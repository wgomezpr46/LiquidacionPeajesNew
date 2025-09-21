using AutoMapper;
using LiquidacionPeajesNew.Application.DTOs.Requests;
using LiquidacionPeajesNew.Application.DTOs.Responses;
using LiquidacionPeajesNew.Domain.Entities;

namespace LiquidacionPeajesNew.Application.Mappings
{
    public class ModoPagoGaritaProfile : Profile
    {
        public ModoPagoGaritaProfile()
        {
            CreateMap<ModoPagoGaritaEntity, ModoPagoGaritaResponse>().ForMember(dest => dest.NombreEstado, opt => opt.MapFrom(src => src.EstadoEntity.Estado));
            CreateMap<ModoPagoGaritaRequest, ModoPagoGaritaEntity>();
        }
    }
}