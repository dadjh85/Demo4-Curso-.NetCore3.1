using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.DtoModels;
using Service.UserService;
using System;
using System.Threading.Tasks;

namespace Demo4.Controllers
{
    /// <summary>
    /// Controler of User
    /// </summary>
    [Authorize]
    public class UserController : GenericController
    {
        private readonly IUserService _userService;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="userService"></param>
        public UserController(IUserService userService)
        {
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
        }

        /// <summary>
        /// GetList of User
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            var result = await _userService.GetList();
            return Ok(result);
        }

        /// <summary>
        /// Get a user by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Content($"user {id}");
        }

        /// <summary>
        /// Add new User
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post(DtoUserAdd item)
        {
            return CreatedAtAction(nameof(Get), item);
        }

        /// <summary>
        /// Get a roles of a user
        /// </summary>
        /// <param name="idUser"></param>
        /// <returns></returns>
        [HttpGet("{idUser}/Roles")]
        public IActionResult GetRoles(int idUser)
        {
            return Ok();
        }

        /// <summary>
        /// Add rol to a user
        /// </summary>
        /// <param name="idUser"></param>
        /// <param name="item"></param>
        /// <returns></returns>
        [HttpPost("{idUser}/Roles")]
        public IActionResult AddRol(int idUser, DtoRolAdd item)
        {
            return CreatedAtAction(nameof(GetRoles), item);
        }
    }
}
