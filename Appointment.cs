using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C969_Appointment_Scheduler
{
    public class Appointment
    {
        public int AppointmentId { get; set; }
        public required int CustomerId { get; set; }
        public required int UserId { get; set; }
        public required string Title { get; set; }
        public string? Description { get; set; }
        public required string Location { get; set; }
        public required string Contact { get; set; }
        public required string Type { get; set; }
        public string? Url { get; set; }
        public required DateTime Start { get; set; }
        public required DateTime End { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.UtcNow;
        public required string CreatedBy { get; set; }
        public DateTime LastUpdate { get; set; } = DateTime.UtcNow;
        public required string LastUpdateBy { get; set; }
    }
}
