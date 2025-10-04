using AutoMapper;
using LiquidacionPeajesNew.Application.DTOs.Requests;
using LiquidacionPeajesNew.Application.DTOs.Responses;
using LiquidacionPeajesNew.Common.Enums;
using LiquidacionPeajesNew.Domain.Entities;
using LiquidacionPeajesNew.Domain.Interfaces;

namespace LiquidacionPeajesNew.Application.Services.GaritaService
{
    public class GaritaService : IGaritaService
    {
        private readonly IGaritaRepository _repository;
        private readonly IMapper _mapper;

        public GaritaService(IGaritaRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ApiResponse<IEnumerable<GaritaResponse>>> GetAllAsync()
        {
            var data = await _repository.GetAllAsync();
            var mapped = _mapper.Map<IEnumerable<GaritaResponse>>(data);

            return new ApiResponse<IEnumerable<GaritaResponse>>(
                status: true,
                value: mapped,
                messageCode: AppResponseCode.OperationCompletedSuccessfully
            );
        }

        public async Task<ApiResponse<GaritaResponse>> GetByIdAsync(long id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity.IdGarita == 0)
            {
                return new ApiResponse<GaritaResponse>(
                    status: false,
                    value: null,
                    messageCode: AppResponseCode.RecordNotFoundInDatabase
                );
            }

            var mapped = _mapper.Map<GaritaResponse>(entity);

            return new ApiResponse<GaritaResponse>(
                status: true,
                value: mapped,
                messageCode: AppResponseCode.OperationCompletedSuccessfully
            );
        }

        public async Task<ApiResponse<long>> AddAsync(GaritaRequest request)
        {
            var mapped = _mapper.Map<GaritaEntity>(request);

            var existe = await _repository.ExistsAsync(mapped.IdGarita, mapped.NombreGarita, mapped.RucProveedor);
            if (existe)
            {
                return new ApiResponse<long>(
                    status: false,
                    value: 0,
                    messageCode: AppResponseCode.RecordAlreadyExists
                );
            }

            await _repository.AddAsync(mapped);

            return new ApiResponse<long>(
                status: true,
                value: mapped.IdGarita,
                messageCode: AppResponseCode.OperationCompletedSuccessfully
            );
        }

        public async Task<ApiResponse<long>> UpdateAsync(GaritaRequest request)
        {
            var mapped = _mapper.Map<GaritaEntity>(request);

            var existe = await _repository.ExistsAsync(mapped.IdGarita, mapped.NombreGarita, mapped.RucProveedor);
            if (existe)
            {
                return new ApiResponse<long>(
                    status: false,
                    value: 0,
                    messageCode: AppResponseCode.RecordAlreadyExists
                );
            }

            await _repository.UpdateAsync(mapped);

            return new ApiResponse<long>(
                status: true,
                value: mapped.IdGarita,
                messageCode: AppResponseCode.OperationCompletedSuccessfully
            );
        }

        public async Task<ApiResponse<long>> DeleteAsync(long id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity.IdGarita == 0)
            {
                return new ApiResponse<long>(
                    status: false,
                    value: id,
                    messageCode: AppResponseCode.RecordNotFoundInDatabase
                );
            }

            await _repository.DeleteAsync(id);

            return new ApiResponse<long>(
                status: true,
                value: entity.IdGarita,
                messageCode: AppResponseCode.OperationCompletedSuccessfully
            );
        }
    }
}