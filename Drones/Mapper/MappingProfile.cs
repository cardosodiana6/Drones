using AutoMapper;
using Drones.Model.Entities;
using Drones.Models;

namespace Drones.Mapper
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<DroneM, Drone>().ReverseMap();
            CreateMap<MedicationM, Medication>();
            CreateMap<LoadM, Load>().ReverseMap();
        }
    }
}
