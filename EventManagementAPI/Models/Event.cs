using System.ComponentModel.DataAnnotations;
using EventManagementAPI.Models;

namespace EventManagementApi.Models
{
    public class Event : BaseEntity
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required]
        public DateTime Date { get; set; }

        [MaxLength(255)]
        public string? Location { get; set; }

        public string? Description { get; set; }

        public ICollection<EventAttendee> EventAttendees { get; set; } = new List<EventAttendee>();
        public ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
    }
}
