

using AutoMapper;
using EventManagementApi.Dtos;
using EventManagementApi.Models;
using EventManagementAPI.Repositories.Interface;

namespace EventManagementAPI.Services.Implementation
{
    public class AttendeeService : IAttendeeService
    {
        private readonly IAttendeeRepository _attendeeRepository;
        private readonly IMapper _mapper;

        public AttendeeService(IAttendeeRepository attendeeRepository, IMapper mapper)
        {
            _attendeeRepository = attendeeRepository;
            _mapper = mapper;
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

        public async Task<Attendee> CreateAttendee(CreateAttendeeDto createAttendeeDto)
        {
            var newAttendee = _mapper.Map<Attendee>(createAttendeeDto);
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
