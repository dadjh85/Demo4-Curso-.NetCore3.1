using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Demo4.Controllers
{
    /// <summary>
    /// Example of controller
    /// </summary>
    //[AllowAnonymous]
    public class OrderController : GenericController
    {
        private readonly ILogger _logger;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="logger"></param>
        public OrderController(ILogger<OrderController> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// Method Index of order
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("[action]")]
        public IActionResult Index()
        {
            _logger.LogInformation("Init method Index of OrderController");
            return Ok();
        }
    }
}
