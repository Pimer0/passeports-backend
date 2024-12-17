using AutoMapper;
using passeports_backend.DTOs;
using passeports_backend.entities;

namespace passeports_backend.Mapper;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<Avantage, AvantageDto>()
            .ConstructUsing(a => new AvantageDto(a.Id, a.Contenu, a.PaysVisitables));
        CreateMap<AvantageDto, Avantage>();
    }
}