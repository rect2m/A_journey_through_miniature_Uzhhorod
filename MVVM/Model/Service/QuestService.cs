using A_journey_through_miniature_Uzhhorod.Database;
using A_journey_through_miniature_Uzhhorod.Database.Models;
using A_journey_through_miniature_Uzhhorod.Database.Models.Translation;
using A_journey_through_miniature_Uzhhorod.MVVM.Model.Notification;
using Microsoft.EntityFrameworkCore;
using static A_journey_through_miniature_Uzhhorod.MVVM.ViewModel.MiniaturesViewModel;

namespace A_journey_through_miniature_Uzhhorod.MVVM.Model.Service
{
    public class QuestService
    {
        private readonly IAppDbContextFactory _contextFactory;
        private readonly AchievementService _achievementService;
        private readonly ToastManager _toastManager;
        private readonly string _secretPhrase = "blueberry";
        private List<MiniatureViewModel> _allMiniatures = new();

        public QuestService(IAppDbContextFactory contextFactory, AchievementService achievementService, ToastManager toastManager)
        {
            _contextFactory = contextFactory;
            _achievementService = achievementService;
            _toastManager = toastManager;
        }

        private void ShowSecretHint(string questType)
        {
            var hintMap = new Dictionary<string, int>
            {
            { "ViewAllMiniatures", 0 },
            { "AddAllFavorites", 3 },
            { "CompleteAllQuests", 6 }
            };

            if (hintMap.TryGetValue(questType, out int index) && _secretPhrase.Length >= index + 3)
            {
                string hint = _secretPhrase.Substring(index, 3);
                string lang = LanguageManager.CurrentLanguage;

                string title = lang == "uk" ? "🔐 Секретна підказка" : "🔐 Secret Hint";
                string message = lang == "uk" ? $"Букви: {hint}" : $"Letters: {hint}";

                _toastManager.ShowToast(title, message, "KeyRound");
            }
        }

        public void MarkSecretQuestCompleted(int userId)
        {
            using var context = _contextFactory.CreateContext();

            var secretQuest = context.Quests.FirstOrDefault(q => q.Type == "SecretQuest");
            if (secretQuest == null) return;

            int total = context.Quests.Count(q => q.Type != "SecretQuest");
            int completed = context.UserQuests.Count(uq => uq.UserId == userId && uq.IsCompleted && uq.Quest.Type != "SecretQuest");

            if (completed < total) return;

            var userQuest = context.UserQuests.FirstOrDefault(uq => uq.UserId == userId && uq.QuestId == secretQuest.Id);
            if (userQuest != null && userQuest.IsCompleted) return;

            if (userQuest == null)
            {
                userQuest = new UserQuest
                {
                    UserId = userId,
                    QuestId = secretQuest.Id,
                    Progress = secretQuest.TargetCount,
                    IsCompleted = true
                };
                context.UserQuests.Add(userQuest);
            }
            else
            {
                userQuest.Progress = secretQuest.TargetCount;
                userQuest.IsCompleted = true;
            }

            context.SaveChanges();
            ShowAchievementToast(userId, secretQuest.Id);
        }

