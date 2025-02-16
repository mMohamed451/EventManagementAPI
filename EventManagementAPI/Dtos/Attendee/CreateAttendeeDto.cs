using System;
using System.ComponentModel.DataAnnotations;

namespace EventManagementApi.Dtos
{
    public class CreateAttendeeDto
    {
        [Required]
        [MaxLength(100)]
        public string FullName { get; set; } = string.Empty;

        [Required]
        [MaxLength(255)]
        public string Email { get; set; } = string.Empty;

        [MaxLength(20)]
        public string PhoneNumber { get; set; } = string.Empty;
    }
}
