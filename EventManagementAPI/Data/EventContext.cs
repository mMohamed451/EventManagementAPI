using Microsoft.EntityFrameworkCore;
using EventManagementApi.Models;
using EventManagementAPI.Models;

namespace EventManagementApi.Data
{
    public class EventContext : DbContext
    {
        public EventContext(DbContextOptions<EventContext> options) : base(options) { }

        public DbSet<Event> Events { get; set; }
        public DbSet<Attendee> Attendees { get; set; }
        public DbSet<EventAttendee> EventAttendees { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<EventAttendee>()
            //    .HasKey(ea => new { ea.EventId, ea.AttendeeId });

            //modelBuilder.Entity<EventAttendee>()
            //    .HasOne(ea => ea.Event) 
            //    .WithMany(e => e.EventAttendees) 
            //    .HasForeignKey(ea => ea.EventId); 

         
            //modelBuilder.Entity<EventAttendee>()
            //    .HasOne(ea => ea.Attendee) 
            //    .WithMany(a => a.EventAttendees)
            //    .HasForeignKey(ea => ea.AttendeeId);
        }
    }
}
