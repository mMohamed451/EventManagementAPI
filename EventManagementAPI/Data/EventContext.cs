using Microsoft.EntityFrameworkCore;
using EventManagementApi.Models;

namespace EventManagementApi.Data
{
    public class EventContext : DbContext
    {
        public EventContext(DbContextOptions<EventContext> options) : base(options) { }

        public DbSet<Event> Events { get; set; }
    }
}
