using Microsoft.AspNetCore.Mvc;

namespace Drones.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DroneController : ControllerBase
    {
        private readonly ILogger<DroneController> _logger;

        public DroneController(ILogger<DroneController> logger)
        {
            _logger = logger;
        }

    }
}