        private void ShowAchievementToast(int userId, int questId)
        {
            using var context = _contextFactory.CreateContext();

            var achievement = context.Achievements
                .Include(a => a.UserAchievements)
                .Include(a => a.Translations)
                .Include(a => a.Quest)
                    .ThenInclude(q => q.Translations)
                .FirstOrDefault(a => a.QuestId == questId && !a.UserAchievements.Any(ua => ua.UserId == userId));

            if (achievement != null)
            {
                context.UserAchievements.Add(new UserAchievement
                {
                    UserId = userId,
                    AchievementId = achievement.Id,
                    UnlockedAt = DateTime.UtcNow.AddHours(3)
                });

                string lang = LanguageManager.CurrentLanguage;

                var achievementTranslation = achievement.Translations.FirstOrDefault(t => t.LanguageCode == lang)
                                         ?? achievement.Translations.FirstOrDefault();

                string title = achievementTranslation?.Title ?? (lang == "uk" ? "Досягнення!" : "Achievement!");
                string description = achievementTranslation?.Description ?? (lang == "uk" ? "Ви отримали нове досягнення." : "You have unlocked a new achievement.");

                var questTitle = achievement.Quest?.Translations.FirstOrDefault(t => t.LanguageCode == lang)?.Title
                              ?? achievement.Quest?.Translations.FirstOrDefault()?.Title
                              ?? (lang == "uk" ? "Невідомий квест" : "Unknown quest");

                context.UserActivities.Add(new UserActivity
                {
                    UserId = userId,
                    Timestamp = DateTime.UtcNow.AddHours(3),
                    Translations = new List<UserActivityTranslation>
            {
                new UserActivityTranslation { LanguageCode = "uk", Action = "Виконано квест", Details = questTitle },
                new UserActivityTranslation { LanguageCode = "en", Action = "Quest completed", Details = questTitle }
            }
                });

                context.UserActivities.Add(new UserActivity
                {
                    UserId = userId,
                    Timestamp = DateTime.UtcNow.AddHours(3),
                    Translations = new List<UserActivityTranslation>
            {
                new UserActivityTranslation { LanguageCode = "uk", Action = "Отримано досягнення", Details = title },
                new UserActivityTranslation { LanguageCode = "en", Action = "Achievement unlocked", Details = title }
            }
                });

                context.SaveChanges();

                _toastManager.ShowToast(title, description, achievement.IconName);
                ShowSecretHint(achievement.Quest.Type);
            }
        }


        public void RefreshDynamicQuestTargets()
        {
            using var context = _contextFactory.CreateContext();

            int totalMiniatures = context.Miniatures.Count();

            var dynamicQuestTypes = new[] { "ViewAllMiniatures", "AddAllFavorites" };

            var dynamicQuests = context.Quests
                .Where(q => dynamicQuestTypes.Contains(q.Type))
                .ToList();

            foreach (var quest in dynamicQuests)
            {
                if (quest.TargetCount != totalMiniatures)
                {
                    quest.TargetCount = totalMiniatures;
                    context.Entry(quest).State = EntityState.Modified;
                }
            }

            context.SaveChanges();
        }

        public void UpdateSimpleQuest(int userId, string questType)
        {
            using var context = _contextFactory.CreateContext();

            var quest = context.Quests.FirstOrDefault(q => q.Type == questType);
            if (quest == null) return;

            var userQuest = context.UserQuests.FirstOrDefault(uq => uq.UserId == userId && uq.QuestId == quest.Id);
            if (userQuest == null || userQuest.IsCompleted) return;

            userQuest.Progress++;
            if (userQuest.Progress >= quest.TargetCount)
            {
                userQuest.IsCompleted = true;
                ActivateChildQuests(userId, quest.Id);
                UpdateCompletedQuestCounters(userId);
                ShowAchievementToast(userId, quest.Id);
            }

            context.SaveChanges();
        }

