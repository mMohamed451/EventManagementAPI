using AutoMapper;
using EventManagementAPI.Dtos.Ticket;
using EventManagementAPI.Models;

namespace EventManagementAPI.Mappings
{
    public class TicketMappingProfile: Profile
    {
        public TicketMappingProfile()
        {
            CreateMap<CreateTicketDto,Ticket > ();
            CreateMap<UpdateTicketDto, Ticket>();
        }
    }
}
