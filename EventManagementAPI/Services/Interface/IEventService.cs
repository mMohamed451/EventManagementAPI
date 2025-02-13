using EventManagementApi.Dtos;
using EventManagementApi.Models;

namespace EventManagementAPI.Services.Implementation
{
    public interface IEventService
    {
        Task<IEnumerable<Event>> GetAllEvents();
        Task<Event?> GetEventById(int id);
        Task<Event> CreateEvent(CreateEventDto createEventDto);
        Task<Event?> UpdateEvent(int id, UpdateEventDto updateEventDto);
        Task<bool> DeleteEvent(int id);
    }
}
