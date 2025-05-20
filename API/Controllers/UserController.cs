using LogicaNegocio.DTOs.User;
using LogicaNegocio;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly Fachada _fachada;

        public UserController(Fachada fachada)
        {
            _fachada = fachada;
        }

        // POST: api/user
        [HttpPost]
        public IActionResult Post([FromBody] AddUserRequest request)
        {
            _fachada.AddUser(request);
            return Ok();
        }

        // GET: api/user/{username}
        [HttpGet("{username}")]
        public ActionResult<UserResponse> Get(string username)
        {
            var user = _fachada.GetUserByUsername(username);
            if (user == null)
                return NotFound();

            return Ok(user);
        }

        // PUT: api/user
        [HttpPut]
        public IActionResult Put([FromBody] UpdateUserRequest request)
        {
            _fachada.UpdateUser(request);
            return NoContent();
        }
    }
}
