using EventManagementProject.DTOs.EventDTO;
using EventManagementProject.Interfaces.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.DataAnnotations;

namespace EventManagementProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("MyCors")]
    public class EventController : ControllerBase
    {
        private readonly IEvent _eventService;
        private readonly ISchedulePrivateEventService _schedulePrivateEventService;
        public EventController(IEvent eventService, ISchedulePrivateEventService schedulePrivateEventService)
        {
            _eventService = eventService;
            _schedulePrivateEventService = schedulePrivateEventService;
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddEvent(AddEventDTO eventDto)
        {
            try
            {
                await _eventService.AddEvent(eventDto);
                return Ok("Event Added Successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAllEventByCategory([FromQuery] string category)
        {
            try
            {
                var events = await _eventService.GetAllEventByCategory(category);
                return Ok(events);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("getid")]
        public async Task<IActionResult> GetEventIdByName(string eventName)
        {
            try
            {
                var eventId = await _eventService.GetEventIdByName(eventName);
                return Ok(eventId);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("add/scheduled/pvt/")]
        public async Task<IActionResult> AddScheduledPrivateEvent(AddScheduledPrivateEventDTO dto)
        {
            try
            {
                await _schedulePrivateEventService.AddSchedulePrivateEvent(dto);
                return Ok("Scheduled Private Event Added Successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("get/scheduled/pvt/ByuserId")]
        public async Task<IActionResult> GetScheduledEventByUserId(int userId)
        {
            try
            {
                var scheduledEvents = await _schedulePrivateEventService.GetScheduledEventByUserId(userId);
                return Ok(scheduledEvents);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("getAll/publicEvents")]
        public async Task<IActionResult> GetAllPublicEvents()
        {
            try
            {
                var events = await _eventService.GetAllPublicEvents();
                return Ok(events);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("get/scheduled/pvt")]
        public async Task<IActionResult> GetAllScheduledPrivateEvent()
        {
            try
            {
                var scheduledEvents = await _schedulePrivateEventService.GetAllScheduledPrivateEvent();
                return Ok(scheduledEvents);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
