using EventManagementApi.Dtos;
using EventManagementApi.Models;

namespace EventManagementAPI.Services.Implementation
{
    public interface IAttendeeService
    {
        Task<IEnumerable<Attendee>> GetAllAttendees();
        Task<Attendee?> GetAttendeeById(int id);
        Task<Attendee> CreateAttendee(CreateAttendeeDto createAttendeeDto);
        Task<Attendee?> UpdateAttendee(int id, UpdateAttendeeDto updateAttendeeDto);
        Task<bool> DeleteAttendee(int id);
    }
}
