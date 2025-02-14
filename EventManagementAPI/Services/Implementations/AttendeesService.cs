

using EventManagementApi.Dtos;
using EventManagementApi.Models;
using EventManagementAPI.Repositories.Interface;

namespace EventManagementAPI.Services.Implementation
{
    public class AttendeeService : IAttendeeService
    {
        private readonly IAttendeeRepository _attendeeRepository;

        public AttendeeService(IAttendeeRepository attendeeRepository)
        {
            _attendeeRepository = attendeeRepository;
        }

        public async Task<IEnumerable<Attendee>> GetAllAttendees()
        {
            return await _attendeeRepository.GetAllAttendees();
        }

        public async Task<Attendee?> GetAttendeeById(int id)
        {
            return await _attendeeRepository.GetAttendeeById(id);
        }



        public async Task<bool> DeleteAttendee(int id)
        {
            return await _attendeeRepository.DeleteAttendee(id);
        }

        public async Task<Attendee> CreateAttendee(EventManagementApi.Dtos.UpdateAttendeeDto createAttendeeDto)
        {
            Attendee newAttendee = new()
            {
                FullName = createAttendeeDto.FullName,
                Email = createAttendeeDto.Email,
                PhoneNumber = createAttendeeDto.PhoneNumber,
            };

            throw new NotImplementedException();
        }


        public async Task<Attendee> CreateAttendee(CreateAttendeeDto createAttendeeDto)
        {
            Attendee newAttendee = new()
            {
                FullName = createAttendeeDto.FullName,
                Email = createAttendeeDto.Email,
                PhoneNumber = createAttendeeDto.PhoneNumber,
            };

            return await _attendeeRepository.CreateAttendee(newAttendee);
        }


        public async Task<Attendee?> UpdateAttendee(int id, UpdateAttendeeDto updateAttendeeDto)
        {
            var existingAttendee = await _attendeeRepository.GetAttendeeById(id);
            if (existingAttendee == null) return null;

            existingAttendee.FullName = updateAttendeeDto.FullName;
            existingAttendee.Email = updateAttendeeDto.Email;
            existingAttendee.PhoneNumber = updateAttendeeDto.PhoneNumber;

            return await _attendeeRepository.UpdateAttendee(existingAttendee);
        }

    }
}
