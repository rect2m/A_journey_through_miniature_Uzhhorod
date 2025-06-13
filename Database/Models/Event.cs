using A_journey_through_miniature_Uzhhorod.Database.Models.Translation;

namespace A_journey_through_miniature_Uzhhorod.Database.Models
{
    public class Event
    {
        public int Id { get; set; }
        public DateTime EventDate { get; set; }

        public List<EventTranslation> Translations { get; set; } = new();
    }
}
