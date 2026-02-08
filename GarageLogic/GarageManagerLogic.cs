using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageLogic
{
    /// <summary>
    /// Core business logic for the garage management system. Handles vehicle registration,
    /// status changes, refueling, recharging, and wheel inflation.
    /// </summary>
    public class GarageManagerLogic
    {
        private readonly List<RegisteredVehicle> r_RegisteredVehicles;

        /// <summary>
        /// Initializes a new empty garage.
        /// </summary>
        public GarageManagerLogic()
        {
            r_RegisteredVehicles = new List<RegisteredVehicle>();
        }

        /// <summary>
        /// Gets the list of all registered vehicles in the garage.
        /// </summary>
        /// <exception cref="InvalidOperationException">Thrown when the garage is empty.</exception>
        public List<RegisteredVehicle> VehiclesInGarage
        {
            get
            {
                if (r_RegisteredVehicles.Count == 0)
                {
                    throw new InvalidOperationException("There are no vehicles in the garage to show.");
                }
                else
                {
                    return r_RegisteredVehicles;
                }
            }
        }

        /// <summary>
        /// Checks whether a vehicle with the given license number exists in the garage.
        /// </summary>
        /// <param name="i_LicenseNumber">The license plate number to search for.</param>
        /// <returns>True if the vehicle is in the garage; otherwise false.</returns>
        public bool ContainVehicle(string i_LicenseNumber)
        {
            bool vehicleInGarage = false;

            foreach (RegisteredVehicle registeredVehicle in r_RegisteredVehicles)
            {
                if (registeredVehicle.Vehicle.LicenseNumber == i_LicenseNumber)
                {
                    vehicleInGarage = true;
                    break;
                }
            }

            return vehicleInGarage;
        }

        /// <summary>
        /// Gets the registered vehicle by its license number.
        /// </summary>
        /// <param name="i_LicenseNumber">The license plate number.</param>
        /// <returns>The registered vehicle.</returns>
        /// <exception cref="ArgumentException">Thrown when no vehicle with the given license exists.</exception>
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

        /// <summary>
        /// Gets all vehicles that have the specified status.
        /// </summary>
        /// <param name="i_VehicleStatus">The status to filter by.</param>
        /// <returns>List of vehicles with the given status.</returns>
        /// <exception cref="InvalidOperationException">Thrown when no vehicles exist with the specified status.</exception>
        public List<RegisteredVehicle> GetVehiclesByStatus(eVehicleStatusInGarage i_VehicleStatus)
        {
            List<RegisteredVehicle> vehiclesInSameStatus = new List<RegisteredVehicle>();

            foreach (RegisteredVehicle registeredVehicle in r_RegisteredVehicles)
            {
                if (registeredVehicle.GarageTicketInfo.VehicleStatus == i_VehicleStatus)
                {
                    vehiclesInSameStatus.Add(registeredVehicle);
                }
            }

            if (vehiclesInSameStatus.Count == 0)
            {
                throw new InvalidOperationException("There are no vehicles in the garage with this status.");
            }

            return vehiclesInSameStatus;
        }

        /// <summary>
        /// Creates a new vehicle of the specified type. Does not register it in the garage.
        /// </summary>
        /// <param name="i_LicenseNumber">The license plate number for the vehicle.</param>
        /// <param name="i_VehicleType">The type of vehicle to create.</param>
        /// <returns>A new vehicle instance ready for property configuration.</returns>
        /// <exception cref="ArgumentException">Thrown when a vehicle with the same license already exists.</exception>
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

        /// <summary>
        /// Registers a vehicle and its garage ticket in the garage.
        /// </summary>
        /// <param name="i_Vehicle">The vehicle to register.</param>
        /// <param name="i_GarageTicket">The garage ticket with owner and status information.</param>
        public void RegisterVehicleInGarage(Vehicle i_Vehicle, GarageTicket i_GarageTicket)
        {
            RegisteredVehicle registeredVehicle = new RegisteredVehicle(i_Vehicle, i_GarageTicket);
            
            r_RegisteredVehicles.Add(registeredVehicle);
        }

        /// <summary>
        /// Changes the status of a vehicle in the garage.
        /// </summary>
        /// <param name="i_LicenseNumber">The license plate number.</param>
        /// <param name="i_NewVehicleStatus">The new status to set.</param>
        public void ChangeVehicleStatus(string i_LicenseNumber, eVehicleStatusInGarage i_NewVehicleStatus)
        {
            RegisteredVehicle vehicle = GetVehicleByLicenseNumber(i_LicenseNumber);
            
            vehicle.GarageTicketInfo.VehicleStatus = i_NewVehicleStatus;
        }

        /// <summary>
        /// Inflates all wheels of the specified vehicle to maximum pressure.
        /// </summary>
        /// <param name="i_LicenseNumber">The license plate number.</param>
        public void InflateVehicleWheelsToMax(string i_LicenseNumber)
        {
            Vehicle vehicleThatInflateHisWheels = GetVehicleByLicenseNumber(i_LicenseNumber).Vehicle;

            vehicleThatInflateHisWheels.InflateTires();
        }

        /// <summary>
        /// Recharges an electric vehicle's battery.
        /// </summary>
        /// <param name="i_LicenseNumber">The license plate number.</param>
        /// <param name="i_AmountToCharge">Amount of charge to add (in minutes).</param>
        /// <exception cref="FormatException">Thrown when the vehicle has a fuel engine.</exception>
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

        /// <summary>
        /// Refuels a fuel-powered vehicle.
        /// </summary>
        /// <param name="i_LicenseNumber">The license plate number.</param>
        /// <param name="i_AmountToRefuel">Amount of fuel to add.</param>
        /// <param name="i_FuelType">The type of fuel (must match the vehicle's engine).</param>
        /// <exception cref="ArgumentException">Thrown when the fuel type does not match the vehicle.</exception>
        /// <exception cref="FormatException">Thrown when the vehicle has an electric engine.</exception>
        public void Refueling(string i_LicenseNumber, float i_AmountToRefuel, eFuelType i_FuelType)
        {
            Vehicle vehicleToRefuel = GetVehicleByLicenseNumber(i_LicenseNumber).Vehicle;
            
            if (vehicleToRefuel.Engine is FuelEngine fuelEngine)
            {
                if (fuelEngine.FuelTypeEnum == i_FuelType)
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

        /// <summary>
        /// Fills the vehicle's engine with energy and updates the energy percentage display.
        /// </summary>
        /// <param name="i_Vehicle">The vehicle to fill.</param>
        /// <param name="i_Engine">The vehicle's engine.</param>
        /// <param name="i_AmountOfFilingEnergy">The amount of energy to add.</param>
        private void filingEnergy(Vehicle i_Vehicle, Engine i_Engine, float i_AmountOfFilingEnergy)
        {
            i_Engine.FillingEnergyInEngine(i_AmountOfFilingEnergy);
            i_Vehicle.UpdatingEnergyPrecentage();
        }
    }
}