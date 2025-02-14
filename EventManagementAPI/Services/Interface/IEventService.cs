using EventManagementApi.Dtos;
using EventManagementApi.Models;
using EventManagementAPI.Models;

namespace EventManagementAPI.Services.Implementation
{
    public interface IEventService
    {
        Task<IEnumerable<Event>> GetAllEvents();
        Task<Event?> GetEventById(int id);
        Task<Event> CreateEvent(CreateEventDto createEventDto);
        Task<Event?> UpdateEvent(int id, UpdateEventDto updateEventDto);
        Task<bool> DeleteEvent(int id);
        Task<List<Attendee>> GetAttendeesForEvent(int eventId);
        Task<bool> AddAttendeeToEvent(int eventId, int attendeeId);
        Task<bool> RemoveAttendeeFromEvent(int eventId, int attendeeId);
    }
}
