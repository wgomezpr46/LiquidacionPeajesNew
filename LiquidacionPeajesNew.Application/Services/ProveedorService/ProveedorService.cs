using AutoMapper;
using LiquidacionPeajesNew.Application.DTOs.Requests;
using LiquidacionPeajesNew.Application.DTOs.Responses;
using LiquidacionPeajesNew.Common.Enums;
using LiquidacionPeajesNew.Domain.Entities;
using LiquidacionPeajesNew.Domain.Interfaces;

namespace LiquidacionPeajesNew.Application.Services.ProveedorService
{
    public class ProveedorService : IProveedorService
    {
        private readonly IProveedorRepository _repository;
        private readonly IMapper _mapper;

        public ProveedorService(IProveedorRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ApiResponse<IEnumerable<ProveedorResponse>>> GetAllAsync()
        {
            var entities = await _repository.GetAllAsync();
            var mapped = _mapper.Map<IEnumerable<ProveedorResponse>>(entities);

            return new ApiResponse<IEnumerable<ProveedorResponse>>(
                status: true,
                value: mapped,
                messageCode: AppResponseCode.OperationCompletedSuccessfully
            );
        }

        public async Task<ApiResponse<ProveedorResponse>> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity.IdProveedorGarita == 0)
            {
                return new ApiResponse<ProveedorResponse>(
                    status: false,
                    value: null,
                    messageCode: AppResponseCode.RecordNotFoundInDatabase
                );
            }

            return new ApiResponse<ProveedorResponse>(
                status: true,
                value: _mapper.Map<ProveedorResponse>(entity),
                messageCode: AppResponseCode.OperationCompletedSuccessfully
            );
        }

        public async Task<ApiResponse<int>> AddAsync(ProveedorRequest request)
        {
            var mapped = _mapper.Map<ProveedorEntity>(request);

            var existeEntity = await _repository.GetByRUCAsync(mapped.IdProveedorGarita, mapped.Ruc);
            if (existeEntity.IdProveedorGarita > 0)
            {
                return new ApiResponse<int>(
                    status: false,
                    value: existeEntity.IdProveedorGarita,
                    messageCode: AppResponseCode.RecordAlreadyExists
                );
            }

            await _repository.AddAsync(mapped);

            return new ApiResponse<int>(
                status: true,
                value: mapped.IdProveedorGarita,
                messageCode: AppResponseCode.OperationCompletedSuccessfully
            );
        }

        public async Task<ApiResponse<int>> UpdateAsync(ProveedorRequest request)
        {
            var mapped = _mapper.Map<ProveedorEntity>(request);

            var existeEntity = await _repository.GetByRUCAsync(mapped.IdProveedorGarita, mapped.Ruc);
            if (existeEntity.IdProveedorGarita > 0)
            {
                return new ApiResponse<int>(
                    status: false,
                    value: existeEntity.IdProveedorGarita,
                    messageCode: AppResponseCode.RecordAlreadyExists
                );
            }

            await _repository.UpdateAsync(mapped);

            return new ApiResponse<int>(
                status: true,
                value: mapped.IdProveedorGarita,
                messageCode: AppResponseCode.OperationCompletedSuccessfully
            );
        }

        public async Task<ApiResponse<int>> DeleteAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity.IdProveedorGarita == 0)
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
                value: entity.IdProveedorGarita,
                messageCode: AppResponseCode.OperationCompletedSuccessfully
            );
        }
    }
}