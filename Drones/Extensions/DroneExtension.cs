using Drones.Model.Entities;
using Drones.Models;
using System.Runtime.CompilerServices;
using System.Text;

namespace Drones.Extensions
{
    public static class DroneExtension
    {
        public static bool IsStateValid(this Drone @this) 
        {
            return @this != null && (@this.State == "IDLE" || @this.State == "LOADING");
        }

        public static bool HasToChangeState(this Drone @this)
        {
            return @this.State == "LOADING" && @this.BatteryLevel < 25;
        }

    }
}
