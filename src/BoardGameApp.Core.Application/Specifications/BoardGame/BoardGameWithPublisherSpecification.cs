using Ardalis.Specification;

namespace BoardGameApp.Core.Application.Specifications.BoardGame
{
    public class BoardGameWithPublisherSpecification : Specification<Domain.Entities.BoardGame>
    {
        public BoardGameWithPublisherSpecification(int id)
        {
            Query
                .Where(b => b.Id == id)
                .Include(b => b.Publisher);
        }
    }
}
