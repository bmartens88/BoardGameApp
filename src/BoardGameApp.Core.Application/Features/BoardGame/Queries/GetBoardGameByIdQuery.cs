using AutoMapper;
using BoardGameApp.Core.Application.DTO.BoardGame;
using BoardGameApp.Core.Application.Interfaces;
using BoardGameApp.Core.Application.Specifications.BoardGame;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BoardGameApp.Core.Application.Features.BoardGame.Queries
{
    public class GetBoardGameByIdQuery : IRequest<BoardGameDTO>
    {
        public int Id { get; set; }

        public class GetBoardGameByIdQueryHandler : IRequestHandler<GetBoardGameByIdQuery, BoardGameDTO>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IMapper _mapper;

            public GetBoardGameByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }

            public async Task<BoardGameDTO> Handle(GetBoardGameByIdQuery query, CancellationToken cancellationToken)
            {
                var spec = new BoardGameWithPublisherSpecification(query.Id);
                var results = await _unitOfWork.Repository<Domain.Entities.BoardGame>().ListAsync(spec);
                var item = results.FirstOrDefault(b => b.Id == query.Id);
                if (item == null) return null;
                return _mapper.Map<BoardGameDTO>(item);
            }
        }
    }
}
