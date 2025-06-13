namespace A_journey_through_miniature_Uzhhorod.Database.Models
{
    public class UserAchievement
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int AchievementId { get; set; }
        public DateTime UnlockedAt { get; set; }

        public User User { get; set; }
        public Achievement Achievement { get; set; }
    }
}
