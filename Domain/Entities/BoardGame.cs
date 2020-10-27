namespace Domain.Entities
{
    public class BoardGame : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int MinPlayers { get; set; }
        public int MaxPlayers { get; set; }
        public int MinAge { get; set; }
        public int MaxAge { get; set; }
        public decimal Price { get; set; }
        public int PublisherId { get; set; }
        public Publisher Publisher { get; set; }
    }
}
