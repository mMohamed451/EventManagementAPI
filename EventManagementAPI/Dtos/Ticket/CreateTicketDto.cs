using System.ComponentModel.DataAnnotations;

namespace EventManagementAPI.Dtos.Ticket
{
    public class CreateTicketDto
    {
        [Required]
        [MaxLength(50)]
        public string Type { get; set; } = string.Empty;

        [Required]
        [Range(0, double.MaxValue)]
        public decimal Price { get; set; }

        [Required]
        public int EventId { get; set; }
    }
}
