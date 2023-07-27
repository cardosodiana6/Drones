using System.ComponentModel.DataAnnotations;

namespace Drones.Models
{
    public class LoadM
    {
        [Required]
        public int DroneId { get; set; }

        [Required]
        public int MedicationId { get; set; }
    }
}
