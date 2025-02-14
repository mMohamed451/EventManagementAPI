using EventManagementAPI.Dtos.Ticket;
using EventManagementAPI.Models;

namespace EventManagementAPI.Services.Interface
{
    public interface ITicketService
    {
        Task<Ticket?> GetTicketByIdAsync(int id);
        Task<IEnumerable<Ticket>> GetAllTicketsAsync();
        Task<Ticket> CreateTicketAsync(CreateTicketDto createTicketDto);
        Task UpdateTicketAsync(int id, UpdateTicketDto updateTicketDto);
        Task DeleteTicketAsync(int id);
    }
}
