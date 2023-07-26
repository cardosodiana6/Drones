using AutoMapper;
using Drones.Model.Entities;
using Drones.Model.Repository.Interfaces;
using Drones.Models;
using Drones.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Drones.Services
{
    public class DronesService: IDronesService
    {
        private readonly DbContext _dbContext;
        private readonly IRepository<Drone> _droneRepository;
        private readonly IRepository<Medication> _medicationRepository;
        private readonly IRepository<Load> _loadRepository;
        private readonly IMapper _mapper;

        public DronesService(DbContext dbContext, IRepository<Drone> droneRepository, IRepository<Medication> medicationRepository, IRepository<Load> loadRepository, IMapper mapper)
        {
            _dbContext = dbContext; 
            _droneRepository = droneRepository;
            _medicationRepository = medicationRepository;
            _loadRepository = loadRepository;
            _mapper = mapper;
        }

        public async Task<int> RegisterDrone(DroneM drone)
        {
            var newDrone = _mapper.Map<Drone>(drone);
            await _droneRepository.AddAsync(newDrone);
            return newDrone.Id;
        }

        public async Task<int> RegisterMedication(MedicationM medication)
        {
            medication = await SaveFile(medication);
            var newMedication = _mapper.Map<Medication>(medication);
            await _medicationRepository.AddAsync(newMedication);
            return newMedication.Id;
        }

        private async Task<MedicationM> SaveFile(MedicationM medication) 
        {
            if (medication.File != null && medication.File.Length > 0)
            {
                var file = medication.File;
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
                medication.ImageName = file.Name;
                medication.ImagePath = fileName;
            }
            return medication;
        }

        public async Task<int> GetBatteryLevel(int dronId) 
        {
            var drone = await _droneRepository.GetById(dronId);
            return drone != null ? drone.BatteryLevel : -1;
        }


    }
}
