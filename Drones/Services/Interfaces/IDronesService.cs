using Drones.Models;

namespace Drones.Services.Interfaces
{
    public interface IDronesService
    {
        Task<int> RegisterDrone(DroneM drone);

        Task<DroneM> GetDroneById(int id);
    }
}
