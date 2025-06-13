using A_journey_through_miniature_Uzhhorod.Database.Models.Translation;

namespace A_journey_through_miniature_Uzhhorod.Database.Models
{
    public class Miniature
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; }
        public string? ModelUrl { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public List<MiniatureTranslation> Translations { get; set; } = new();

        public List<Review> Reviews { get; set; } = new();
    }

}
