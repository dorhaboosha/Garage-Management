using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageLogic
{
    public class RegisteredVehicle
    {
        private readonly Vehicle r_Vehicle;
        private readonly GarageTicket r_GarageTicket;

        internal RegisteredVehicle(Vehicle i_Vehicle, GarageTicket i_OwnerVehicleInfo)
        {
            r_Vehicle = i_Vehicle;
            r_GarageTicket = i_OwnerVehicleInfo;
        }

        public Vehicle Vehicle
        {
            get
            { 
                return r_Vehicle; 
            }
        }

        public GarageTicket GarageTicketInfo
        {
            get 
            {
                return r_GarageTicket;
            }
        }

        public override string ToString()
        {
            string registeredCar = string.Format("{0}\n{1}", GarageTicketInfo.ToString(), Vehicle.ToString());

            return registeredCar.ToString();
        }
    }
}