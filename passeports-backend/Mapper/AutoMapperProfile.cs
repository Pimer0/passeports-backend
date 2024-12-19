using AutoMapper;
using passeports_backend.DTOs;
using passeports_backend.entities;

namespace passeports_backend.Mapper;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<Passeport, PasseportDto>();
        CreateMap<Avantage, AvantageDto>();
    }
}