using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Drones.Model.Entities
{
    [Table("MEDICATION")]
    public class Medication : EntityBase
    {
        public string Name { get; set; }

        public double Weight { get; set; }

        public string Code { get; set; }

        public string ImagePath { get; set; }

    }
}
