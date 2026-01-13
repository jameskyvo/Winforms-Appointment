using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C969_Appointment_Scheduler
{
    internal class Address
    {
        public int Id { get; set; }
        public required string StreetAddress { get; set; }
        public string? SecondaryStreetAddress { get; set; }
        public int CityId { get; }
        public int PostalCode { get; set; }
        public required string PhoneNumber { get; set; }

        public DateTime CreateDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime LastUpdate { get; set; }
        public string LastUpdatedBy { get; set; }

    }
}
