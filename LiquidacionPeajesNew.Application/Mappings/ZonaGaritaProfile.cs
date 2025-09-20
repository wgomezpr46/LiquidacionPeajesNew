using AutoMapper;
using LiquidacionPeajesNew.Application.DTOs.Responses;
using LiquidacionPeajesNew.Domain.Entities;

namespace LiquidacionPeajesNew.Application.Mappings
{
    public class ZonaGaritaProfile : Profile
    {
        public ZonaGaritaProfile()
        {
            CreateMap<ZonaGaritaEntity, ZonaGaritaResponse>();
        }
    }
}