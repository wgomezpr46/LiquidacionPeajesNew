using AutoMapper;
using LiquidacionPeajesNew.Application.DTOs.Responses;
using LiquidacionPeajesNew.Common.Enums;
using LiquidacionPeajesNew.Domain.Interfaces;

namespace LiquidacionPeajesNew.Application.Services.OficinaService
{
    public class OficinaService : IOficinaService
    {
        private readonly IOficinaRepository _repository;
        private readonly IMapper _mapper;

        public OficinaService(IOficinaRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ApiResponse<ICollection<OficinaResponse>>> GetAllAsync(string OfiCodigo)
        {
            var data = await _repository.GetAllAsync(OfiCodigo);
            var mapped = _mapper.Map<ICollection<OficinaResponse>>(data);

            return new ApiResponse<ICollection<OficinaResponse>>(
                status: true,
                value: mapped,
                messageCode: AppResponseCode.OperationCompletedSuccessfully
            );
        }
    }
}