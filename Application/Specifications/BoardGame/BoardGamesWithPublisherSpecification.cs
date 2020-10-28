using Ardalis.Specification;

namespace BoardGameApp.Core.Application.Specifications.BoardGame
{
    public class BoardGamesWithPublisherSpecification : Specification<Domain.Entities.BoardGame>
    {
        public BoardGamesWithPublisherSpecification()
        {
            Query
                .Include(b => b.Publisher);
        }
    }
}
