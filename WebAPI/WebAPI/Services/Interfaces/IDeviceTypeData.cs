using System.Collections.Generic;
using WebAPI.Entities;

namespace WebAPI.Services.Interfaces
{
    public interface IDeviceTypeData
    {
        IEnumerable<DeviceType> GetAll();
        DeviceType GetById(int id);
        void Add(DeviceType newDeviceType);
        void Update(int oldDeviceTypeId, DeviceType newDeviceType);
        void Delete(int id);
    }
}
