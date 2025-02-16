using AutoMapper;
using EventManagementApi.Dtos;
using EventManagementApi.Models;
using EventManagementAPI.Models;
using EventManagementAPI.Repositories.Interface;

namespace EventManagementAPI.Services.Implementation
{
    public class EventService : IEventService
    {
        private readonly IEventRepository _eventRepository;
        private readonly IMapper _mapper;
        public EventService(IEventRepository eventRepository, IMapper mapper)
        {
            _eventRepository = eventRepository;
            _mapper = mapper;
        }


        public async Task<IEnumerable<Event>> GetAllEvents()
        {
            return await _eventRepository.GetAllEvents();
        }

        public async Task<Event?> GetEventById(int id)
        {
            return await _eventRepository.GetEventById(id);
        }

        public async Task<Event> CreateEvent(CreateEventDto createEventDto)
        {
        
            var newEvent = _mapper.Map<Event>(createEventDto);
            var createdEvent = await _eventRepository.CreateEvent(newEvent);

            return createdEvent;
        }

        public async Task<Event?> UpdateEvent(int id, UpdateEventDto updateEventDto)
        {
            var existingEvent = await _eventRepository.GetEventById(id);
            if (existingEvent == null) return null;

            // Update existing entity properties
            existingEvent.Name = updateEventDto.Name;
            existingEvent.Date = updateEventDto.Date;
            existingEvent.Location = updateEventDto.Location;
            existingEvent.Description = updateEventDto.Description;

            return await _eventRepository.UpdateEvent(existingEvent);
        }

        public async Task<bool> DeleteEvent(int id)
        {
            return await _eventRepository.DeleteEvent(id);
        }

        public async Task<List<Attendee>> GetAttendeesForEvent(int eventId)
        {
            return await _eventRepository.GetAttendeesForEvent(eventId);
        }

        public async Task<bool> AddAttendeeToEvent(int eventId, int attendeeId)
        {
            EventAttendee eventAttendee = new()
            {
                EventId = eventId,
                AttendeeId = attendeeId
            };

            var isAdded = await _eventRepository.AddAttendeeToEvent(eventAttendee);
            return isAdded;
        }

        public async Task<bool> RemoveAttendeeFromEvent(int eventId, int attendeeId)
        {
            EventAttendee eventAttendee = new()
            {
                EventId = eventId,
                AttendeeId = attendeeId
            };

            return await _eventRepository.RemoveAttendeeFromEvent(eventAttendee);
        }
    }
}
