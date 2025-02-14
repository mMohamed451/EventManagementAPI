using EventManagementAPI.Models;

namespace EventManagementAPI.Repositories.Interface
{
    public interface ITicketRepository
    {
        Task<Ticket?> GetByIdAsync(int id);
        Task<IEnumerable<Ticket>> GetAllAsync();
        Task AddAsync(Ticket ticket);
        Task UpdateAsync(Ticket ticket);
        Task DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
    }
}
