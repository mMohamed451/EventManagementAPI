using System.ComponentModel.DataAnnotations;
using EventManagementApi.Models;

namespace EventManagementAPI.Dtos.Ticket
{
    public class CreateTicketDto
    {
        [Required]
        [MaxLength(50)]
        public string Type { get; set; } = string.Empty;

        [Required]
        public decimal Price { get; set; }

        public int EventId { get; set; }
    }
}
