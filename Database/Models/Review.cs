namespace A_journey_through_miniature_Uzhhorod.Database.Models
{
    using System;

    public class Review
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int MiniatureId { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public User User { get; set; }
        public Miniature Miniature { get; set; }
    }
}
