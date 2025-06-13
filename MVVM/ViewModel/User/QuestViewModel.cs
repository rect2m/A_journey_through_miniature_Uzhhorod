using A_journey_through_miniature_Uzhhorod.Database;
using A_journey_through_miniature_Uzhhorod.MVVM.Model.Service;
using A_journey_through_miniature_Uzhhorod.Properties;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;

namespace A_journey_through_miniature_Uzhhorod.MVVM.ViewModel
{
    public class QuestViewModel : ViewModelBase
    {
        public ObservableCollection<QuestNodeViewModel> Nodes { get; set; } = new();
        public QuestNodeViewModel? RootNode { get; set; }

        private readonly IAppDbContextFactory _contextFactory;
        private readonly QuestService _questService;

        private string CurrentLanguage => Settings.Default.LanguageCode;

        public QuestViewModel(IAppDbContextFactory contextFactory, QuestService questService)
        {
            _contextFactory = contextFactory;
            _questService = questService;

            LanguageManager.LanguageChanged += BuildTree;
            BuildTree();
        }

        public void BuildTree()
        {
            using var context = _contextFactory.CreateContext();

            _questService.RefreshDynamicQuestTargets();

            var user = context.Users.FirstOrDefault(u => u.Username == Settings.Default.username);
            if (user == null) return;

            var quests = context.Quests
                .Include(q => q.Translations)
                .Include(q => q.ChildQuests)
                .ToList();

            var userQuests = context.UserQuests
                .Where(uq => uq.UserId == user.Id)
                .ToList();

            var questMap = new Dictionary<int, QuestNodeViewModel>();

            foreach (var quest in quests)
            {
                var translation = quest.Translations.FirstOrDefault(t => t.LanguageCode == CurrentLanguage)
                                    ?? quest.Translations.FirstOrDefault();

                var userQuest = userQuests.FirstOrDefault(uq => uq.QuestId == quest.Id);

                var vm = new QuestNodeViewModel
                {
                    QuestId = quest.Id,
                    Title = translation?.Title ?? "Квест",
                    Description = translation?.Description ?? "",
                    TargetCount = quest.TargetCount,
                    Progress = userQuest?.Progress ?? 0,
                    IsCompleted = userQuest?.IsCompleted ?? false,
                    IconName = quest.IconName ?? "Question",
                };

                questMap[quest.Id] = vm;
            }

            foreach (var quest in quests)
            {
                if (quest.ParentQuestId.HasValue)
                {
                    var parent = questMap[quest.ParentQuestId.Value];
                    parent.Children.Add(questMap[quest.Id]);
                }
            }

            var root = questMap.Values.FirstOrDefault(q => quests.First(p => p.Id == q.QuestId).Type == "Register");
            if (root == null) return;

            RootNode = root;

            double centerX = 800, centerY = 600;
            LayoutRadial(root, centerX, centerY, 0, 2 * Math.PI);

            Nodes.Clear();
            Nodes.Add(root);
        }

        private void LayoutRadial(QuestNodeViewModel node, double centerX, double centerY, double startAngle, double endAngle, double radius = 160, int depth = 1)
        {
            node.X = centerX;
            node.Y = centerY;

            if (node.Children.Count == 0) return;

            double angleStep = (endAngle - startAngle) / node.Children.Count;
            double childRadius = radius * 1.4;

            for (int i = 0; i < node.Children.Count; i++)
            {
                double angle = startAngle + angleStep * i + angleStep / 2;
                double childX = centerX + Math.Cos(angle) * childRadius;
                double childY = centerY + Math.Sin(angle) * childRadius;

                var child = node.Children[i];
                child.X = childX;
                child.Y = childY;

                LayoutRadial(child, childX, childY, angle - angleStep / 2, angle + angleStep / 2, radius, depth + 1);
            }
        }
    }
}
