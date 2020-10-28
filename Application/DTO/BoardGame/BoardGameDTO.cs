using BoardGameApp.Core.Application.DTO.Publisher;

namespace BoardGameApp.Core.Application.DTO.BoardGame
{
    public class BoardGameDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int MinPlayers { get; set; }
        public int MaxPlayers { get; set; }
        public int MinAge { get; set; }
        public int MaxAge { get; set; }
        public decimal? Price { get; set; }
        public string PictureUri { get; set; }
        public PublisherDTO Publisher { get; set; }
    }
}
