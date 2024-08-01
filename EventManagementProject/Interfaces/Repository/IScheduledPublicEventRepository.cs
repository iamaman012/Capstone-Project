using EventManagementProject.Models;

namespace EventManagementProject.Interfaces.Repository
{
    public interface IScheduledPublicEventRepository : IRepository<int, ScheduledPublicEvent >
    {
        public Task<List<ScheduledPublicEvent>> ScheduledPublicEventsByUserId(int userId);

        public Task<List<ScheduledPublicEvent>> GetAllScheduledPublicEvents();
    }
}
