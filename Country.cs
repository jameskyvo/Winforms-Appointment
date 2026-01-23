
namespace C969_Appointment_Scheduler
{
    public class Country
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public DateTime CreateDate { get; set; }
        public required string CreatedBy { get; set; }
        public DateTime LastUpdate { get; set; }
        public required string LastUpdatedBy { get; set; }
    }
}