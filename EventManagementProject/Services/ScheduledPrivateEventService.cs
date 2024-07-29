using EventManagementProject.DTOs.EventDTO;
using EventManagementProject.Interfaces.Repository;
using EventManagementProject.Interfaces.Services;
using EventManagementProject.Models;

namespace EventManagementProject.Services
{
    public class ScheduledPrivateEventService : ISchedulePrivateEventService
    {   private readonly IScheduledPrivateEventRepository _scheduledPrivateEventRepository;
        private readonly IEvent _eventService;
        private readonly IEventRepository _eventRepository;
        private readonly IPvtQuotationResponseRepository _pvtQuotationResponseRepository;
        public ScheduledPrivateEventService(IScheduledPrivateEventRepository scheduledPrivateEventRepository, IEvent eventService, IPvtQuotationResponseRepository pvtQuotationResponseRepository, IEventRepository eventRepository)
        {
            _scheduledPrivateEventRepository = scheduledPrivateEventRepository;
            _eventService = eventService;
            _pvtQuotationResponseRepository = pvtQuotationResponseRepository;
            _eventRepository = eventRepository;
        }
        public async Task AddSchedulePrivateEvent(AddScheduledPrivateEventDTO addScheduledPrivateEventDTO)
        {
            try
            {
                var eventId = await _eventService.GetEventIdByName(addScheduledPrivateEventDTO.EventName);

                var scheduledPrivateEvent = new ScheduledPrivateEvent
                {
                    EventId = eventId,
                    PrivateQuotationRequestId = addScheduledPrivateEventDTO.PrivateQuotationRequestId,
                    UserId = addScheduledPrivateEventDTO.UserId
                };
                await _scheduledPrivateEventRepository.Add(scheduledPrivateEvent);
                await _pvtQuotationResponseRepository.ResponseAcceptedByUser(addScheduledPrivateEventDTO.PrivateQuotationResponseId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<ReturnSchedulePrivateEventDTO>> GetScheduledEventByUserId(int userId)
        {
            try
            {
                var scheduledEvents = await _scheduledPrivateEventRepository.GetScheduledPrivateEventByUserId(userId);

                var privateScheduledEvents = scheduledEvents.Select(scheduledEvent => new ReturnSchedulePrivateEventDTO
                {
                    ScheduledPrivateEventId = scheduledEvent.ScheduledPrivateEventId,
                    EventName =     scheduledEvent.Event.EventName,
                    QuotatedAmount = scheduledEvent.PrivateQuotationRequest.PrivateQuotationResponse.QuotedAmount,
                    EventStartDate = scheduledEvent.PrivateQuotationRequest.EventStartDate,
                    EventEndDate = scheduledEvent.PrivateQuotationRequest.EventEndDate,
                    EventTiming = scheduledEvent.PrivateQuotationRequest.EventTiming,
                    VenueType = scheduledEvent.PrivateQuotationRequest.VenueType,
                });

                

                return privateScheduledEvents;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}

