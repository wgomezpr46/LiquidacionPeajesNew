using AutoMapper;
using LiquidacionPeajesNew.Application.DTOs.Responses;
using LiquidacionPeajesNew.Common.Enums;
using LiquidacionPeajesNew.Domain.Interfaces;

namespace LiquidacionPeajesNew.Application.Services.EstadoService
{
    public class EstadoService : IEstadoService
    {
        private readonly IEstadoRepository _repository;
        private readonly IMapper _mapper;

        public EstadoService(IEstadoRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ApiResponse<ICollection<EstadoResponse>>> GetAllAsync()
        {
            var data = await _repository.GetAllAsync();
            var mapped = _mapper.Map<ICollection<EstadoResponse>>(data);

            return new ApiResponse<ICollection<EstadoResponse>>(
                status: true,
                value: mapped,
                messageCode: AppResponseCode.OperationCompletedSuccessfully
            );
        }
    }
}