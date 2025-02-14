using EventManagementApi.Data;
using EventManagementApi.Dtos;
using EventManagementApi.Models;
using EventManagementAPI.Models;
using EventManagementAPI.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace EventManagementAPI.Repositories.Implementation
{
    public class EventRepository : IEventRepository
    {
        private readonly EventContext _context;

        public EventRepository(EventContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Event>> GetAllEvents()
        {
            return await _context.Events.ToListAsync();
        }

        public async Task<Event?> GetEventById(int id)
        {
            return await _context.Events.FindAsync(id);
        }


  

        public async Task<bool> DeleteEvent(int id)
        {
            var eventToDelete = await _context.Events.FindAsync(id);
            if (eventToDelete == null) return false;

            _context.Events.Remove(eventToDelete);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Event> CreateEvent(Event createEvent)
        {
            _context.Events.Add(createEvent);
            await _context.SaveChangesAsync();
            return createEvent;
        }

        public async Task<Event?> UpdateEvent(Event updatedEvent)
        {
            _context.Events.Attach(updatedEvent); // Attach the entity if it's not being tracked
            _context.Entry(updatedEvent).State = EntityState.Modified; // Mark it as modified
            await _context.SaveChangesAsync();
            return updatedEvent;
        }

        public  EventAttendee GetEventAttendee(int eventId, int attendeeId)
        {
            // Find the EventAttendee entity using the composite key
            var eventAttendee =  _context.EventAttendees
                .FirstOrDefault(ea => ea.EventId == eventId && ea.AttendeeId == attendeeId);

            return eventAttendee;
        }

        public async Task<List<Attendee>> GetAttendeesForEvent(int eventId)
        {
            return await _context.EventAttendees
                .Where(ea => ea.EventId == eventId)
                .Select(ae => ae.Attendee)
                .ToListAsync();
        }

        public async Task<bool> AddAttendeeToEvent(EventAttendee eventAttendee)
        {
            _context.EventAttendees.Add(eventAttendee);
            await _context.SaveChangesAsync();
            return true; // TODO: check error handling or null data.
        }

        public async Task<bool> RemoveAttendeeFromEvent(EventAttendee eventAttendee)
        {
            var eventAtendeeee = this.GetEventAttendee(eventAttendee.EventId, eventAttendee.AttendeeId);
            if (eventAtendeeee == null) return false;
            _context.EventAttendees.Remove(eventAtendeeee);
                await _context.SaveChangesAsync();
            return true;// TODO: check error handling or null data.
        }
    }
}
