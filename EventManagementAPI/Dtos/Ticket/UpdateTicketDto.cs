using EventManagementApi.Models;
using System.ComponentModel.DataAnnotations;

namespace EventManagementAPI.Dtos.Ticket
{
    public class UpdateTicketDto
    {
        [Required]
        [MaxLength(50)]
        public string Type { get; set; } = string.Empty;

        [Required]
        public decimal Price { get; set; }

        public int EventId { get; set; }
        public Event Event { get; set; }
    }
}
