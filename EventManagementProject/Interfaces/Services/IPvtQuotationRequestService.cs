using EventManagementProject.DTOs.QuotationDTO.cs;

namespace EventManagementProject.Interfaces.Services
{
    public interface IPvtQuotationRequestService
    {
        public Task AddPvtQuotationRequest(AddPvtQuotationRequestDTO pvtQuotationRequestDto);
        public Task<IEnumerable<ReturnPvtQuotationsDTO>> ReturnPvtQuotation();
    }
}
