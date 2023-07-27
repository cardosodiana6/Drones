using Drones.Model.Entities;
using Drones.Models;

namespace Drones.Services.Interfaces
{
    public interface IDronesService
    {
        Task<int> RegisterDrone(DroneM drone);

        Task<int> RegisterMedication(MedicationM medication);

        Task<ServiceResultM> GetDronBatteryLevel(int dronId);

        Task<ServiceResultM> RegisterLoad(LoadM load);

        Task<IEnumerable<LoadM>> GetDroneLoadedMedications(int droneId);

        Task<List<int>> GetAvailableDronesForLoading();

        Task<bool> ChangeDroneState(DroneStateM droneState);

        Task<bool> CheckDronBatteryLevelAndState(Drone drone, string newState);

        Task<IEnumerable<DroneM>> GetDrones();
    }
}
