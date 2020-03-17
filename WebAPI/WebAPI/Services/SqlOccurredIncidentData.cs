using System.Collections.Generic;
using System.Linq;
using WebAPI.Context;
using WebAPI.Entities;
using WebAPI.Services.Interfaces;

namespace WebAPI.Services
{
    public class SqlOccurredIncidentData : IOccurredIncidentData
    {
        private IMToolContext _context;

        public SqlOccurredIncidentData(IMToolContext context)
        {
            _context = context;
        }

        public IEnumerable<OccurredIncident> GetAll()
        {
            return _context.OccurredIncidents.OrderBy(oi => oi.OccurredIncidentId).ToList();
        }

        public IEnumerable<OccurredIncident> GetAllSolvedIncidents()
        {
            return _context.OccurredIncidents.Where(oi => oi.Solved == true).ToList();
        }

        public IEnumerable<OccurredIncident> GetAllUnsolvedIncidents()
        {
            return _context.OccurredIncidents.Where(oi => oi.Solved == false).ToList();
        }

        public IEnumerable<OccurredIncident> GetAllIncidentsByAccountId(int id)
        {
            return _context.OccurredIncidents.Where(oi => oi.CurrentUserId == id).ToList();
        }

        // Niet in gebruik voor opdracht
        public OccurredIncident GetOccurredIncidentById(int id)
        {
            return _context.OccurredIncidents.FirstOrDefault(oi => oi.OccurredIncidentId == id);
        }

        public void Add(OccurredIncident newOccurredIncident)
        {
            _context.Add(newOccurredIncident);
            _context.SaveChanges();
        }

        public void SetOccurredIncidentSolved(int id)
        {
            _context.OccurredIncidents.Where(oi => oi.OccurredIncidentId == id)
                                      .ToList()
                                      .ForEach(io => io.Solved = true);
            _context.SaveChanges();
        }

        public void SetOccurredIncidentUnsolved(int id)
        {
            _context.OccurredIncidents.Where(oi => oi.OccurredIncidentId == id)
                                      .ToList()
                                      .ForEach(io => io.Solved = false);
            _context.SaveChanges();
        }
    }
}
