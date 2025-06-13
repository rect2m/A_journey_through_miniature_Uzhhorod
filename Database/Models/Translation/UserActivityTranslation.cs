namespace A_journey_through_miniature_Uzhhorod.Database.Models.Translation
{
    public class UserActivityTranslation
    {
        public int Id { get; set; }
        public int UserActivityId { get; set; }

        public string LanguageCode { get; set; }

        public string Action { get; set; }
        public string Details { get; set; }

        public UserActivity UserActivity { get; set; }
    }
}
