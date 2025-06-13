using A_journey_through_miniature_Uzhhorod.Database.Models;
using A_journey_through_miniature_Uzhhorod.Database.Models.Translation;
using Microsoft.EntityFrameworkCore;

namespace A_journey_through_miniature_Uzhhorod.Database
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Miniature> Miniatures { get; set; }
        public DbSet<MiniatureTranslation> MiniatureTranslations { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Quest> Quests { get; set; }
        public DbSet<QuestTranslation> QuestTranslations { get; set; }
        public DbSet<Achievement> Achievements { get; set; }
        public DbSet<AchievementTranslation> AchievementTranslations { get; set; }
        public DbSet<UserAchievement> UserAchievements { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<EventTranslation> EventTranslations { get; set; }
        public DbSet<UserActivity> UserActivities { get; set; }
        public DbSet<UserActivityTranslation> UserActivityTranslations { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<UserQuest> UserQuests { get; set; }
        public DbSet<FavoriteMiniature> FavoriteMiniatures { get; set; }
        public DbSet<UserQuestAction> UserQuestActions { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // 🔹 Users
            modelBuilder.Entity<User>()
                .Property(u => u.Username)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<User>()
                .Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(255);

            modelBuilder.Entity<User>()
                .Property(u => u.PasswordHash)
                .IsRequired();

            modelBuilder.Entity<User>()
                .Property(u => u.Role)
                .HasConversion<string>()
                .HasDefaultValue(UserRole.User);

            modelBuilder.Entity<User>()
                .Property(u => u.Status)
                .HasConversion<string>()
                .HasDefaultValue(UserStatus.Active);


            modelBuilder.Entity<User>()
                .Property(u => u.AvatarUrl)
                .IsRequired(false);

            // 🔹 Miniatures
            modelBuilder.Entity<Miniature>()
                .Property(m => m.Latitude).IsRequired();
            modelBuilder.Entity<Miniature>()
                .Property(m => m.Longitude).IsRequired();
            modelBuilder.Entity<Miniature>()
                .Property(m => m.ImageUrl).IsRequired(false);

            modelBuilder.Entity<MiniatureTranslation>()
                .HasOne(mt => mt.Miniature)
                .WithMany(m => m.Translations)
                .HasForeignKey(mt => mt.MiniatureId)
                .OnDelete(DeleteBehavior.Cascade);

            // 🔹 Reviews
            modelBuilder.Entity<Review>()
                .Property(r => r.Rating).IsRequired();
            modelBuilder.Entity<Review>()
                .Property(r => r.Comment).IsRequired(false);
            modelBuilder.Entity<Review>()
                .HasOne(r => r.User)
                .WithMany(u => u.Reviews)
                .HasForeignKey(r => r.UserId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Review>()
                .HasOne(r => r.Miniature)
                .WithMany(m => m.Reviews)
                .HasForeignKey(r => r.MiniatureId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Review>()
                .Property(r => r.CreatedAt)
                .HasConversion(v => v, v => DateTime.SpecifyKind(v, DateTimeKind.Utc));

            // 🔹 Quests
            modelBuilder.Entity<QuestTranslation>()
                .HasOne(qt => qt.Quest)
                .WithMany(q => q.Translations)
                .HasForeignKey(qt => qt.QuestId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Quest>()
                .HasOne(q => q.ParentQuest)
                .WithMany(q => q.ChildQuests)
                .HasForeignKey(q => q.ParentQuestId)
                .OnDelete(DeleteBehavior.Restrict);

            // 🔹 Achievements
            modelBuilder.Entity<Achievement>()
                .HasOne(a => a.Quest)
                .WithOne()
                .HasForeignKey<Achievement>(a => a.QuestId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<AchievementTranslation>()
                .HasOne(at => at.Achievement)
                .WithMany(a => a.Translations)
                .HasForeignKey(at => at.AchievementId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<UserAchievement>()
                .HasOne(ua => ua.User)
                .WithMany(u => u.UserAchievements)
                .HasForeignKey(ua => ua.UserId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<UserAchievement>()
                .HasOne(ua => ua.Achievement)
                .WithMany(a => a.UserAchievements)
                .HasForeignKey(ua => ua.AchievementId)
                .OnDelete(DeleteBehavior.Cascade);

            // 🔹 Events
            modelBuilder.Entity<Event>()
                .Property(e => e.EventDate)
                .IsRequired()
                .HasConversion(v => v, v => DateTime.SpecifyKind(v, DateTimeKind.Utc));
            modelBuilder.Entity<EventTranslation>()
                .HasOne(et => et.Event)
                .WithMany(e => e.Translations)
                .HasForeignKey(et => et.EventId)
                .OnDelete(DeleteBehavior.Cascade);

            // 🔹 UserActivity Translations
            modelBuilder.Entity<UserActivityTranslation>()
                .HasOne(t => t.UserActivity)
                .WithMany(a => a.Translations)
                .HasForeignKey(t => t.UserActivityId)
                .OnDelete(DeleteBehavior.Cascade);

            // 🔹 UserQuests
            modelBuilder.Entity<UserQuest>()
                .HasOne(uq => uq.User)
                .WithMany(u => u.UserQuests)
                .HasForeignKey(uq => uq.UserId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<UserQuest>()
                .HasOne(uq => uq.Quest)
                .WithMany()
                .HasForeignKey(uq => uq.QuestId)
                .OnDelete(DeleteBehavior.Cascade);

            // 🔹 Favorites
            modelBuilder.Entity<FavoriteMiniature>()
                .HasOne(f => f.User)
                .WithMany(u => u.FavoriteMiniatures)
                .HasForeignKey(f => f.UserId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<FavoriteMiniature>()
                .HasOne(f => f.Miniature)
                .WithMany()
                .HasForeignKey(f => f.MiniatureId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Feedback>()
                .HasOne(f => f.User)
                .WithMany()
                .HasForeignKey(f => f.UserId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
