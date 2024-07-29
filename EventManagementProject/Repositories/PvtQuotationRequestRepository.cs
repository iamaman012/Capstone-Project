using EventManagementProject.Context;
using EventManagementProject.Interfaces.Repository;
using EventManagementProject.Models;

namespace EventManagementProject.Repositories
{
    public class PvtQuotationRequestRepository:Repository<int, PrivateQuotationRequest>, IPvtQuotationRequestRepository
    {
        public PvtQuotationRequestRepository(EventManagementContext context) : base(context)
        {
        }

        public async Task UpdateQuotationStatus(int id, string status)
        {
            try
            {
                var quotation = _context.PrivateQuotationRequests.Find(id);
                quotation.QuotationStatus = status;
                _context.Update(quotation);
                await _context.SaveChangesAsync();

            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);    
            }
        }
    }
}
