using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Demo4.Controllers
{
    public class OrderController : GenericController
    {
        private readonly ILogger _logger;

        public OrderController(ILogger<OrderController> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [Route("[action]")]
        public IActionResult Index()
        {
            _logger.LogInformation("Init method Index of OrderController");
            return Ok();
        }
    }
}
