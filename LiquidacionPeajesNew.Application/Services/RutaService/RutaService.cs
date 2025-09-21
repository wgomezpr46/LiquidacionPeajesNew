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
        private readonly IRutaRepository _rutaRepository;
        private readonly IOficinaRepository _oficinaRepository;
        private readonly IMapper _mapper;

        public RutaService(IRutaRepository rutaRepository, IOficinaRepository oficinaRepository, IMapper mapper)
        {
            _rutaRepository = rutaRepository;
            _oficinaRepository = oficinaRepository;
            _mapper = mapper;
        }

        public async Task<ApiResponse<IEnumerable<RutaResponse>>> GetAllAsync()
        {
            var rutas = await _rutaRepository.GetAllAsync();
            var oficinas = await _oficinaRepository.GetAllAsync(string.Empty);

            var mapped = _mapper.Map<IEnumerable<RutaResponse>>(rutas);
            foreach (var item in mapped)
            {
                item.NombreOrigen = oficinas.FirstOrDefault(x => x.Ofi_Codigo == item.IdOrigen)?.Ofi_Nombre ?? string.Empty;
                item.NombreDestino = oficinas.FirstOrDefault(x => x.Ofi_Codigo == item.IdDestino)?.Ofi_Nombre ?? string.Empty;
            }

            return new ApiResponse<IEnumerable<RutaResponse>>(
                status: true,
                value: mapped,
                messageCode: AppResponseCode.OperationCompletedSuccessfully
            );
        }

        public async Task<ApiResponse<RutaResponse>> GetByIdAsync(int id)
        {
            var entity = await _rutaRepository.GetByIdAsync(id);
            var oficinas = await _oficinaRepository.GetAllAsync(string.Empty);

            if (entity.IdRuta == 0)
            {
                return new ApiResponse<RutaResponse>(
                    status: false,
                    value: null,
                    messageCode: AppResponseCode.RecordNotFoundInDatabase
                );
            }

            var mapped = _mapper.Map<RutaResponse>(entity);
            mapped.NombreOrigen = oficinas.FirstOrDefault(x => x.Ofi_Codigo == mapped.IdOrigen)?.Ofi_Nombre ?? string.Empty;
            mapped.NombreDestino = oficinas.FirstOrDefault(x => x.Ofi_Codigo == mapped.IdDestino)?.Ofi_Nombre ?? string.Empty;

            return new ApiResponse<RutaResponse>(
                status: true,
                value: mapped,
                messageCode: AppResponseCode.OperationCompletedSuccessfully
            );
        }

        public async Task<ApiResponse<int>> AddAsync(RutaRequest request)
        {
            var mapped = _mapper.Map<RutaEntity>(request);

            var existeEntity = await _rutaRepository.GetByOrigenDestinoAsync(mapped.IdRuta, mapped.IdOrigen, mapped.IdDestino);
            if (existeEntity.IdRuta > 0)
            {
                return new ApiResponse<int>(
                    status: false,
                    value: existeEntity.IdRuta,
                    messageCode: AppResponseCode.RecordAlreadyExists
                );
            }

            await _rutaRepository.AddAsync(mapped);

            return new ApiResponse<int>(
                status: true,
                value: mapped.IdRuta,
                messageCode: AppResponseCode.OperationCompletedSuccessfully
            );
        }

        public async Task<ApiResponse<int>> UpdateAsync(RutaRequest request)
        {
            var mapped = _mapper.Map<RutaEntity>(request);

            var existeEntity = await _rutaRepository.GetByOrigenDestinoAsync(mapped.IdRuta, mapped.IdOrigen, mapped.IdDestino);
            if (existeEntity.IdRuta > 0)
            {
                return new ApiResponse<int>(
                    status: false,
                    value: existeEntity.IdRuta,
                    messageCode: AppResponseCode.RecordAlreadyExists
                );
            }

            await _rutaRepository.UpdateAsync(mapped);

            return new ApiResponse<int>(
                status: true,
                value: mapped.IdRuta,
                messageCode: AppResponseCode.OperationCompletedSuccessfully
            );
        }

        public async Task<ApiResponse<int>> DeleteAsync(int id)
        {
            var entity = await _rutaRepository.GetByIdAsync(id);
            if (entity.IdRuta == 0)
            {
                return new ApiResponse<int>(
                    status: false,
                    value: id,
                    messageCode: AppResponseCode.RecordNotFoundInDatabase
                );
            }

            await _rutaRepository.DeleteAsync(id);

            return new ApiResponse<int>(
                status: true,
                value: entity.IdRuta,
                messageCode: AppResponseCode.OperationCompletedSuccessfully
            );
        }
    }
}