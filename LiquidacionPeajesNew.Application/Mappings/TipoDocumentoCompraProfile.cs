using AutoMapper;
using LiquidacionPeajesNew.Application.DTOs.Responses;
using LiquidacionPeajesNew.Domain.Entities;

namespace LiquidacionPeajesNew.Application.Mappings
{
    public class TipoDocumentoCompraProfile : Profile
    {
        public TipoDocumentoCompraProfile()
        {
            CreateMap<TipoDocumentoCompraEntity, TipoDocumentoCompraResponse>();
        }
    }
}