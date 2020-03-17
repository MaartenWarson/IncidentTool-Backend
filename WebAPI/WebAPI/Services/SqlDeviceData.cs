using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using WebAPI.Context;
using WebAPI.Entities;
using WebAPI.Services.Interfaces;

namespace WebAPI.Services
{
    public class SqlDeviceData : IDeviceData
    {
        private IMToolContext _context;

        public SqlDeviceData(IMToolContext context)
        {
            _context = context;
        }

        public IEnumerable<Device> GetAll()
        {
            return _context.Devices.OrderBy(d => d.DeviceId).ToList();
        }

        public Device GetById(int id)
        {
            return _context.Devices.FirstOrDefault(d => d.DeviceId == id);
        }

        public void Add(Device newDevice)
        {
            _context.Devices.Add(newDevice);
            _context.SaveChanges();
        }

        // Niet in gebruik voor opdracht
        public void Update(int oldDeviceId, Device newDevice)
        {
            _context.Devices.Where(d => d.DeviceId == oldDeviceId)
                            .ToList()
                            .ForEach(d => d = newDevice);
            _context.SaveChanges();
        }

        // Niet in gebruik voor opdracht
        public void Delete(int id)
        {
            _context.Devices.Where(d => d.DeviceId == id)
                            .ToList()
                            .RemoveAll(d => d.DeviceId == id);
            _context.SaveChanges();
        }
    }
}
