namespace A_journey_through_miniature_Uzhhorod.Database.Models.Translation
{
    public class AchievementTranslation
    {
        public int Id { get; set; }
        public int AchievementId { get; set; }
        public string LanguageCode { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public Achievement Achievement { get; set; }
    }
}
