using Drones.Model.Entities;
using Drones.Models;

namespace Drones.Extensions
{
    public static class MedicationMExtensions
    {

        public static async Task<MedicationM> SaveImage(this MedicationM @this) 
        {
            if (@this.File != null && @this.File.Length > 0)
            {
                var file = @this.File;
                var extension = $".{file.FileName.Split('.')[file.FileName.Split('.').Length - 1]}";

                var fileName = $"{DateTime.Now.Ticks}{extension}";
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Upload\\Files");

                if (!Directory.Exists(filePath))
                {
                    Directory.CreateDirectory(filePath);
                }
                var exactPath = Path.Combine(Directory.GetCurrentDirectory(), "Upload\\Files", fileName);
                using (var stream = new FileStream(exactPath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
                @this.ImageName = file.Name;
                @this.ImagePath = fileName;
            }
            return @this;
        }
    }
}
