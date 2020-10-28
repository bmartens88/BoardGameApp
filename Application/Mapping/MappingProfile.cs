using AutoMapper;
using BoardGameApp.Core.Application.DTO.BoardGame;
using BoardGameApp.Core.Application.DTO.Publisher;
using BoardGameApp.Core.Domain.Entities;

namespace BoardGameApp.Core.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<BoardGame, BoardGameDTO>();
            CreateMap<Publisher, PublisherDTO>();
        }
    }
}
