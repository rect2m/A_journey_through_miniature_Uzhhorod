namespace A_journey_through_miniature_Uzhhorod.Database.Models
{
    public class FavoriteMiniature
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int MiniatureId { get; set; }

        public User User { get; set; }
        public Miniature Miniature { get; set; }
    }

}
