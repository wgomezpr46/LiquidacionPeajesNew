using AutoMapper;
using LiquidacionPeajesNew.Application.DTOs.Requests;
using LiquidacionPeajesNew.Application.DTOs.Responses;
using LiquidacionPeajesNew.Domain.Entities;

namespace LiquidacionPeajesNew.Application.Mappings
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserEntity, UserResponse>()
                .ForMember(dest => dest.Usr_Codigo, opt => opt.MapFrom(src => src.IdUsuario))
                .ForMember(dest => dest.Usr_Nombre, opt => opt.MapFrom(src => src.Usuario))
                .ForMember(dest => dest.Usr_Estado, opt => opt.MapFrom(src => src.Estado))
                .ReverseMap();

            CreateMap<UserEntity, UserRequest>()
                .ForMember(dest => dest.Usr_Codigo, opt => opt.MapFrom(src => src.IdUsuario))
                .ForMember(dest => dest.Usr_Nombre, opt => opt.MapFrom(src => src.Usuario))
                .ForMember(dest => dest.Usr_Estado, opt => opt.MapFrom(src => src.Estado))
                .ReverseMap();
        }
    }
}