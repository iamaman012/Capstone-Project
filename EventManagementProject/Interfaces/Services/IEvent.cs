using EventManagementProject.DTOs.EventDTO;

namespace EventManagementProject.Interfaces.Services
{
    public interface IEvent
    {
        public Task AddEvent(AddEventDTO eventDto);
        public Task<IEnumerable<EventListDTO>> GetAllEventByCategory(string category);
    }
}
