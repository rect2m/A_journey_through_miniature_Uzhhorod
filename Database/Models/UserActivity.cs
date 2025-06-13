using A_journey_through_miniature_Uzhhorod.Database.Models.Translation;

namespace A_journey_through_miniature_Uzhhorod.Database.Models
{
    public class UserActivity
    {
        public int Id { get; set; }
        public int UserId { get; set; }

        public DateTime Timestamp { get; set; } = DateTime.UtcNow;

        public User User { get; set; }

        public List<UserActivityTranslation> Translations { get; set; } = new();
    }
}
