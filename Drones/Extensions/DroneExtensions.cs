using Drones.Model.Entities;
using Drones.Models;
using System.Runtime.CompilerServices;

namespace Drones.Extensions
{
    public static class DroneExtensions
    {
        public static bool IsStateValid(this Drone @this) 
        {
            return @this != null && (@this.State == "IDLE" || @this.State == "LOADING");
        }

    }
}
