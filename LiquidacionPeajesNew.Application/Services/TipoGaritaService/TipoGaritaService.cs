using AutoMapper;
using LiquidacionPeajesNew.Application.DTOs.Requests;
using LiquidacionPeajesNew.Application.DTOs.Responses;
using LiquidacionPeajesNew.Common.Enums;
using LiquidacionPeajesNew.Domain.Entities;
using LiquidacionPeajesNew.Domain.Interfaces;

namespace LiquidacionPeajesNew.Application.Services.TipoGaritaService
{
    public class TipoGaritaService : ITipoGaritaService
    {
        private readonly ITipoGaritaRepository _repository;
        private readonly IMapper _mapper;

        public TipoGaritaService(ITipoGaritaRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ApiResponse<IEnumerable<TipoGaritaResponse>>> GetAllAsync()
        {
            var data = await _repository.GetAllAsync();
            var mapped = _mapper.Map<IEnumerable<TipoGaritaResponse>>(data);

            return new ApiResponse<IEnumerable<TipoGaritaResponse>>(
                status: true,
                value: mapped,
                messageCode: AppResponseCode.OperationCompletedSuccessfully
            );
        }

        public async Task<ApiResponse<TipoGaritaResponse>> GetByIdAsync(short id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity.IdTipoGarita == 0)
            {
                return new ApiResponse<TipoGaritaResponse>(
                    status: false,
                    value: null,
                    messageCode: AppResponseCode.RecordNotFoundInDatabase
                );
            }

            var mapped = _mapper.Map<TipoGaritaResponse>(entity);

            return new ApiResponse<TipoGaritaResponse>(
                status: true,
                value: mapped,
                messageCode: AppResponseCode.OperationCompletedSuccessfully
            );
        }

        public async Task<ApiResponse<int>> AddAsync(TipoGaritaRequest request)
        {
            var mapped = _mapper.Map<TipoGaritaEntity>(request);

            var existe = await _repository.ExistsAsync(mapped.IdTipoGarita, mapped.TipoGarita);
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
                value: mapped.IdTipoGarita,
                messageCode: AppResponseCode.OperationCompletedSuccessfully
            );
        }

        public async Task<ApiResponse<int>> UpdateAsync(TipoGaritaRequest request)
        {
            var mapped = _mapper.Map<TipoGaritaEntity>(request);

            var existe = await _repository.ExistsAsync(mapped.IdTipoGarita, mapped.TipoGarita);
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
                value: mapped.IdTipoGarita,
                messageCode: AppResponseCode.OperationCompletedSuccessfully
            );
        }

        public async Task<ApiResponse<int>> DeleteAsync(short id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity.IdTipoGarita == 0)
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
                value: entity.IdTipoGarita,
                messageCode: AppResponseCode.OperationCompletedSuccessfully
            );
        }
    }
}