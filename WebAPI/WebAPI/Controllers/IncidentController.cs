using Microsoft.AspNetCore.Mvc;
using WebAPI.Entities;
using WebAPI.Services.Interfaces;

namespace WebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class IncidentController : Controller
    {
        private IIncidentData _incidentData; // Service om data op te halen

        public IncidentController(IIncidentData incidentData)
        {
            _incidentData = incidentData;
        }

        // GET /incident/all
        [Route("all")]
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_incidentData.GetAll());
        }

        // Niet in gebruik voor opdracht
        [HttpGet]
        public IActionResult GetById(int id)
        {
            return Ok(_incidentData.GetById(id));
        }

        // GET /incident/devicetypeid/{id}
        [Route("devicetypeid/{id}")]
        [HttpGet]
        public IActionResult GetAllByDeviceTypeId(int id)
        {
            return Ok(_incidentData.GetAllByDeviceTypeId(id));
        }

        // POST /incident/add
        [Route("add")]
        [HttpPost]
        public IActionResult Add([FromBody]Incident newIncident)
        {
            Incident incident = null;

            if (ModelState.IsValid)
            {
                incident = new Incident()
                {
                    IncidentId = newIncident.IncidentId,
                    Description = newIncident.Description,
                    CurrentDeviceTypeId = newIncident.CurrentDeviceTypeId
                };
            }

            if (incident != null)
            {
                _incidentData.Add(newIncident);
                return Ok();
            }

            return BadRequest();
        }

        // Niet in gebruik voor opdracht
        [HttpPut("{id}")]
        public IActionResult Update(int oldIncidentId, Incident newIncident)
        {
            if (_incidentData.GetById(oldIncidentId) == null)
            {
                return NotFound();
            }

            _incidentData.Update(oldIncidentId, newIncident);

            return Ok();
        }

        // Niet in gebruik voor opdracht
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (_incidentData.GetById(id) == null)
            {
                return NotFound();
            }

            _incidentData.Delete(id);

            return Ok();
        }
    }
}