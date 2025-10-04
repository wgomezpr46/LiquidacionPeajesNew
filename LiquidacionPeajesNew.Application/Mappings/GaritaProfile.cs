using AutoMapper;
using LiquidacionPeajesNew.Application.DTOs.Requests;
using LiquidacionPeajesNew.Application.DTOs.Responses;
using LiquidacionPeajesNew.Domain.Entities;

namespace LiquidacionPeajesNew.Application.Mappings
{
    public class GaritaProfile : Profile
    {
        public GaritaProfile()
        {
            CreateMap<GaritaEntity, GaritaResponse>()
                .ForMember(dest => dest.NombreZonaGarita, opt => opt.MapFrom(src => src.ZonaGaritaEntity.ZonaGarita))
                .ForMember(dest => dest.NombreTipoGarita, opt => opt.MapFrom(src => src.TipoGaritaEntity.TipoGarita))
                .ForMember(dest => dest.NombreEstado, opt => opt.MapFrom(src => src.EstadoEntity.Estado));

            CreateMap<GaritaRequest, GaritaEntity>();
        }
    }
}