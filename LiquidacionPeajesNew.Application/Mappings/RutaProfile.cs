using AutoMapper;
using LiquidacionPeajesNew.Application.DTOs.Requests;
using LiquidacionPeajesNew.Application.DTOs.Responses;
using LiquidacionPeajesNew.Domain.Entities;

namespace LiquidacionPeajesNew.Application.Mappings
{
    public class RutaProfile : Profile
    {
        public RutaProfile()
        {
            CreateMap<RutaEntity, RutaResponse>().ForMember(dest => dest.NombreEstado, opt => opt.MapFrom(src => src.EstadoEntity.Estado));
            CreateMap<RutaRequest, RutaEntity>();
        }
    }
}