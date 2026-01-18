
namespace C969_Appointment_Scheduler
{
    internal class City
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public int? CountryId { get; set; }
        public DateTime CreateDate { get; set; }
        public required string CreatedBy { get; set; }
        public DateTime LastUpdate { get; set; }
        public required string LastUpdatedBy { get; set; }
    }
}