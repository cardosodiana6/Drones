using System.ComponentModel.DataAnnotations;

namespace Drones.Models
{
    public class MedicationM
    {
        public int Id { get; set; }

        [Required]
        [RegularExpression(@"^[0-9a-zA-Z-_]*$", ErrorMessage = "Allowed only letters, numbers , '-' and '_'")]
        public string Name { get; set; }

        public double Weight { get; set; }

        [Required]
        [RegularExpression(@"^[0-9A-Z_]*$", ErrorMessage = "Allowed only upper case letters, numbers and '_'")]
        public string Code { get; set; }

        public IFormFile? File { get; set; }

        public string? ImageName { get; set; }

        public string? ImagePath { get; set; }
    }
}
