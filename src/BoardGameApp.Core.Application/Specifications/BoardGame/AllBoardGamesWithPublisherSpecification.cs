using Ardalis.Specification;

namespace BoardGameApp.Core.Application.Specifications.BoardGame
{
    public class AllBoardGamesWithPublisherSpecification : Specification<Domain.Entities.BoardGame>
    {
        public AllBoardGamesWithPublisherSpecification()
        {
            Query
                .Include(b => b.Publisher);
        }
    }
}
