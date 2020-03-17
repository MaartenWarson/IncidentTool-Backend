using System.Collections.Generic;

namespace WebAPI.Entities
{
    public class User
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public ICollection<OccurredIncident> OccurredIncidents { get; set; } // Nodig voor relatie
    }
}
