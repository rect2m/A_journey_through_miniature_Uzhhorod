using A_journey_through_miniature_Uzhhorod.Database.Models.Translation;

namespace A_journey_through_miniature_Uzhhorod.Database.Models
{
    public class Quest
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public int TargetCount { get; set; }
        public string? IconName { get; set; }

        public int? ParentQuestId { get; set; }
        public Quest? ParentQuest { get; set; }
        public List<Quest> ChildQuests { get; set; } = new();

        public List<QuestTranslation> Translations { get; set; } = new();
    }

}
