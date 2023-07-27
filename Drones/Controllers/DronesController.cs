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

        [HttpPost("[action]")]
        public async Task<int> RegisterDrone([FromBody] DroneM drone) 
        {
            _logger.LogInformation("RegisterDrone method is started");
            return await _dronesService.RegisterDrone(drone);
        }

        [HttpPost("[action]")]
        public async Task<int> RegisterMedication([FromForm] MedicationM medication)
        {
            return await _dronesService.RegisterMedication(medication);
        }

        [HttpGet("[action]/{droneId}")]
        public async Task<ServiceResultM> GetBatteryLevelByDrone(int droneId)
        {
            return await _dronesService.GetBatteryLevelByDrone(droneId);
        }

        [HttpPost("[action]")]
        public async Task<ServiceResultM> RegisterLoad([FromBody] LoadM load)
        {
            return await _dronesService.RegisterLoad(load);
        }

        [HttpGet("[action]/{droneId}")]
        public async Task<IEnumerable<LoadM>> GetLoadedMedicationsByDrone(int droneId)
        {
            return await _dronesService.GetLoadedMedicationsByDrone(droneId);
        }

        [HttpGet("[action]")]
        public async Task<IEnumerable<int>> GetAvailableDronesForLoading()
        {
            return await _dronesService.GetAvailableDronesForLoading();
        }

        [HttpPut("[action]")]
        public async Task<bool> ChangeDroneState(DroneStateM droneState)
        {
            return await _dronesService.ChangeDroneState(droneState);
        }

    }
}