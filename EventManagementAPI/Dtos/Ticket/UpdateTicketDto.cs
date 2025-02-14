namespace EventManagementAPI.Dtos.Ticket
{
    public class UpdateTicketDto
    {
        public int Id { get; set; }
        public string Type { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int EventId { get; set; }
    }
}
