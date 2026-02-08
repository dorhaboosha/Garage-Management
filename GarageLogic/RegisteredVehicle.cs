using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageLogic
{
    /// <summary>
    /// Combines a vehicle with its garage ticket, representing a vehicle registered in the garage.
    /// </summary>
    public class RegisteredVehicle
    {
        private readonly Vehicle r_Vehicle;
        private readonly GarageTicket r_GarageTicket;

        /// <summary>
        /// Creates a new registered vehicle pairing a vehicle with its garage ticket.
        /// </summary>
        /// <param name="i_Vehicle">The vehicle.</param>
        /// <param name="i_OwnerVehicleInfo">The garage ticket with owner and status information.</param>
        internal RegisteredVehicle(Vehicle i_Vehicle, GarageTicket i_OwnerVehicleInfo)
        {
            r_Vehicle = i_Vehicle;
            r_GarageTicket = i_OwnerVehicleInfo;
        }

        /// <summary>
        /// Gets the vehicle.
        /// </summary>
        public Vehicle Vehicle
        {
            get
            { 
                return r_Vehicle; 
            }
        }

        /// <summary>
        /// Gets the garage ticket with owner and status information.
        /// </summary>
        public GarageTicket GarageTicketInfo
        {
            get 
            {
                return r_GarageTicket;
            }
        }

        /// <summary>
        /// Returns a string combining the garage ticket info and vehicle details.
        /// </summary>
        /// <returns>Formatted registered vehicle information.</returns>
        public override string ToString()
        {
            string registeredCar = string.Format("{0}\n{1}", GarageTicketInfo.ToString(), Vehicle.ToString());

            return registeredCar.ToString();
        }
    }
}