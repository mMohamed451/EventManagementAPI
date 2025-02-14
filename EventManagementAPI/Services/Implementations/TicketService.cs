using EventManagementAPI.Dtos.Ticket;
using EventManagementAPI.Models;
using EventManagementAPI.Repositories.Interface;
using EventManagementAPI.Services.Interface;

namespace EventManagementAPI.Services.Implementations
{
    public class TicketService : ITicketService
    {
        private readonly ITicketRepository _ticketRepository;

        public TicketService(ITicketRepository ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }

        public async Task<Ticket?> GetTicketByIdAsync(int id)
        {
            var ticket = await _ticketRepository.GetByIdAsync(id);
            return ticket;
        }

        public async Task<IEnumerable<Ticket>> GetAllTicketsAsync()
        {
            var tickets = await _ticketRepository.GetAllAsync();
            return tickets;
        }

        public async Task<Ticket> CreateTicketAsync(CreateTicketDto createTicketDto)
        {
            Ticket newTicket = new()
            {
                Price = createTicketDto.Price,
                Type = createTicketDto.Type,
                EventId = createTicketDto.EventId,
            };
        
            await _ticketRepository.AddAsync(newTicket);
            return newTicket;
        }

        public async Task UpdateTicketAsync(int id, UpdateTicketDto updateTicketDto)
        {
            var ticket = await _ticketRepository.GetByIdAsync(id);
            if (ticket == null)
            {
                throw new KeyNotFoundException("Ticket not found.");
            }
            Ticket newTicket = new()
            {
                Price = updateTicketDto.Price,
                Type = updateTicketDto.Type,
                EventId = updateTicketDto.EventId,
            };

            await _ticketRepository.UpdateAsync(newTicket);
        }

        public async Task DeleteTicketAsync(int id)
        {
            if (!await _ticketRepository.ExistsAsync(id))
            {
                throw new KeyNotFoundException("Ticket not found.");
            }

            await _ticketRepository.DeleteAsync(id);
        }
    }
}
