
namespace C969_Appointment_Scheduler
{
    internal class City
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? CountryId { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime LastUpdate { get; set; }
        public string LastUpdatedBy { get; set; }
    }
}