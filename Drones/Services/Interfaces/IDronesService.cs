using Drones.Models;

namespace Drones.Services.Interfaces
{
    public interface IDronesService
    {
        Task<int> RegisterDrone(DroneM drone);

        Task<int> RegisterMedication(MedicationM medication);

        Task<int> GetBatteryLevel(int dronId);
    }
}
