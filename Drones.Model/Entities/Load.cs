using System.ComponentModel.DataAnnotations.Schema;

namespace Drones.Model.Entities
{
    [Table("LOAD")]
    public class Load : EntityBase
    {
        public int DroneId { get; set; }

        public Drone Drone { get; set; }

        public int MedicationId { get; set; }

        public Medication Medication { get; set; }

        public DateTime CreationDate { get; set; }
    }
}
