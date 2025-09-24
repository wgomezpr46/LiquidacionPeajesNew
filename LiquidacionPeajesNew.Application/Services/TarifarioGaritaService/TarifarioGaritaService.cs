using AutoMapper;
using LiquidacionPeajesNew.Application.DTOs.Requests;
using LiquidacionPeajesNew.Application.DTOs.Responses;
using LiquidacionPeajesNew.Common.Enums;
using LiquidacionPeajesNew.Domain.Entities;
using LiquidacionPeajesNew.Domain.Interfaces;

namespace LiquidacionPeajesNew.Application.Services.TarifarioGaritaService
{
    internal class TarifarioGaritaService : ITarifarioGaritaService
    {
        private readonly ITarifarioGaritaRepository _repository;
        private readonly IMapper _mapper;

        public TarifarioGaritaService(ITarifarioGaritaRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ApiResponse<IEnumerable<TarifarioGaritaResponse>>> GetAllAsync()
        {
            var data = await _repository.GetAllAsync();
            var mapped = _mapper.Map<IEnumerable<TarifarioGaritaResponse>>(data);

            return new ApiResponse<IEnumerable<TarifarioGaritaResponse>>(
                status: true,
                value: mapped,
                messageCode: AppResponseCode.OperationCompletedSuccessfully
            );
        }

        public async Task<ApiResponse<TarifarioGaritaResponse>> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity.IdTarifarioGarita == 0)
            {
                return new ApiResponse<TarifarioGaritaResponse>(
                    status: false,
                    value: null,
                    messageCode: AppResponseCode.RecordNotFoundInDatabase
                );
            }

            var mapped = _mapper.Map<TarifarioGaritaResponse>(entity);

            return new ApiResponse<TarifarioGaritaResponse>(
                status: true,
                value: mapped,
                messageCode: AppResponseCode.OperationCompletedSuccessfully
            );
        }

        public async Task<ApiResponse<int>> AddAsync(TarifarioGaritaRequest request)
        {
            var mapped = _mapper.Map<TarifarioGaritaEntity>(request);

            var existe = await _repository.ExistsAsync(mapped.IdTarifarioGarita, mapped.IdGarita, mapped.EjeVehiculo);
            if (existe)
            {
                return new ApiResponse<int>(
                    status: false,
                    value: 0,
                    messageCode: AppResponseCode.RecordAlreadyExists
                );
            }

            await _repository.AddAsync(mapped);

            return new ApiResponse<int>(
                status: true,
                value: mapped.IdTarifarioGarita,
                messageCode: AppResponseCode.OperationCompletedSuccessfully
            );
        }

        public async Task<ApiResponse<int>> UpdateAsync(TarifarioGaritaRequest request)
        {
            var mapped = _mapper.Map<TarifarioGaritaEntity>(request);

            var existe = await _repository.ExistsAsync(mapped.IdTarifarioGarita, mapped.IdGarita, mapped.EjeVehiculo);
            if (existe)
            {
                return new ApiResponse<int>(
                    status: false,
                    value: 0,
                    messageCode: AppResponseCode.RecordAlreadyExists
                );
            }

            await _repository.UpdateAsync(mapped);

            return new ApiResponse<int>(
                status: true,
                value: mapped.IdTarifarioGarita,
                messageCode: AppResponseCode.OperationCompletedSuccessfully
            );
        }

        public async Task<ApiResponse<int>> DeleteAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity.IdTarifarioGarita == 0)
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
                value: entity.IdTarifarioGarita,
                messageCode: AppResponseCode.OperationCompletedSuccessfully
            );
        }
    }
}