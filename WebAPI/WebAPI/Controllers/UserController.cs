using Microsoft.AspNetCore.Mvc;
using WebAPI.Entities;
using WebAPI.Services.Interfaces;

namespace WebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private IUserData _userData; // Service om data op te halen

        public UserController(IUserData userData)
        {
            _userData = userData;
        }

        // Niet in gebruik voor opdracht
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_userData.GetAll());
        }

        // GET /user/{id}
        [Route("{id}")]
        [HttpGet]
        public IActionResult GetById(int id)
        {
            return Ok(_userData.GetById(id));
        }

        // GET /user/name/{name}
        [Route("name/{name}")]
        [HttpGet]
        public IActionResult GetByName(string name)
        {
            return Ok(_userData.GetByName(name));
        }

        // Niet in gebruik voor opdracht
        [HttpPost]
        public IActionResult Add(User newUser)
        {
            _userData.Add(newUser);

            return Ok();
        }

        // Niet in gebruik voor opdracht
        [HttpPut("{id}")]
        public IActionResult Update(int oldUserId, User newUser)
        {
            if (_userData.GetById(oldUserId) == null)
            {
                return NotFound();
            }

            _userData.Update(oldUserId, newUser);

            return Ok();
        }

        // Niet in gebruik voor opdracht
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (_userData.GetById(id) == null)
            {
                return NotFound();
            }

            _userData.Delete(id);

            return Ok();
        }
    }
}