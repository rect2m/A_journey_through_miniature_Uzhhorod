namespace A_journey_through_miniature_Uzhhorod.Database.Models.Translation
{
    public class MiniatureTranslation
    {
        public int Id { get; set; }
        public int MiniatureId { get; set; }
        public string LanguageCode { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public Miniature Miniature { get; set; }
    }
}
