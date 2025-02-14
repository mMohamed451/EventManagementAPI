using EventManagementApi.Dtos;
using EventManagementAPI.Services.Implementation;
using Microsoft.AspNetCore.Mvc;

namespace EventManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttendeeController : ControllerBase
    {
        private readonly IAttendeeService _attendeeService;

        public AttendeeController(IAttendeeService attendeeService)
        {
            _attendeeService = attendeeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var attendees = await _attendeeService.GetAllAttendees();
            return Ok(attendees);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var attendee = await _attendeeService.GetAttendeeById(id);
            if (attendee == null)
                return NotFound();
            return Ok(attendee);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateAttendeeDto createAttendeeDto)
        {
            var newAttendee = await _attendeeService.CreateAttendee(createAttendeeDto);
            return CreatedAtAction(nameof(GetById), new { id = newAttendee.Id }, newAttendee);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateAttendeeDto updateAttendeeDto)
        {
            var updatedAttendee = await _attendeeService.UpdateAttendee(id, updateAttendeeDto);
            if (updatedAttendee == null)
                return NotFound();
            return Ok(updatedAttendee);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _attendeeService.DeleteAttendee(id);
            if (!deleted)
                return NotFound();
            return Ok();
        }
    }
}
