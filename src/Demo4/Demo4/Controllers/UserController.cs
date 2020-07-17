using Microsoft.AspNetCore.Mvc;

namespace Demo4.Controllers
{
    public class UserController : ControllerBase
    {
        public IActionResult Get(int id)
        {
            return Content($"user {id}");
        }
    }
}
