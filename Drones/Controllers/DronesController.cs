using Drones.Models;
using Drones.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

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

        #region Drone

        [HttpPost("[action]")]
        public async Task<int> RegisterDrone([FromBody] DroneM drone)
        {
            _logger.LogInformation("RegisterDrone method is started");
            return await _dronesService.RegisterDrone(drone);
        }

        [HttpGet("[action]/{droneId}")]
        public async Task<ServiceResultM> GetDronBatteryLevel(int droneId)
        {
            return await _dronesService.GetDronBatteryLevel(droneId);
        }

        [HttpPut("[action]")]
        public async Task<bool> ChangeDroneState(DroneStateM droneState)
        {
            return await _dronesService.ChangeDroneState(droneState);
        }

        [HttpGet("[action]")]
        public async Task<IEnumerable<int>> GetAvailableDronesForLoading()
        {
            return await _dronesService.GetAvailableDronesForLoading();
        }

        [HttpGet("[action]")]
        public async Task<IEnumerable<DroneM>> GetDrones()
        {
            return await _dronesService.GetDrones();
        }

        #endregion

        #region Medication

        [HttpPost("[action]")]
        public async Task<int> RegisterMedication([FromForm] MedicationM medication)
        {
            return await _dronesService.RegisterMedication(medication);
        }

        #endregion

        #region Load

        [HttpPost("[action]")]
        public async Task<ServiceResultM> RegisterLoad([FromBody] LoadM load)
        {
            return await _dronesService.RegisterLoad(load);
        }

        [HttpGet("[action]/{droneId}")]
        public async Task<IEnumerable<LoadM>> GetDroneLoadedMedications(int droneId)
        {
            return await _dronesService.GetDroneLoadedMedications(droneId);
        }

        #endregion

      
    }
}