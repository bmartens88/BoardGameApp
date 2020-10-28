using AutoMapper;
using BoardGameApp.Core.Application.DTO.BoardGame;
using BoardGameApp.Core.Application.Interfaces;
using BoardGameApp.Core.Application.Specifications.BoardGame;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace BoardGameApp.Core.Application.Features.BoardGame.Queries
{
    public class GetAllBoardGamesQuery : IRequest<IEnumerable<BoardGameDTO>>
    {

        public class GetAllBoardGamesQueryHandler : IRequestHandler<GetAllBoardGamesQuery, IEnumerable<BoardGameDTO>>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IMapper _mapper;

            public GetAllBoardGamesQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }

            public async Task<IEnumerable<BoardGameDTO>> Handle(GetAllBoardGamesQuery _, CancellationToken cancellationToken)
            {
                var spec = new AllBoardGamesWithPublisherSpecification();
                var items = await _unitOfWork.Repository<Domain.Entities.BoardGame>().ListAsync(spec);
                return _mapper.Map<IEnumerable<BoardGameDTO>>(items);
            }
        }
    }
}
