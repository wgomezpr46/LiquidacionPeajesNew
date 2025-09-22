using AutoMapper;
using LiquidacionPeajesNew.Application.DTOs.Requests;
using LiquidacionPeajesNew.Application.DTOs.Responses;
using LiquidacionPeajesNew.Domain.Entities;

namespace LiquidacionPeajesNew.Application.Mappings
{
    public class TipoGaritaProfile : Profile
    {
        public TipoGaritaProfile()
        {
            CreateMap<TipoGaritaEntity, TipoGaritaResponse>()
                .ForMember(dest => dest.NombreModoPagoGarita, opt => opt.MapFrom(src => src.ModoPagoGaritaEntity.ModoPagoGarita))
                .ForMember(dest => dest.NombreEstado, opt => opt.MapFrom(src => src.EstadoEntity.Estado));

            CreateMap<TipoGaritaRequest, TipoGaritaEntity>();
        }
    }
}