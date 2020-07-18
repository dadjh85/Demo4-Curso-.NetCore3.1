using Microsoft.AspNetCore.Mvc;

namespace Demo4.Controllers
{
    /// <summary>
    /// Generic controller for centralice configuration of all controllers
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class GenericController : ControllerBase
    {
    }
}
