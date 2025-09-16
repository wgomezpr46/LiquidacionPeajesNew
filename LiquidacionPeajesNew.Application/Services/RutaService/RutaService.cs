using AutoMapper;
using LiquidacionPeajesNew.Application.DTOs.Requests;
using LiquidacionPeajesNew.Application.DTOs.Responses;
using LiquidacionPeajesNew.Common.Enums;
using LiquidacionPeajesNew.Domain.Entities;
using LiquidacionPeajesNew.Domain.Interfaces;

namespace LiquidacionPeajesNew.Application.Services.RutaService
{
    public class RutaService : IRutaService
    {
        private readonly IRutaRepository _repository;
        private readonly IMapper _mapper;

        public RutaService(IRutaRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ApiResponse<IEnumerable<RutaResponse>>> GetAllAsync()
        {
            var rutas = await _repository.GetAllAsync();
            var mapped = _mapper.Map<IEnumerable<RutaResponse>>(rutas);

            return new ApiResponse<IEnumerable<RutaResponse>>(
                status: true,
                value: mapped,
                messageCode: AppResponseCode.OperationCompletedSuccessfully
            );
        }

        public async Task<ApiResponse<RutaResponse>> GetByIdAsync(int id)
        {
            var ruta = await _repository.GetByIdAsync(id);
            if (ruta == null)
            {
                return new ApiResponse<RutaResponse>(
                    status: false,
                    value: null,
                    messageCode: AppResponseCode.OperationCompletedSuccessfully
                );
            }

            return new ApiResponse<RutaResponse>(
                status: true,
                value: _mapper.Map<RutaResponse>(ruta),
                messageCode: AppResponseCode.OperationCompletedSuccessfully
            );
        }

        public async Task<ApiResponse<int>> AddAsync(RutaRequest request)
        {
            var ruta = _mapper.Map<RutaEntity>(request);
            await _repository.AddAsync(ruta);

            return new ApiResponse<int>(
                status: true,
                value: ruta.IdRuta,
                messageCode: AppResponseCode.OperationCompletedSuccessfully
            );
        }

        public async Task<ApiResponse<int>> UpdateAsync(RutaRequest request)
        {
            var ruta = await _repository.GetByIdAsync(request.IdRuta);
            if (ruta == null)
            {
                return new ApiResponse<int>(
                    status: false,
                value: ruta.IdRuta,
                    messageCode: AppResponseCode.RecordNotFoundInDatabase
                );
            }

            _mapper.Map(request, ruta);
            await _repository.UpdateAsync(ruta);

            return new ApiResponse<int>(
                status: true,
                value: ruta.IdRuta,
                messageCode: AppResponseCode.OperationCompletedSuccessfully
            );
        }

        public async Task<ApiResponse<int>> DeleteAsync(int id)
        {
            var ruta = await _repository.GetByIdAsync(id);
            if (ruta == null)
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
                value: ruta.IdRuta,
                messageCode: AppResponseCode.OperationCompletedSuccessfully
            );
        }
    }
}