using EventManagementApi.Data;
using EventManagementAPI.Models;
using EventManagementAPI.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace EventManagementAPI.Repositories.Implementations
{
    public class TicketRepository : ITicketRepository
    {
        private readonly EventContext _context;

        public TicketRepository(EventContext context)
        {
            _context = context;
        }

        public async Task<Ticket?> GetByIdAsync(int id)
        {
            return await _context.Tickets.FindAsync(id);
        }

        public async Task<IEnumerable<Ticket>> GetAllAsync()
        {
            return await _context.Tickets.ToListAsync();
        }

        public async Task AddAsync(Ticket ticket)
        {
            await _context.Tickets.AddAsync(ticket);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Ticket ticket)
        {
            _context.Tickets.Update(ticket);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var ticket = await _context.Tickets.FindAsync(id);
            if (ticket != null)
            {
                _context.Tickets.Remove(ticket);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Tickets.AnyAsync(t => t.Id == id);
        }
    }
}
