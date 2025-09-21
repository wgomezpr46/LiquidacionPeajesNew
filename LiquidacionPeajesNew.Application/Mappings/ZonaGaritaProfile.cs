using AutoMapper;
using LiquidacionPeajesNew.Application.DTOs.Requests;
using LiquidacionPeajesNew.Application.DTOs.Responses;
using LiquidacionPeajesNew.Domain.Entities;

namespace LiquidacionPeajesNew.Application.Mappings
{
    public class ZonaGaritaProfile : Profile
    {
        public ZonaGaritaProfile()
        {
            CreateMap<ZonaGaritaEntity, ZonaGaritaResponse>().ForMember(dest => dest.IdZonaGarita, opt => opt.Ignore());
            CreateMap<ZonaGaritaRequest, ZonaGaritaEntity>();
        }
    }
}