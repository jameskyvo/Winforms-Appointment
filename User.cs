using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C969_Appointment_Scheduler
{
    public class User
    {
        public int Id { get; set; }
        public required string UserName { get; set; }
        public required string Password { get; set; }
        public required sbyte Active { get; set; }
        public DateTime CreateDate { get; set; }
        public required string CreatedBy { get; set; }
        public DateTime LastUpdate { get; set; }
        public required string LastUpdatedBy { get; set; }
    }
}
