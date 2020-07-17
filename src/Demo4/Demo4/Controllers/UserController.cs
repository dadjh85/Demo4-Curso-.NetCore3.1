using Demo4.DtoModels;
using Microsoft.AspNetCore.Mvc;

namespace Demo4.Controllers
{
    public class UserController : GenericController
    {
        [HttpGet]
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
