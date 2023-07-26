using System.ComponentModel.DataAnnotations;

namespace Drones.Models
{
    public class DroneM
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [StringLength(100, MinimumLength = 1)]
        public string SerialNumber { get; set; }

        public string Model { get; set; }

        [Range(1,500, ErrorMessage = "Value for {0} must be between {1} and {2}")]
        public double Weight { get; set; }

        [Range(0, 100, ErrorMessage = "Value for {0} must be between {1} and {2}")]
        public int BatteryLevel { get; set; }

        public string State { get; set; }
    }
}
