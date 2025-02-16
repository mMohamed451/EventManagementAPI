using System;
using System.ComponentModel.DataAnnotations;

namespace EventManagementApi.Dtos
{
    public class CreateEventDto
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required]
        public DateTime Date { get; set; }

        [MaxLength(255)]
        public string? Location { get; set; }

        public string? Description { get; set; }
    }
}
