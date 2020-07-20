using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using System;
using System.Globalization;

namespace Demo4.Controllers
{
    /// <summary>
    /// Controler of customer
    /// </summary>
    [AllowAnonymous]
    public class CustomerController : ControllerBase
    {
        private readonly IStringLocalizer<CustomerController> _localizer;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="localizer"></param>
        public CustomerController(IStringLocalizer<CustomerController> localizer)
        {
            _localizer = localizer ?? throw new ArgumentNullException(nameof(localizer));
        }

        /// <summary>
        /// Get a customer by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult Get(int id)
        {
            return Content($"Customer {id} - Message Culture: {_localizer["se ha producido un error al insertar"]}");
        }
    }
}
