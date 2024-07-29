using EventManagementProject.DTOs.QuotationDTO.cs;

namespace EventManagementProject.Interfaces.Services
{
    public interface IPvtQuotationResponseService
    {
        public Task AddQuotationResponse(PvtQuotationResponseDTO pvtQuotationResponseDTO);
        public Task<IEnumerable<ReturnPvtQuotationResponseDTO>> GetQuotationResponseByuserId(int userId);
    }
}
