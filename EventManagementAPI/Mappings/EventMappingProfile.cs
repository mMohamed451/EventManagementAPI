using AutoMapper;
using EventManagementApi.Dtos;
using EventManagementApi.Models;

namespace EventManagementAPI.Mappings
{
    public class EventMappingProfile: Profile
    {
        public EventMappingProfile() 
        {
            CreateMap<CreateEventDto, Event>();
            CreateMap<UpdateEventDto, Event>();
        }
    }
}
