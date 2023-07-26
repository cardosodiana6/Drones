using System.ComponentModel.DataAnnotations;

namespace Drones.Model.Entities
{
    public class EntityBase
    {
        [Key]
        public int Id { get; set; }
    }
}
