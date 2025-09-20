using AutoMapper;
using LiquidacionPeajesNew.Application.DTOs.Responses;
using LiquidacionPeajesNew.Common.Enums;
using LiquidacionPeajesNew.Domain.Interfaces;

namespace LiquidacionPeajesNew.Application.Services.ZonaGaritaService
{
    public class ZonaGaritaService : IZonaGaritaService
    {
        private readonly IZonaGaritaRepository _repository;
        private readonly IMapper _mapper;

        public ZonaGaritaService(IZonaGaritaRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ApiResponse<IEnumerable<ZonaGaritaResponse>>> GetAllAsync()
        {
            var data = await _repository.GetAllAsync();
            var mapped = _mapper.Map<IEnumerable<ZonaGaritaResponse>>(data);

            return new ApiResponse<IEnumerable<ZonaGaritaResponse>>(
                status: true,
                value: mapped,
                messageCode: AppResponseCode.OperationCompletedSuccessfully
            );
        }
    }
}