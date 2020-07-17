using Microsoft.AspNetCore.Mvc;

namespace Demo4.Controllers
{
    public class CustomerController : ControllerBase
    {
        public IActionResult Get(int id)
        {
            return Content($"Customer {id}");
        }
    }
}
