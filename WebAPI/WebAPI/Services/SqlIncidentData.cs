using System.Collections.Generic;
using System.Linq;
using WebAPI.Context;
using WebAPI.Entities;
using WebAPI.Services.Interfaces;

namespace WebAPI.Services
{
    public class SqlIncidentData : IIncidentData
    {
        private IMToolContext _context;

        public SqlIncidentData(IMToolContext context)
        {
            _context = context;
        }

        public IEnumerable<Incident> GetAll()
        {
            return _context.Incidents.OrderBy(i => i.IncidentId).ToList();
        }

        // Niet in gebruik voor opdracht
        public Incident GetById(int id)
        {
            return _context.Incidents.FirstOrDefault(i => i.IncidentId == id);
        }

        public IEnumerable<Incident> GetAllByDeviceTypeId(int deviceTypeId)
        {
            return _context.Incidents.Where(i => i.CurrentDeviceTypeId == deviceTypeId).ToList();
        }

        public void Add(Incident newIncident)
        {
            _context.Incidents.Add(newIncident);
            _context.SaveChanges();
        }

        // Niet in gebruik voor opdracht
        public void Update(int oldIncidentId, Incident newIncident)
        {
            _context.Incidents.Where(i => i.IncidentId == oldIncidentId)
                              .ToList()
                              .ForEach(i => i = newIncident);
            _context.SaveChanges();
        }

        // Niet in gebruik voor opdracht
        public void Delete(int id)
        {
            _context.Incidents.Where(i => i.IncidentId == id)
                              .ToList()
                              .RemoveAll(i => i.IncidentId == id);
            _context.SaveChanges();
        }
    }
}
