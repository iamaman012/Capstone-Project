using Microsoft.Extensions.Logging;
using System.ComponentModel.DataAnnotations;

namespace EventManagementProject.Models
{
    public class ScheduledPublicEvent
    {
        [Key]
        public int ScheduledPublicEventId { get; set; }
        public int UserId { get; set; }
        public int EventId { get; set; }
        public int PublicQuotationRequestId { get; set; }
        public string EventName { get; set; }
        public string Host { get; set; }
        public string ImageURL { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public int TotalSeats { get; set; }
        public int RemainingSeats { get; set; }
        public double TicketPrice { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Timing { get; set; }
        public string Venue { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsActive { get; set; }
        public string City { get; set; }

        public User User { get; set; }
        public Event Event { get; set; }
        public PublicQuotationRequest PublicQuotationRequest { get; set; }
        public ICollection<Ticket> Tickets { get; set; }

    }
}
