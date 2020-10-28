using Ardalis.Specification;
using AutoMapper;
using BoardGameApp.Core.Application.Features.BoardGame.Queries;
using BoardGameApp.Core.Application.Interfaces;
using BoardGameApp.Core.Application.Mapping;
using BoardGameApp.Core.Domain.Entities;
using Moq;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using static BoardGameApp.Core.Application.Features.BoardGame.Queries.GetAllBoardGamesQuery;

namespace UnitTests.MediatorHandlers.BoardGamesTests.Queries
{
    public class GetAllBoardGamesQueryTests
    {
        private readonly Mock<IUnitOfWork> _unitOfWork;
        private readonly Mock<IGenericRepository<BoardGame>> _repository;
        private readonly IMapper _mapper;

        public GetAllBoardGamesQueryTests()
        {
            var boardGame = new BoardGame
            {
                Title = "De Legenden van Andor",
                Description = "Spannend coöperatief bordspel voor het hele gezin. Verdedig Andor als tovenaar, dwerg, boogschutter of krijger tegen onder andere trollen en een oeroude draak. Vijf verschillende legenden leiden je stap voor stap door het verhaal en de spelregels!",
                MinPlayers = 2,
                MaxPlayers = 4,
                MinAge = 10,
                Price = 44.99m,
                PictureUri = "https://www.999games.nl/media/catalog/product/cache/59229511a255889d0a4402cca1d50739/D/e/De_Legenden_van_Andor.png",
                Publisher = new Publisher
                {
                    Name = "999 Games",
                    Description = "999 Games is een Nederlandse uitgever van bordspellen, kaartspellen en ruilkaartspellen. Het bedrijf ontstond in 1990 als postorderbedrijf."
                }
            };

            _unitOfWork = new Mock<IUnitOfWork>();
            _repository = new Mock<IGenericRepository<BoardGame>>();
            _unitOfWork.Setup(u => u.Repository<BoardGame>())
                .Returns(_repository.Object);
            _repository.Setup(r => r.ListAsync(It.IsAny<ISpecification<BoardGame>>()))
                .ReturnsAsync(new List<BoardGame> { boardGame });
            _mapper = new MapperConfiguration(opts => opts.AddProfile(new MappingProfile())).CreateMapper();
        }

        [Fact]
        public async Task GetAllBoardGamesQueryHandler_ShouldReturnBoardGames()
        {
            var request = new GetAllBoardGamesQuery();

            var handler = new GetAllBoardGamesQueryHandler(_unitOfWork.Object, _mapper);

            var result = await handler.Handle(request, CancellationToken.None);

            Assert.NotNull(result);
            Assert.Single(result);
        }
    }
}
