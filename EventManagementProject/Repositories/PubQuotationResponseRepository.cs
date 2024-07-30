using EventManagementProject.Context;
using EventManagementProject.Interfaces.Repository;
using EventManagementProject.Models;

namespace EventManagementProject.Repositories
{
    public class PubQuotationResponseRepository : Repository<int, PublicQuotationResponse>, IPubQuotationResponseRepository
    {
        public PubQuotationResponseRepository(EventManagementContext _context) : base(_context)
        {
        }
    }
}
