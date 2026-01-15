using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C969_Appointment_Scheduler
{
    internal class Customer
    {
        public int? Id { get; set; }
        public string? Name { get; set; }
        public long? AddressId { get; set; }
        public sbyte Active { get; set; } = 0;
        public DateTime? CreateDate { get; set; } = DateTime.Now;
        public string? CreatedBy { get; set; }
        public DateTime? LastUpdate { get; set; }
        public string? LastUpdatedBy { get; set; }
    }
}
