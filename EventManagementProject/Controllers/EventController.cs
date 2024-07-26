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
        public EventController(IEvent eventService)
        {
            _eventService = eventService;
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

    }
}
