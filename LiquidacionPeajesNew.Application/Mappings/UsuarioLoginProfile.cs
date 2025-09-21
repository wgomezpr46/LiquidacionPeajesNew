using AutoMapper;
using LiquidacionPeajesNew.Application.DTOs.Requests;
using LiquidacionPeajesNew.Application.DTOs.Responses;
using LiquidacionPeajesNew.Domain.Entities;

namespace LiquidacionPeajesNew.Application.Mappings
{
    public class UsuarioLoginProfile : Profile
    {
        public UsuarioLoginProfile()
        {
            CreateMap<UsuarioLoginEntity, UsuarioLoginResponse>().ReverseMap();
            CreateMap<UsuarioLoginRequest, UsuarioLoginEntity>().ReverseMap();
        }
    }
}