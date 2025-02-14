using EventManagementApi.Dtos;
using EventManagementApi.Models;
using EventManagementAPI.Services.Implementation;
using Microsoft.AspNetCore.Mvc;

namespace EventManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IEventService _eventService;

        public EventController(IEventService eventService)
        {
            _eventService = eventService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEvents()
        {
            var events = await _eventService.GetAllEvents();
            return Ok(events);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEventById(int id)
        {
            var eventItem = await _eventService.GetEventById(id);
            if (eventItem == null) return NotFound();
            return Ok(eventItem);
        }

        [HttpPost]
        public async Task<IActionResult> CreateEvent(CreateEventDto eventModel)
        {
            var createdEvent = await _eventService.CreateEvent(eventModel);
            return CreatedAtAction(nameof(GetEventById), new { id = createdEvent.Id }, createdEvent);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEvent(int id, UpdateEventDto eventModel)
        {
            var updatedEvent = await _eventService.UpdateEvent(id, eventModel);
            if (updatedEvent == null) return NotFound();
            return Ok(updatedEvent);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEvent(int id)
        {
            var isDeleted = await _eventService.DeleteEvent(id);
            if (!isDeleted) return NotFound();
            return Ok();
        }


        // GET: api/events/5/attendees
        [HttpGet("{eventId}/Attendees")]
        public async Task<ActionResult<IEnumerable<Attendee>>> GetAttendeesForEvent(int eventId)
        {
            var attendees = await _eventService.GetAttendeesForEvent(eventId);
            return Ok(attendees);
        }

        // POST: api/events/5/attendees
        [HttpPost("{eventId}/Attendees")]
        public async Task<IActionResult> AddAttendeeToEvent(int eventId, int attendeeId)
        {
            await _eventService.AddAttendeeToEvent(eventId, attendeeId);
            return NoContent();
        }

        // DELETE: api/events/5/attendees/3
        [HttpDelete("{eventId}/Attendees/{attendeeId}")]
        public async Task<IActionResult> RemoveAttendeeFromEvent(int eventId, int attendeeId)
        {
            await _eventService.RemoveAttendeeFromEvent(eventId, attendeeId);
            return NoContent();
        }
    }
}
