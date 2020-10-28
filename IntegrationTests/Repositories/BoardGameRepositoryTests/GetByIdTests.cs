using BoardGameApp.Core.Domain.Entities;
using BoardGameApp.Infrastructure.Persistence.Data;
using Fixtures;
using Fixtures.Data;
using System.Threading.Tasks;
using Xunit;

namespace IntegrationTests.Repositories.BoardGameRepositoryTests
{
    public class GetByIdTests : IClassFixture<BoardGamesContextFactory>
    {
        private readonly GenericRepository<BoardGame> _repository;

        public GetByIdTests(BoardGamesContextFactory factory) => _repository = new GenericRepository<BoardGame>(factory.ContextInstance);

        [Fact]
        public async Task BoardGameRepository_ShouldReturnBoardGame_WhenGivenExistingId()
        {
            var gameFromRepo = await _repository.GetByIdAsync(BoardGames.DEFAULT_BOARDGAME.Id);
            Assert.NotNull(gameFromRepo);
            Assert.Equal(BoardGames.DEFAULT_BOARDGAME.Title, gameFromRepo.Title);
        }

        [Fact]
        public async Task BoardGameRepository_ShouldReturnNull_WhenGivenNonExistingId()
        {
            var gameFromRepo = await _repository.GetByIdAsync(++BoardGames.DEFAULT_BOARDGAME.Id);
            Assert.Null(gameFromRepo);
        }
    }
}
