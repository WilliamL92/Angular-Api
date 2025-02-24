using Microsoft.AspNetCore.Mvc;
using Angular_Api.Application.Services;
using Angular_Api.Domain.Entities;

namespace Angular_Api.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly UserService _userService;

        public UsersController(UserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<User>> Get()
        {
            var users = _userService.GetAllUsers();
            return Ok(users);
        }
    }
}