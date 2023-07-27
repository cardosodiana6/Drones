using AutoMapper;
using Drones.Model.Entities;
using Drones.Model.Repository.Interfaces;
using Drones.Models;
using Drones.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Drones.Extensions;

namespace Drones.Services
{
    public class DronesService: IDronesService
    {
        private readonly DbContext _dbContext;
        private readonly IRepository<Drone> _droneRepository;
        private readonly IRepository<Medication> _medicationRepository;
        private readonly IRepository<Load> _loadRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<DronesService> _logger;

        public DronesService(DbContext dbContext, IRepository<Drone> droneRepository, IRepository<Medication> medicationRepository, IRepository<Load> loadRepository, IMapper mapper, ILogger<DronesService> logger)
        {
            _dbContext = dbContext; 
            _droneRepository = droneRepository;
            _medicationRepository = medicationRepository;
            _loadRepository = loadRepository;
            _mapper = mapper;
            _logger = logger;
        }

        #region Drone

        public async Task<int> RegisterDrone(DroneM drone)
        {
            var mappedDrone = _mapper.Map<Drone>(drone);
            await _droneRepository.AddAsync(mappedDrone);
            return mappedDrone.Id;
        }

        public async Task<ServiceResultM> GetDronBatteryLevel(int dronId)
        {
            var drone = await _droneRepository.GetById(dronId);
            return drone != null ? new ServiceResultM { Value = drone.BatteryLevel } : new ServiceResultM
            {
                HasErrors = true,
                ErrorMessage = $"Drone {dronId}, was not found"
            };
        }

        public async Task<List<int>> GetAvailableDronesForLoading()
        {
            return (await _droneRepository.GetDbSet().Where(d => IsDroneAvailableForLoad(d)).Select(d => d.Id).ToListAsync());
        }

        public async Task<bool> ChangeDroneState(DroneStateM droneState)
        {
            var drone = await _droneRepository.GetById(droneState.DroneId);
            return drone != null ? (await CheckDronBatteryLevelAndState(drone, droneState.State)) : false;
        }

        public async Task<bool> CheckDronBatteryLevelAndState(Drone drone, string newState)
        {
            _logger.LogInformation($"Starting the method: CheckDronBatteryLevelAndState");
            if ((newState != "LOADING" || drone.BatteryLevel > 25) && newState != drone.State)
            {
                drone.State = newState;
                await _droneRepository.UpdateAsync(drone);
                _logger.LogWarning($"The dron changed its state from LOADING to {newState}, because the dron battery's level is under 25%");
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<DroneM>> GetDrones()
        {
            var drones = await _droneRepository.GetAllAsync();

            return drones != null ? drones.Select(d => _mapper.Map<DroneM>(d)).ToList() : new List<DroneM>();
        }

        #endregion

        #region Medication

        public async Task<int> RegisterMedication(MedicationM medication)
        {
            medication = await medication.SaveImage();
            var mappedMedication = _mapper.Map<Medication>(medication);
            await _medicationRepository.AddAsync(mappedMedication);
            return mappedMedication.Id;
        }

        #endregion

        #region Load

        public async Task<ServiceResultM> RegisterLoad(LoadM load)
        {
            var mappedLoad = _mapper.Map<Load>(load);
            mappedLoad.CreationDate = DateTime.Now;

            var drone = await _droneRepository.GetById(mappedLoad.DroneId);
            if (drone != null)
            {
                var medication = await _medicationRepository.GetById(mappedLoad.MedicationId);
                if (medication != null)
                {
                    if (IsDroneAvailableForLoadMedication(drone, medication))
                    {
                        await _loadRepository.AddAsync(mappedLoad);
                        return new ServiceResultM { Value = mappedLoad.Id };
                    }
                    else
                    {
                        return new ServiceResultM { Value = -1 };
                    }
                }
                return new ServiceResultM
                {
                    HasErrors = true,
                    ErrorMessage = $"Medication {mappedLoad.MedicationId}, is not registered"
                };
            }
            return new ServiceResultM
            {
                HasErrors = true,
                ErrorMessage = $"Drone {mappedLoad.DroneId}, is not registered"
            };
        }

        public async Task<IEnumerable<LoadM>> GetDroneLoadedMedications(int droneId)
        {
            var droneLoad = await _loadRepository.GetDbSet().Where(l => l.DroneId == droneId).ToListAsync();
            return droneLoad != null ? droneLoad.Select(dl => _mapper.Map<LoadM>(dl)) : new List<LoadM>();
        }


        #endregion


        #region Auxiliar Methods

        private bool IsDroneAvailableForLoadMedication(Drone drone, Medication medication)
        {
            if (drone.IsStateValid())
            {
                var droneTotalLoadedWeight = GetDroneTotalLoadedWeight(drone.Id);
                return droneTotalLoadedWeight + medication.Weight <= drone.Weight;
            }
            return false;
        }

        private bool IsDroneAvailableForLoad(Drone drone)
        {
            if (drone.IsStateValid())
            {
                var droneTotalLoadedWeight = GetDroneTotalLoadedWeight(drone.Id);
                return drone.Weight > droneTotalLoadedWeight;
            }
            return false;
        }

        private double GetDroneTotalLoadedWeight(int droneId)
        {
            return _loadRepository.GetDbSet().Where(l => l.DroneId == droneId).Include(l => l.Medication).Select(l => l.Medication.Weight).Sum();
        }

        

        #endregion

    }
}
