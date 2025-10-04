using AutoMapper;
using LiquidacionPeajesNew.Application.DTOs.Requests;
using LiquidacionPeajesNew.Application.DTOs.Responses;
using LiquidacionPeajesNew.Common.Enums;
using LiquidacionPeajesNew.Domain.Entities;
using LiquidacionPeajesNew.Domain.Interfaces;

namespace LiquidacionPeajesNew.Application.Services.ModoPagoGaritaService
{
    public class ModoPagoGaritaService : IModoPagoGaritaService
    {
        private readonly IModoPagoGaritaRepository _repository;
        private readonly IMapper _mapper;

        public ModoPagoGaritaService(IModoPagoGaritaRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ApiResponse<IEnumerable<ModoPagoGaritaResponse>>> GetAllAsync()
        {
            var data = await _repository.GetAllAsync();
            var mapped = _mapper.Map<IEnumerable<ModoPagoGaritaResponse>>(data);

            return new ApiResponse<IEnumerable<ModoPagoGaritaResponse>>(
                status: true,
                value: mapped,
                messageCode: AppResponseCode.OperationCompletedSuccessfully
            );
        }

        public async Task<ApiResponse<ModoPagoGaritaResponse>> GetByIdAsync(short id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity.IdModoPagoGarita == 0)
            {
                return new ApiResponse<ModoPagoGaritaResponse>(
                    status: false,
                    value: null,
                    messageCode: AppResponseCode.RecordNotFoundInDatabase
                );
            }

            var mapped = _mapper.Map<ModoPagoGaritaResponse>(entity);

            return new ApiResponse<ModoPagoGaritaResponse>(
                status: true,
                value: mapped,
                messageCode: AppResponseCode.OperationCompletedSuccessfully
            );
        }

        public async Task<ApiResponse<int>> AddAsync(ModoPagoGaritaRequest request)
        {
            var mapped = _mapper.Map<ModoPagoGaritaEntity>(request);

            var existe = await _repository.ExistsAsync(mapped.IdModoPagoGarita, mapped.ModoPagoGarita);
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
                value: mapped.IdModoPagoGarita,
                messageCode: AppResponseCode.OperationCompletedSuccessfully
            );
        }

        public async Task<ApiResponse<int>> UpdateAsync(ModoPagoGaritaRequest request)
        {
            var mapped = _mapper.Map<ModoPagoGaritaEntity>(request);

            var existe = await _repository.ExistsAsync(mapped.IdModoPagoGarita, mapped.ModoPagoGarita);
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
                value: mapped.IdModoPagoGarita,
                messageCode: AppResponseCode.OperationCompletedSuccessfully
            );
        }

        public async Task<ApiResponse<int>> DeleteAsync(short id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity.IdModoPagoGarita == 0)
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
                value: entity.IdModoPagoGarita,
                messageCode: AppResponseCode.OperationCompletedSuccessfully
            );
        }
    }
}