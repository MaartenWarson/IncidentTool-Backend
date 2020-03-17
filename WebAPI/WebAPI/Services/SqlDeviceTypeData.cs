using System.Collections.Generic;
using System.Linq;
using WebAPI.Context;
using WebAPI.Entities;
using WebAPI.Services.Interfaces;

namespace WebAPI.Services
{
    public class SqlDeviceTypeData : IDeviceTypeData
    {
        private IMToolContext _context;

        public SqlDeviceTypeData(IMToolContext context)
        {
            _context = context;
        }

        public IEnumerable<DeviceType> GetAll()
        {
            return _context.DeviceTypes.OrderBy(dt => dt.DeviceTypeId).ToList();
        }

        // Niet in gebruik voor opdracht
        public DeviceType GetById(int id)
        {
            return _context.DeviceTypes.FirstOrDefault(dt => dt.DeviceTypeId == id);
        }

        public void Add(DeviceType newDeviceType)
        {
            _context.DeviceTypes.Add(newDeviceType);
            _context.SaveChanges();
        }

        // Niet in gebruik voor opdracht
        public void Update(int oldDeviceTypeId, DeviceType newDeviceType)
        {
            _context.DeviceTypes.Where(dt => dt.DeviceTypeId == oldDeviceTypeId)
                                .ToList()
                                .ForEach(dt => dt = newDeviceType);
            _context.SaveChanges();
        }

        // Niet in gebruik voor opdracht
        public void Delete(int id)
        {
            _context.DeviceTypes.Where(dt => dt.DeviceTypeId == id)
                                .ToList()
                                .RemoveAll(dt => dt.DeviceTypeId == id);
            _context.SaveChanges();
        }
    }
}
