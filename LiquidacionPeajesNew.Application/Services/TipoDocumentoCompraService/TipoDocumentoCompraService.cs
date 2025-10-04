using AutoMapper;
using LiquidacionPeajesNew.Application.DTOs.Responses;
using LiquidacionPeajesNew.Common.Enums;
using LiquidacionPeajesNew.Domain.Interfaces;

namespace LiquidacionPeajesNew.Application.Services.TipoDocumentoCompraService
{
    public class TipoDocumentoCompraService : ITipoDocumentoCompraService
    {
        private readonly ITipoDocumentoCompraRepository _repository;
        private readonly IMapper _mapper;

        public TipoDocumentoCompraService(ITipoDocumentoCompraRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ApiResponse<IEnumerable<TipoDocumentoCompraResponse>>> GetAllAsync()
        {
            var data = await _repository.GetAllAsync();
            var mapped = _mapper.Map<IEnumerable<TipoDocumentoCompraResponse>>(data);

            return new ApiResponse<IEnumerable<TipoDocumentoCompraResponse>>(
                status: true,
                value: mapped,
                messageCode: AppResponseCode.OperationCompletedSuccessfully
            );
        }
    }
}