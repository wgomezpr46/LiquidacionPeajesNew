using AutoMapper;
using LiquidacionPeajesNew.Application.DTOs.Requests;
using LiquidacionPeajesNew.Application.DTOs.Responses;
using LiquidacionPeajesNew.Common.Enums;
using LiquidacionPeajesNew.Domain.Entities;
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

        public async Task<ApiResponse<ZonaGaritaResponse>> GetByIdAsync(byte id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity.IdZonaGarita == 0)
            {
                return new ApiResponse<ZonaGaritaResponse>(
                    status: false,
                    value: null,
                    messageCode: AppResponseCode.RecordNotFoundInDatabase
                );
            }

            var mapped = _mapper.Map<ZonaGaritaResponse>(entity);

            return new ApiResponse<ZonaGaritaResponse>(
                status: true,
                value: mapped,
                messageCode: AppResponseCode.OperationCompletedSuccessfully
            );
        }

        public async Task<ApiResponse<int>> AddAsync(ZonaGaritaRequest request)
        {
            var mapped = _mapper.Map<ZonaGaritaEntity>(request);

            var existeEntity = await _repository.GetByNameAsync(mapped.IdZonaGarita, mapped.ZonaGarita);
            if (existeEntity.IdZonaGarita > 0)
            {
                return new ApiResponse<int>(
                    status: false,
                    value: existeEntity.IdZonaGarita,
                    messageCode: AppResponseCode.RecordAlreadyExists
                );
            }

            await _repository.AddAsync(mapped);

            return new ApiResponse<int>(
                status: true,
                value: mapped.IdZonaGarita,
                messageCode: AppResponseCode.OperationCompletedSuccessfully
            );
        }

        public async Task<ApiResponse<int>> UpdateAsync(ZonaGaritaRequest request)
        {
            var mapped = _mapper.Map<ZonaGaritaEntity>(request);

            var existeEntity = await _repository.GetByNameAsync(mapped.IdZonaGarita, mapped.ZonaGarita);
            if (existeEntity.IdZonaGarita > 0)
            {
                return new ApiResponse<int>(
                    status: false,
                    value: existeEntity.IdZonaGarita,
                    messageCode: AppResponseCode.RecordAlreadyExists
                );
            }

            await _repository.UpdateAsync(mapped);

            return new ApiResponse<int>(
                status: true,
                value: mapped.IdZonaGarita,
                messageCode: AppResponseCode.OperationCompletedSuccessfully
            );
        }

        public async Task<ApiResponse<int>> DeleteAsync(byte id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity.IdZonaGarita == 0)
            {
                return new ApiResponse<int>(
                    status: false,
                    value: id,
                    messageCode: AppResponseCode.RecordNotFoundInDatabase
                );
            }

            await _repository.DeleteAsync(id);

            return new ApiResponse<int>(
                status: true,
                value: entity.IdZonaGarita,
                messageCode: AppResponseCode.OperationCompletedSuccessfully
            );
        }
    }
}