using System.Collections.Generic;

namespace WebAPI.Entities
{
    public class DeviceType
    {
        public int DeviceTypeId { get; set; }
        public string Description { get; set; }
        public ICollection<Device> Devices { get; set; } // Nodig voor relatie
        public ICollection<Incident> Incidents { get; set; } // Nodig voor relatie
    }
}
