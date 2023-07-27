using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Drones.Model.Entities
{
    public class EntityBase
    {
        [Key]
        public int Id { get; set; }
    }
}
