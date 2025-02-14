using EventManagementApi.Models;
using Microsoft.EntityFrameworkCore;

namespace EventManagementAPI.Repositories.Interface
{
    public interface IAttendeeRepository
    {
        Task<IEnumerable<Attendee>> GetAllAttendees();
        Task<Attendee?> GetAttendeeById(int id);
        Task<Attendee> CreateAttendee(Attendee newAttendee);
        Task<Attendee?> UpdateAttendee(Attendee updatedAttendee);
        Task<bool> DeleteAttendee(int id);
    }
}
