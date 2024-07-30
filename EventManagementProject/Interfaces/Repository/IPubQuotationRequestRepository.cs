using EventManagementProject.Models;

namespace EventManagementProject.Interfaces.Repository
{
    public interface IPubQuotationRequestRepository : IRepository<int,PublicQuotationRequest>
    {
        public Task UpdateQuotationStatus(int id, string status);
    }
}
