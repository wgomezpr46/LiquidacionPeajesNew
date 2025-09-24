using AutoMapper;
using LiquidacionPeajesNew.Application.DTOs.Requests;
using LiquidacionPeajesNew.Application.DTOs.Responses;
using LiquidacionPeajesNew.Domain.Entities;

namespace LiquidacionPeajesNew.Application.Mappings
{
    internal class TarifarioGaritaProfile : Profile
    {
        public TarifarioGaritaProfile()
        {
            CreateMap<TarifarioGaritaEntity, TarifarioGaritaResponse>().ForMember(dest => dest.NombreGarita, opt => opt.MapFrom(src => src.GaritaEntity.NombreGarita));
            CreateMap<TarifarioGaritaRequest, TarifarioGaritaEntity>();
        }
    }
}