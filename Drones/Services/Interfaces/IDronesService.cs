using Drones.Models;

namespace Drones.Services.Interfaces
{
    public interface IDronesService
    {
        Task<int> RegisterDrone(DroneM drone);

        Task<int> RegisterMedication(MedicationM medication);

        Task<ServiceResultM> GetBatteryLevelByDrone(int dronId);

        Task<ServiceResultM> RegisterLoad(LoadM load);

        Task<IEnumerable<LoadM>> GetLoadedMedicationsByDrone(int droneId);

        Task<List<int>> GetAvailableDronesForLoading();

        Task<bool> ChangeDroneState(DroneStateM droneState);
    }
}
