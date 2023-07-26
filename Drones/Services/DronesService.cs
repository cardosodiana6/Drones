using AutoMapper;
using Drones.Model.Entities;
using Drones.Model.Repository.Interfaces;
using Drones.Models;
using Drones.Services.Interfaces;
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

        public async Task<DroneM> GetDroneById(int id) 
        {
            var drone = await _droneRepository.GetById(id);
            return _mapper.Map<DroneM>(drone);
        }
    }
}
