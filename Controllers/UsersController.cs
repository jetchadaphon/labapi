using LABAPI.Models;
using LABAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace LABAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _repo;
        private readonly ILogger<UsersController> _logger;

        public UsersController(IUserRepository repo, ILogger<UsersController> logger)
        {
            _repo = repo;
            _logger = logger;
        }

        [HttpGet]
        public ActionResult<IEnumerable<User>> Get()
        {
            return Ok(_repo.GetAll());
        }

        [HttpGet("{id:guid}")]
        public ActionResult<User> Get(Guid id)
        {
            var user = _repo.Get(id);
            if (user == null) return NotFound();
            return Ok(user);
        }

        [HttpPost]
        public ActionResult<User> Post([FromBody] User user)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var created = _repo.Create(user);
            return CreatedAtAction(nameof(Get), new { id = created.Id }, created);
        }

        [HttpPut("{id:guid}")]
        public ActionResult Put(Guid id, [FromBody] User user)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var ok = _repo.Update(id, user);
            if (!ok) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public ActionResult Delete(Guid id)
        {
            var ok = _repo.Delete(id);
            if (!ok) return NotFound();
            return NoContent();
        }
    }
}
