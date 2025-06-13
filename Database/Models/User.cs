namespace A_journey_through_miniature_Uzhhorod.Database.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public UserRole Role { get; set; } = UserRole.User;
        public UserStatus Status { get; set; } = UserStatus.Active;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public string AvatarUrl { get; set; }

        public List<Review> Reviews { get; set; } = new();
        public List<UserQuest> UserQuests { get; set; } = new();
        public ICollection<FavoriteMiniature> FavoriteMiniatures { get; set; } = new List<FavoriteMiniature>();
        public List<UserAchievement> UserAchievements { get; set; } = new();
    }

    public enum UserRole
    {
        User,
        Admin
    }

    public enum UserStatus
    {
        Active,
        Blocked
    }
}
