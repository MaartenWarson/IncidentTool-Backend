namespace WebAPI.Entities
{
    public class OccurredIncident
    {
        public int OccurredIncidentId { get; set; }
        public int DeviceId { get; set; }
        public string IncidentDescription { get; set; }
        public int CurrentUserId { get; set; }
        public User User { get; set; } // Nodig voor relatie
        public bool Solved { get; set; }
    }
}
