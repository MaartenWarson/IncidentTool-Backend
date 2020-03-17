using System.Collections.Generic;
using WebAPI.Entities;

namespace WebAPI.Services.Interfaces
{
    public interface IOccurredIncidentData
    {
        IEnumerable<OccurredIncident> GetAll();
        IEnumerable<OccurredIncident> GetAllSolvedIncidents();
        IEnumerable<OccurredIncident> GetAllUnsolvedIncidents();
        IEnumerable<OccurredIncident> GetAllIncidentsByAccountId(int id);
        OccurredIncident GetOccurredIncidentById(int id);
        void Add(OccurredIncident newOccurredIncident);
        void SetOccurredIncidentSolved(int id);
        void SetOccurredIncidentUnsolved(int id);
    }
}
