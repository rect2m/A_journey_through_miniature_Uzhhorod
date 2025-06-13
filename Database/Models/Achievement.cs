using A_journey_through_miniature_Uzhhorod.Database.Models.Translation;

namespace A_journey_through_miniature_Uzhhorod.Database.Models
{
    public class Achievement
    {
        public int Id { get; set; }

        public string IconName { get; set; } = "Trophy";
        public bool IsSecret { get; set; } = false;

        public int QuestId { get; set; }
        public Quest Quest { get; set; } = null!;

        public List<AchievementTranslation> Translations { get; set; } = new();
        public List<UserAchievement> UserAchievements { get; set; } = new();
    }
}
