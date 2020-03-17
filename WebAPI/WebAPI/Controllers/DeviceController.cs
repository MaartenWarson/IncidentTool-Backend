using Microsoft.AspNetCore.Mvc;
using WebAPI.Entities;
using WebAPI.Services.Interfaces;

namespace WebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DeviceController : Controller
    {
        private IDeviceData _deviceData; // Service om data op te halen

        public DeviceController(IDeviceData deviceData)
        {
            _deviceData = deviceData;
        }

        // GET /device/all
        [Route("all")]
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_deviceData.GetAll());
        }

        // GET /device/{id}
        [Route("{id}")]
        [HttpGet]
        public IActionResult GetById(int id)
        {
            return Ok(_deviceData.GetById(id));
        }

        // POST /device/add
        [Route("add")]
        [HttpPost]
        public IActionResult Add([FromBody]Device newDevice)
        {
            Device device = null;

            if (ModelState.IsValid)
            {
                device = new Device()
                {
                    DeviceId = newDevice.DeviceId,
                    Name = newDevice.Name,
                    Location = newDevice.Location,
                    CurrentDeviceTypeId = newDevice.CurrentDeviceTypeId
                };
            }

            if (device != null)
            {
                _deviceData.Add(device);
                return Ok();
            }

            return BadRequest();
        }

        // Niet in gebruik voor opdracht
        [HttpPut("{id}")]
        public IActionResult Update(int oldDeviceId, Device newDevice)
        {
            if (_deviceData.GetById(oldDeviceId) == null)
            {
                return NotFound();
            }

            _deviceData.Update(oldDeviceId, newDevice);

            return Ok();
        }

        // Niet in gebruik voor opdracht
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (_deviceData.GetById(id) == null)
            {
                return NotFound();
            }

            _deviceData.Delete(id);

            return Ok();
        }
    }
}