using A_journey_through_miniature_Uzhhorod.Database;
using A_journey_through_miniature_Uzhhorod.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace A_journey_through_miniature_Uzhhorod.MVVM.Model.Service
{
    public class AchievementService
    {
        private readonly AppDbContext _context;

        public AchievementService(AppDbContext context)
        {
            _context = context;
        }

        public void GrantIfEligible(int userId, int questId)
        {
            var achievement = _context.Achievements
                .Include(a => a.UserAchievements)
                .FirstOrDefault(a => a.QuestId == questId);

            if (achievement == null)
                return;

            bool alreadyUnlocked = achievement.UserAchievements.Any(ua => ua.UserId == userId);
            if (alreadyUnlocked)
                return;

            _context.UserAchievements.Add(new UserAchievement
            {
                UserId = userId,
                AchievementId = achievement.Id,
                UnlockedAt = DateTime.UtcNow.AddHours(3)
            });

            _context.SaveChanges();
        }
    }
}