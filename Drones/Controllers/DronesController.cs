using Drones.Models;
using Drones.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Drones.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DronesController : ControllerBase
    {
        private readonly ILogger<DronesController> _logger;
        private readonly IDronesService _dronesService;

        public DronesController(ILogger<DronesController> logger, IDronesService dronesService)
        {
            _logger = logger;
            _dronesService = dronesService;
        }

        [HttpPost("action")]
        public async Task<int> RegisterDrone([FromBody] DroneM drone) 
        {
            return await _dronesService.RegisterDrone(drone);
        }

        [HttpGet("[action]/{droneId}")]
        public async Task<DroneM> GetDroneById(int droneId)
        {
            return await _dronesService.GetDroneById(droneId);
        }
    }
}