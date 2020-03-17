namespace WebAPI.Entities
{
    public class Incident
    {
        public int IncidentId { get; set; }
        public string Description { get; set; }
        public int CurrentDeviceTypeId { get; set; }
        public DeviceType DeviceType { get; set; } // Nodig voor relatie
    }
}
