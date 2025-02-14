using EventManagementAPI.Dtos.Ticket;
using EventManagementAPI.Models;
using EventManagementAPI.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace EventManagementAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class TicketController : ControllerBase
    {
     
            private readonly ITicketService _ticketService;

            public TicketController(ITicketService ticketService)
            {
                _ticketService = ticketService;
            }

            [HttpGet("{id}")]
            public async Task<ActionResult<Ticket>> GetTicket(int id)
            {
                var ticket = await _ticketService.GetTicketByIdAsync(id);
                if (ticket == null)
                {
                    return NotFound();
                }
                return Ok(ticket);
            }

            [HttpGet]
            public async Task<ActionResult<IEnumerable<Ticket>>> GetAllTickets()
            {
                var tickets = await _ticketService.GetAllTicketsAsync();
                return Ok(tickets);
            }

            [HttpPost]
            public async Task<ActionResult<Ticket>> CreateTicket(CreateTicketDto createTicketDto)
            {
                var ticket = await _ticketService.CreateTicketAsync(createTicketDto);
                return CreatedAtAction(nameof(GetTicket), new { id = ticket.Id }, ticket);
            }

            [HttpPut("{id}")]
            public async Task<IActionResult> UpdateTicket(int id, UpdateTicketDto updateTicketDto)
            {
                try
                {
                    await _ticketService.UpdateTicketAsync(id, updateTicketDto);
                    return NoContent();
                }
                catch (KeyNotFoundException)
                {
                    return NotFound();
                }
            }

            [HttpDelete("{id}")]
            public async Task<IActionResult> DeleteTicket(int id)
            {
                try
                {
                    await _ticketService.DeleteTicketAsync(id);
                    return NoContent();
                }
                catch (KeyNotFoundException)
                {
                    return NotFound();
                }
            }
    }
}
