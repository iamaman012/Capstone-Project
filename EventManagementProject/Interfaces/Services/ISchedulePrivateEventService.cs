using EventManagementProject.DTOs.EventDTO;

namespace EventManagementProject.Interfaces.Services
{
    public interface ISchedulePrivateEventService
    {
        public Task AddSchedulePrivateEvent(AddScheduledPrivateEventDTO addScheduledPrivateEventDTO);
        public Task<IEnumerable<ReturnSchedulePrivateEventDTO>> GetScheduledEventByUserId(int userId);
        public Task<IEnumerable<ReturnSchedulePrivateEventDTO>> GetAllScheduledPrivateEvent();
    }
}
