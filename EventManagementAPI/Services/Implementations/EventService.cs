﻿using EventManagementApi.Dtos;
using EventManagementApi.Models;
using EventManagementAPI.Models;
using EventManagementAPI.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace EventManagementAPI.Services.Implementation
{
    public class EventService : IEventService
    {
        private readonly IEventRepository _eventRepository;

        public EventService(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
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
            var newEvent = new Event
            {
                Name = createEventDto.Name,
                Date = createEventDto.Date,
                Location = createEventDto.Location,
                Description = createEventDto.Description,
            };

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
