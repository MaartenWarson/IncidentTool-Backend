using Microsoft.AspNetCore.Mvc;
using WebAPI.Entities;
using WebAPI.Services.Interfaces;

namespace WebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OccurredIncidentController : Controller
    {
        private IOccurredIncidentData _occurredIncidentData; // Service om data op te halen

        public OccurredIncidentController(IOccurredIncidentData occurredIncidentData)
        {
            _occurredIncidentData = occurredIncidentData;
        }

        // GET /occurredincident/all
        [Route("all")]
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_occurredIncidentData.GetAll());
        }

        // GET /occurredincident/all/solved
        [Route("all/solved")]
        [HttpGet]
        public IActionResult GetAllSolvedIncidents()
        {
            return Ok(_occurredIncidentData.GetAllSolvedIncidents());
        }

        // GET /occurredincident/all/unsolved
        [Route("all/unsolved")]
        [HttpGet]
        public IActionResult GetAllUnsolvedIncidents()
        {
            return Ok(_occurredIncidentData.GetAllUnsolvedIncidents());
        }

        // GET /occurredincident/all/user/{id}
        [Route("all/user/{id}")]
        [HttpGet]
        public IActionResult GetAllIncidentsByAccountId(int id)
        {
            return Ok(_occurredIncidentData.GetAllIncidentsByAccountId(id));
        }

        // Niet in gebruik voor opdracht
        [HttpGet]
        public IActionResult GetOccurredIncidentById(int id)
        {
            return Ok(_occurredIncidentData.GetOccurredIncidentById(id));
        }

        // POST /occurredincident/add
        [Route("add")]
        [HttpPost]
        public IActionResult Add([FromBody] OccurredIncident newOccurredIncident)
        {
            OccurredIncident occurredIncident = null;

            if (ModelState.IsValid)
            {
                occurredIncident = new OccurredIncident()
                {
                    OccurredIncidentId = newOccurredIncident.OccurredIncidentId,
                    IncidentDescription = newOccurredIncident.IncidentDescription,
                    CurrentUserId = newOccurredIncident.CurrentUserId,
                    Solved = newOccurredIncident.Solved,
                    DeviceId = newOccurredIncident.DeviceId
                };
            }

            if (occurredIncident != null)
            {
                _occurredIncidentData.Add(newOccurredIncident);
                return Ok();
            }

            return BadRequest();            
        }

        // GET /occurredincident/{id}/solved
        [Route("{id}/solved")]
        [HttpGet]
        public IActionResult SetOccurredIncidentSolved(int id)
        {
            _occurredIncidentData.SetOccurredIncidentSolved(id);

            return Ok();
        }

        // GET /occurredincident/{id}/unsolved
        [Route("{id}/unsolved")]
        [HttpGet]
        public IActionResult SetOccurredIncidentUnsolved(int id)
        {
            _occurredIncidentData.SetOccurredIncidentUnsolved(id);

            return Ok();
        }
    }
}