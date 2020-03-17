using System.Collections.Generic;
using WebAPI.Entities;

namespace WebAPI.Services.Interfaces
{
    public interface IDeviceData
    {
        IEnumerable<Device> GetAll();
        Device GetById(int id);
        void Add(Device newDevice);
        void Update(int oldDeviceId, Device newDevice);
        void Delete(int id);
    }
}
