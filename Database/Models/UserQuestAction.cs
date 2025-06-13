namespace A_journey_through_miniature_Uzhhorod.Database.Models
{
    public class UserQuestAction
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string QuestType { get; set; }
        public string TargetKey { get; set; }
        public DateTime Timestamp { get; set; }
    }

}
