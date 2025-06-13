namespace A_journey_through_miniature_Uzhhorod.Database.Models
{
    public class Feedback
    {
        public int Id { get; set; }

        public int? UserId { get; set; }
        public virtual User? User { get; set; }

        public string Email { get; set; }
        public string Category { get; set; }
        public string Message { get; set; }
        public DateTime SentAt { get; set; } = DateTime.UtcNow;

        public string? AdminResponse { get; set; }
        public DateTime? RespondedAt { get; set; }
    }
}
