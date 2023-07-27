using Drones.Validations;

namespace Drones.Models
{
    public class DroneStateM
    {
        public int DroneId { get; set; }

        [DroneStateValidation]
        public string State { get; set; }
    }
}
