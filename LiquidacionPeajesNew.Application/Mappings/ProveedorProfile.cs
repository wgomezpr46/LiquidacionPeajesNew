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
            CreateMap<ProveedorEntity, ProveedorResponse>().ForMember(dest => dest.TipoDoc, opt => opt.MapFrom(src => src.TipoDocumentoCompra.TipoDoc));
            CreateMap<ProveedorRequest, ProveedorEntity>();
        }
    }
}