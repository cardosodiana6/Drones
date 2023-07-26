using System.ComponentModel.DataAnnotations;

namespace Drones.Validations
{
    public class DroneStateValidation : ValidationAttribute
    {
        private List<string> _validValues = new List<string> { "IDLE", "LOADING", "LOADED", "DELIVERING", "DELIVERED", "RETURNING" };

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                var state = value.ToString().ToUpper();
                if (_validValues.Any(v => v == state))
                {
                    return ValidationResult.Success;
                }
            }
            return new ValidationResult($"Select one of these valid values: {String.Join(", ", _validValues)}");
        }
    }
}
