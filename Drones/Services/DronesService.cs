using Drones.Model.Entities;
using Drones.Model.Repository.Interfaces;
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

        public DronesService(DbContext dbContext, IRepository<Drone> droneRepository, IRepository<Medication> medicationRepository, IRepository<Load> loadRepository)
        {
            _dbContext = dbContext; 
            _droneRepository = droneRepository;
            _medicationRepository = medicationRepository;
            _loadRepository = loadRepository;
        }
    }
}
