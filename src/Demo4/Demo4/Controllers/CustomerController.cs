using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Demo4.Controllers
{
    /// <summary>
    /// Controler of customer
    /// </summary>
    [AllowAnonymous]
    public class CustomerController : ControllerBase
    {
        /// <summary>
        /// Get a customer by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult Get(int id)
        {
            return Content($"Customer {id}");
        }
    }
}
