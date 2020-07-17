using Microsoft.AspNetCore.Mvc;
using Service.DtoModels;
using Service.UserService;
using System;
using System.Threading.Tasks;

namespace Demo4.Controllers
{
    public class UserController : GenericController
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
        }

        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            var result = await _userService.GetList();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Content($"user {id}");
        }

        [HttpPost]
        public IActionResult Post(DtoUserAdd item)
        {
            return CreatedAtAction(nameof(Get), item);
        }

        [HttpGet("{idUser}/Roles")]
        public IActionResult GetRoles(int idUser)
        {
            return Ok();
        }

        [HttpPost("{idUser}/Roles")]
        public IActionResult AddRol(int idUser, DtoRolAdd item)
        {
            return CreatedAtAction(nameof(GetRoles), item);
        }
    }
}