        public void UpdateMiniatureViewQuest(int userId, int miniatureId)
        {
            using var context = _contextFactory.CreateContext();

            if (context.UserQuestActions.Any(a =>
                a.UserId == userId &&
                a.QuestType == "ViewMiniature" &&
                a.TargetKey == miniatureId.ToString()))
                return;

            context.UserQuestActions.Add(new UserQuestAction
            {
                UserId = userId,
                QuestType = "ViewMiniature",
                TargetKey = miniatureId.ToString(),
                Timestamp = DateTime.UtcNow.AddHours(3)
            });

            context.SaveChanges();

            int viewedCount = context.UserQuestActions
                .Where(a => a.UserId == userId && a.QuestType == "ViewMiniature")
                .Select(a => a.TargetKey)
                .Distinct()
                .Count();

            int totalMiniatures = context.Miniatures.Count();

            var questTypes = new[] { "ViewFirstMiniature", "View10Miniatures", "View30Miniatures", "ViewAllMiniatures" };

            foreach (var type in questTypes)
            {
                var quest = context.Quests.FirstOrDefault(q => q.Type == type);
                if (quest == null) continue;

                if (type == "ViewAllMiniatures")
                {
                    quest.TargetCount = totalMiniatures;
                    context.Entry(quest).State = EntityState.Modified;
                }

                var userQuest = context.UserQuests.FirstOrDefault(uq => uq.UserId == userId && uq.QuestId == quest.Id);
                if (userQuest == null) continue;

                userQuest.Progress = Math.Min(viewedCount, quest.TargetCount);

                if (!userQuest.IsCompleted && userQuest.Progress >= quest.TargetCount)
                {
                    userQuest.IsCompleted = true;
                    ActivateChildQuests(userId, quest.Id);
                    UpdateCompletedQuestCounters(userId);
                    ShowAchievementToast(userId, quest.Id);
                }
            }

            context.SaveChanges();
        }

        public void UpdateFavoriteQuest(int userId, int miniatureId)
        {
            using var context = _contextFactory.CreateContext();

            if (context.UserQuestActions.Any(a =>
                a.UserId == userId &&
                a.QuestType == "FavoriteMiniature" &&
                a.TargetKey == miniatureId.ToString()))
                return;

            bool isCurrentlyFavorite = context.FavoriteMiniatures
                .AsNoTracking()
                .Any(f => f.UserId == userId && f.MiniatureId == miniatureId);

            if (!isCurrentlyFavorite)
                return;

            context.UserQuestActions.Add(new UserQuestAction
            {
                UserId = userId,
                QuestType = "FavoriteMiniature",
                TargetKey = miniatureId.ToString(),
                Timestamp = DateTime.UtcNow.AddHours(3)
            });

            context.SaveChanges();

            int favoriteCount = context.UserQuestActions
                .Where(a => a.UserId == userId && a.QuestType == "FavoriteMiniature")
                .Select(a => a.TargetKey)
                .Distinct()
                .Count();

            int totalMiniatures = context.Miniatures.Count();

            var questTypes = new[] { "AddFavorite", "Add10Favorites", "Add30Favorites", "AddAllFavorites" };

            foreach (var type in questTypes)
            {
                var quest = context.Quests.FirstOrDefault(q => q.Type == type);
                if (quest == null) continue;

                if (type == "AddAllFavorites")
                {
                    quest.TargetCount = totalMiniatures;
                    context.Entry(quest).State = EntityState.Modified;
                }

                var userQuest = context.UserQuests.FirstOrDefault(uq => uq.UserId == userId && uq.QuestId == quest.Id);
                if (userQuest == null) continue;

                userQuest.Progress = Math.Min(favoriteCount, quest.TargetCount);

                if (!userQuest.IsCompleted && userQuest.Progress >= quest.TargetCount)
                {
                    userQuest.IsCompleted = true;
                    ActivateChildQuests(userId, quest.Id);
                    UpdateCompletedQuestCounters(userId);
                    ShowAchievementToast(userId, quest.Id);
                }
            }

            context.SaveChanges();
        }

        public void UpdateQuestProgress(int userId, string questType)
        {
            using var context = _contextFactory.CreateContext();

            var quest = context.Quests.FirstOrDefault(q => q.Type == questType);
            if (quest == null) return;

            var userQuest = context.UserQuests.FirstOrDefault(uq => uq.UserId == userId && uq.QuestId == quest.Id);
            if (userQuest == null || userQuest.IsCompleted) return;

            userQuest.Progress = Math.Min(userQuest.Progress + 1, quest.TargetCount);
            if (userQuest.Progress >= quest.TargetCount)
            {
                userQuest.IsCompleted = true;
                ActivateChildQuests(userId, quest.Id);
                UpdateCompletedQuestCounters(userId);
                ShowAchievementToast(userId, quest.Id);
            }

            context.SaveChanges();
        }

