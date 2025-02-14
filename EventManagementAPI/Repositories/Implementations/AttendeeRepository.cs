using EventManagementApi.Data;
using EventManagementApi.Models;
using EventManagementAPI.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace EventManagementAPI.Repositories.Implementation
{
    public class AttendeeRepository : IAttendeeRepository
    {
        private readonly EventContext _context;

        public AttendeeRepository(EventContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Attendee>> GetAllAttendees()
        {
            return await _context.Attendees.ToListAsync();
        }

        public async Task<Attendee?> GetAttendeeById(int id)
        {
            return await _context.Attendees.FindAsync(id);
        }

        public async Task<Attendee> CreateAttendee(Attendee newAttendee)
        {
            _context.Attendees.Add(newAttendee);
            await _context.SaveChangesAsync();
            return newAttendee;
        }

        public async Task<Attendee?> UpdateAttendee(Attendee updatedAttendee)
        {
            _context.Attendees.Update(updatedAttendee);
            await _context.SaveChangesAsync();
            return updatedAttendee;
        }

        public async Task<bool> DeleteAttendee(int id)
        {
            var attendeeToDelete = await _context.Attendees.FindAsync(id);
            if (attendeeToDelete == null) return false;

            _context.Attendees.Remove(attendeeToDelete);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
