namespace A_journey_through_miniature_Uzhhorod.Database.Models.Translation
{
    public class EventTranslation
    {
        public int Id { get; set; }
        public int EventId { get; set; }
        public string LanguageCode { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public Event Event { get; set; }
    }
}
