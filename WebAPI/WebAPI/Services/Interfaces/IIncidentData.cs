using System.Collections.Generic;
using WebAPI.Entities;

namespace WebAPI.Services.Interfaces
{
    public interface IIncidentData
    {
        IEnumerable<Incident> GetAll();
        IEnumerable<Incident> GetAllByDeviceTypeId(int deviceTypeId);
        Incident GetById(int id);
        void Add(Incident newIncident);
        void Update(int oldIncidentId, Incident newIncident);
        void Delete(int id);
    }
}
