namespace A_journey_through_miniature_Uzhhorod.Database.Models.Translation
{
    public class QuestTranslation
    {
        public int Id { get; set; }
        public int QuestId { get; set; }
        public string LanguageCode { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public Quest Quest { get; set; }
    }
}
