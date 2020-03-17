namespace WebAPI.Entities
{
    public class Device
    {
        public int DeviceId { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public int CurrentDeviceTypeId { get; set; }
        public DeviceType DeviceType { get; set; } // Nodig voor relatie
    }
}
