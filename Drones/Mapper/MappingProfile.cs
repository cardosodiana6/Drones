using AutoMapper;
using Drones.Model.Entities;
using Drones.Models;

namespace Drones.Mapper
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<Drone, DroneM>().ReverseMap();
            CreateMap<Medication, MedicationM>().ReverseMap();
            CreateMap<Load, LoadM>().ReverseMap();
        }
    }
}
