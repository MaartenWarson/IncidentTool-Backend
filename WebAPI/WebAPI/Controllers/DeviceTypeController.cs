using Microsoft.AspNetCore.Mvc;
using WebAPI.Entities;
using WebAPI.Services.Interfaces;

namespace WebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DeviceTypeController : Controller
    {
        private IDeviceTypeData _deviceTypeData; // Service om data op te halen

        public DeviceTypeController(IDeviceTypeData deviceTypeData)
        {
            _deviceTypeData = deviceTypeData;
        }

        // GET /devicetype/all
        [Route("all")]
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_deviceTypeData.GetAll());
        }

        // Niet in gebruik voor opdracht
        [HttpGet]
        public IActionResult GetById(int id)
        {
            return Ok(_deviceTypeData.GetById(id));
        }

        // POST /devicetype/add
        [Route("add")]
        [HttpPost]
        public IActionResult Add([FromBody]DeviceType newDeviceType)
        {
            DeviceType deviceType = null;

            if (ModelState.IsValid)
            {
                deviceType = new DeviceType
                {
                    DeviceTypeId = newDeviceType.DeviceTypeId,
                    Description = newDeviceType.Description
                };
            }

            if (deviceType != null)
            {
                _deviceTypeData.Add(newDeviceType);
                return Ok();
            }

            return BadRequest();   
        }

        // Niet in gebruik voor opdracht
        [HttpPut("{id}")]
        public IActionResult Update(int oldDeviceTypeId, DeviceType newDeviceType)
        {
            if (_deviceTypeData.GetById(oldDeviceTypeId) == null)
            {
                return NotFound();
            }

            _deviceTypeData.Update(oldDeviceTypeId, newDeviceType);

            return Ok();
        }

        // Niet in gebruik voor opdracht
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (_deviceTypeData.GetById(id) == null)
            {
                return NotFound();
            }

            _deviceTypeData.Delete(id);

            return Ok();
        }
    }
}