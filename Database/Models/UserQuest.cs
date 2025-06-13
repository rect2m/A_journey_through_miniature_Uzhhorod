namespace A_journey_through_miniature_Uzhhorod.Database.Models
{
    public class UserQuest
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int QuestId { get; set; }
        public int Progress { get; set; }
        public bool IsCompleted { get; set; }

        public User User { get; set; }
        public Quest Quest { get; set; }
    }

}
