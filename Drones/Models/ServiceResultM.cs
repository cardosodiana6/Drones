namespace Drones.Models
{
    public class ServiceResultM
    {
        public bool HasErrors { get; set; }

        public string ErrorMessage { get; set; }

        public object Value { get; set; }
    }
}
