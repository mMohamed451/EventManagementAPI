using System;
using System.ComponentModel.DataAnnotations;
using EventManagementAPI.Models;

namespace EventManagementApi.Models
{
    public class Attendee : BaseEntity
    {
        [Required]
        [MaxLength(100)]
        public string FullName { get; set; } = string.Empty;

        [Required]
        [MaxLength(255)]
        public string Email { get; set; } = string.Empty;

        [MaxLength(20)]
        public string PhoneNumber { get; set; } = string.Empty;

        //public ICollection<EventAttendee> EventAttendees { get; set; } = new List<EventAttendee>();
    }
}
