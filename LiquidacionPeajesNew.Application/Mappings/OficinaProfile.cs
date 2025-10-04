using AutoMapper;
using LiquidacionPeajesNew.Application.DTOs.Responses;
using LiquidacionPeajesNew.Domain.Entities;

namespace LiquidacionPeajesNew.Application.Mappings
{
    public class OficinaProfile : Profile
    {
        public OficinaProfile()
        {
            CreateMap<OficinaEntity, OficinaResponse>();
        }
    }
}