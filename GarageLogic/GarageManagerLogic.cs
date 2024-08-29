using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageLogic
{
    public class GarageManagerLogic
    {
        private readonly List<RegisteredVehicle> r_RegisteredVehicles;

        public GarageManagerLogic()
        {
            r_RegisteredVehicles = new List<RegisteredVehicle>();
        }

        public List<RegisteredVehicle> VehiclesInGarage
        {
            get
            {
                if (r_RegisteredVehicles.Count == 0) 
                {
                    throw new Exception("There is no vehicles in the garage to show.");
                }
                else 
                { 
                    return r_RegisteredVehicles; 
                }
            }
        }

        public bool ContainVehicle(string i_LicenseNumber)
        {
            bool vehicleInGarage = false;

            foreach (RegisteredVehicle registeredVehicle in r_RegisteredVehicles)
            {
                if (registeredVehicle.Vehicle.LicenseNumber == i_LicenseNumber)
                {
                    vehicleInGarage = !vehicleInGarage;
                    break;
                }
            }

            return vehicleInGarage;
        }

        public RegisteredVehicle GetVehicleByLicenseNumber(string i_LicenseNumber)
        {
            RegisteredVehicle vehicle = null;
            
            foreach(RegisteredVehicle registeredVehicle in r_RegisteredVehicles)
            {
                if(registeredVehicle.Vehicle.LicenseNumber == i_LicenseNumber) 
                {
                    vehicle = registeredVehicle;
                    break;
                }
            }

            if (vehicle == null)
            {
                throw new ArgumentException("There is no and was not vehicle in the garage with this license number," +
                    " therefore the operation you tried to do canceled.");
            }

            return vehicle;
        }

        public List<RegisteredVehicle> GetVehiclesByStatus(eVehicleStatusInGarage i_VehicleStatus)
        {
            List<RegisteredVehicle> vehiclesInSameStatus = new List<RegisteredVehicle> ();

            foreach(RegisteredVehicle registeredVehicle in r_RegisteredVehicles)
            {
                if (registeredVehicle.GarageTicketInfo.VehicleStatus == i_VehicleStatus)
                {
                    vehiclesInSameStatus.Add(registeredVehicle);
                }
            }

            if(vehiclesInSameStatus.Count == 0) 
            {
                throw new Exception("There is no vehicles in the garage in this status.");
            }

            return vehiclesInSameStatus;
        }

        public Vehicle CreateVehicle(string i_LicenseNumber, eVehicleType i_VehicleType)
        {
            if (ContainVehicle(i_LicenseNumber))
            {
                throw new ArgumentException("There is a vehicle with the same license number in the system," +
                    " please check the license number again, therefore the operation you tried to do canceled.");
            }
            else
            {
                return VehicleCreator.CreateNewVehicle(i_LicenseNumber, i_VehicleType);
            }
        }

        public void RegisterVehicleInGarage(Vehicle i_Vehicle, GarageTicket i_GarageTicket)
        {
            RegisteredVehicle registeredVehicle = new RegisteredVehicle(i_Vehicle, i_GarageTicket);
            
            r_RegisteredVehicles.Add(registeredVehicle);
        }

        public void ChangeVehicleStatus(string i_LicenseNumber, eVehicleStatusInGarage i_NewVehicleStatus)
        {
            RegisteredVehicle vehicle = GetVehicleByLicenseNumber(i_LicenseNumber);
            
            vehicle.GarageTicketInfo.VehicleStatus = i_NewVehicleStatus;
        }

        public void InflateVehicleWheelsToMax(string i_LicenseNumber)
        {
            Vehicle vehicleThatInflateHisWheels = GetVehicleByLicenseNumber(i_LicenseNumber).Vehicle;

            vehicleThatInflateHisWheels.InflateTires();
        }

        public void Recharge(string i_LicenseNumber, float i_AmountToCharge)
        {
            Vehicle vehicleToCharge = GetVehicleByLicenseNumber(i_LicenseNumber).Vehicle;
            
            if(vehicleToCharge.Engine is ElectricEngine electricEngine)
            {
                filingEnergy(vehicleToCharge, electricEngine, i_AmountToCharge);
            }
            else
            {
                throw new FormatException("The vehicle has fuel engine so we cannot recharge this vehicle," +
                    " therefore the operation you tried to do canceled.");
            }
        }

        public void Refueling(string i_LicenseNumber, float i_AmountToRefuel, eFuelType i_FuelType)
        {
            Vehicle vehicleToRefuel = GetVehicleByLicenseNumber(i_LicenseNumber).Vehicle;
            
            if (vehicleToRefuel.Engine is FuelEngine fuelEngine)
            {
                if (fuelEngine.FuelType == i_FuelType.ToString())
                {
                    filingEnergy(vehicleToRefuel, fuelEngine, i_AmountToRefuel);
                }
                else
                {
                    throw new ArgumentException("The fuel type is not fit to the this vehicle," +
                        " therefore the operation you tried to do canceled.");
                }
            }
            else
            {
                throw new FormatException("The vehicle has electric engine so we cannot refuel this vehicle," + 
                    " therefore the operation you tried to do canceled.");
            }
        }

        private void filingEnergy(Vehicle i_Vehicle, Engine i_Engine, float i_AmountOfFilingEnergy)
        {
            i_Engine.FillingEnergyInEngine(i_AmountOfFilingEnergy);
            i_Vehicle.UpdatingEnergyPrecentage();
        }
    }
}