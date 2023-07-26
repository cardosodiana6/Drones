using System.ComponentModel.DataAnnotations;

namespace Drones.Validations
{
    public class DroneModelValidation: ValidationAttribute
    {
        private List<string> _validValues = new List<string> { "Lightweight", "Middleweight", "Cruiserweight", "Heavyweight" };

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                var model = value.ToString().ToLower();
                if (_validValues.Any(v => v.ToLower() == model))
                {
                    return ValidationResult.Success;
                }
            }
            return new ValidationResult($"Select one of these valid values: {String.Join(", ", _validValues)}");
        }
    }
}
