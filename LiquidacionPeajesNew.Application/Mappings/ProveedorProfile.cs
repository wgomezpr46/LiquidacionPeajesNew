using AutoMapper;
using LiquidacionPeajesNew.Application.DTOs.Requests;
using LiquidacionPeajesNew.Application.DTOs.Responses;
using LiquidacionPeajesNew.Domain.Entities;

namespace LiquidacionPeajesNew.Application.Mappings
{
    public class ProveedorProfile : Profile
    {
        public ProveedorProfile()
        {
            CreateMap<ProveedorEntity, ProveedorResponse>()
                .ForMember(dest => dest.NombreTipoDoc, opt => opt.MapFrom(src => src.TipoDocumentoCompraEntity.TipoDoc))
                .ForMember(dest => dest.NombreEstado, opt => opt.MapFrom(src => src.EstadoEntity.Estado));

            CreateMap<ProveedorRequest, ProveedorEntity>();
        }
    }
}