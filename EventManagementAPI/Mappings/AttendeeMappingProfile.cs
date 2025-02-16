
using AutoMapper;
using EventManagementApi.Dtos;
using EventManagementApi.Models;

namespace EventManagementAPI.Mappings
{
    public class AttendeeMappingProfile: Profile
    {
        public AttendeeMappingProfile()
        {
            CreateMap<CreateAttendeeDto, Attendee>();
            CreateMap<UpdateAttendeeDto, Attendee>();
        }
    }
}
