using EventManagementProject.DTOs.QuotationDTO.cs;

namespace EventManagementProject.Interfaces.Services
{
    public interface IPubQuotationResponseService
    {
        public Task AddPubQuotationResponse(PubQuotationResponseDTO pubQuotationResponseDTO);
        public Task<IEnumerable<ReturnPubQuotationResponseDTO>> GetPubQuotationResponseByUserId(int userId);
    }
}
