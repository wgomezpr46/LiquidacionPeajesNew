using AutoMapper;
using LiquidacionPeajesNew.Application.DTOs.Responses;
using LiquidacionPeajesNew.Domain.Entities;

namespace LiquidacionPeajesNew.Application.Mappings
{
    internal class EstadoProfile : Profile
    {
        public EstadoProfile()
        {
            CreateMap<EstadoEntity, EstadoResponse>();
        }
    }
}