        public void UpdateUniqueQuest(int userId, string questType, string itemKey)
        {
            using var context = _contextFactory.CreateContext();

            if (context.UserQuestActions.Any(a => a.UserId == userId && a.QuestType == questType && a.TargetKey == itemKey))
                return;

            context.UserQuestActions.Add(new UserQuestAction
            {
                UserId = userId,
                QuestType = questType,
                TargetKey = itemKey,
                Timestamp = DateTime.UtcNow.AddHours(3)
            });

            context.SaveChanges();

            UpdateQuestProgress(userId, questType);
        }

        private void ActivateChildQuests(int userId, int parentQuestId)
        {
            using var context = _contextFactory.CreateContext();

            var childQuests = context.Quests
                .Include(q => q.Translations)
                .Where(q => q.ParentQuestId == parentQuestId)
                .ToList();

            foreach (var child in childQuests)
            {
                var exists = context.UserQuests.Any(uq => uq.UserId == userId && uq.QuestId == child.Id);
                if (!exists)
                {
                    context.UserQuests.Add(new UserQuest
                    {
                        UserId = userId,
                        QuestId = child.Id,
                        Progress = 0,
                        IsCompleted = false
                    });
                }
            }

            context.SaveChanges();
        }

        public void InitializeFirstQuestForUser(int userId)
        {
            using var context = _contextFactory.CreateContext();

            var registerQuest = context.Quests.FirstOrDefault(q => q.Type == "Register");
            if (registerQuest == null) return;

            bool alreadyExists = context.UserQuests.Any(uq => uq.UserId == userId && uq.QuestId == registerQuest.Id);
            if (!alreadyExists)
            {
                context.UserQuests.Add(new UserQuest
                {
                    UserId = userId,
                    QuestId = registerQuest.Id,
                    Progress = 1,
                    IsCompleted = true
                });

                context.SaveChanges();

                ActivateChildQuests(userId, registerQuest.Id);
                UpdateCompletedQuestCounters(userId);
                ShowAchievementToast(userId, registerQuest.Id);
            }
        }

        public void UpdateCompletedQuestCounters(int userId)
        {
            using var context = _contextFactory.CreateContext();

            int completedCount = context.UserQuests
                .Count(uq => uq.UserId == userId && uq.IsCompleted);

            void Update(string questType, int target)
            {
                var quest = context.Quests.FirstOrDefault(q => q.Type == questType);
                if (quest == null) return;

                var userQuest = context.UserQuests.FirstOrDefault(uq => uq.UserId == userId && uq.QuestId == quest.Id);
                if (userQuest == null) return;

                userQuest.Progress = Math.Min(completedCount, quest.TargetCount);

                if (!userQuest.IsCompleted && userQuest.Progress >= quest.TargetCount)
                {
                    userQuest.IsCompleted = true;
                    ActivateChildQuests(userId, quest.Id);
                    ShowAchievementToast(userId, quest.Id);
                }
            }

            Update("Complete5Quests", 5);
            Update("Complete10Quests", 10);

            var allQuest = context.Quests.FirstOrDefault(q => q.Type == "CompleteAllQuests");
            if (allQuest != null)
            {
                int totalQuestCount = context.Quests.Count(q => q.Type != "CompleteAllQuests" && q.Type != "SecretQuest");
                allQuest.TargetCount = totalQuestCount;

                var uq = context.UserQuests.FirstOrDefault(u => u.UserId == userId && u.QuestId == allQuest.Id);
                if (uq != null)
                {
                    uq.Progress = completedCount;

                    if (!uq.IsCompleted && uq.Progress >= totalQuestCount)
                    {
                        uq.IsCompleted = true;
                        ActivateChildQuests(userId, uq.QuestId);
                        ShowAchievementToast(userId, allQuest.Id);
                    }
                }
            }

            context.SaveChanges();
        }
    }
}
