using System.ComponentModel.DataAnnotations.Schema;

namespace Drones.Model.Entities
{
    [Table("DRONE")]
    public class Drone : EntityBase
    {
        public string SerialNumber { get; set; }

        public string Model { get; set; }

        public double Weight { get; set; }

        public int BatteryLevel { get; set; }

        public string State { get; set; }

        public List<Medication> Medications { get; set; }
    }
}
