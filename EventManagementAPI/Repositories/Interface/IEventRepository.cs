using EventManagementApi.Models;
using EventManagementAPI.Models;

namespace EventManagementAPI.Repositories.Interface
{
    public interface IEventRepository
    {
        Task<IEnumerable<Event>> GetAllEvents();
        Task<Event?> GetEventById(int id);
        Task<Event> CreateEvent(Event newEvent);
        Task<Event?> UpdateEvent(Event updatedEvent);
        Task<bool> DeleteEvent(int id);
        Task<List<Attendee>> GetAttendeesForEvent(int eventId);
        Task<bool> AddAttendeeToEvent(EventAttendee eventAttendee);
        Task<bool> RemoveAttendeeFromEvent(EventAttendee eventAttendee);
    }
}
