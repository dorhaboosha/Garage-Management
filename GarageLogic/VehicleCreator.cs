using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageLogic
{
    /// <summary>
    /// Factory for creating vehicles with the appropriate engine and wheels based on vehicle type.
    /// </summary>
    internal static class VehicleCreator
    {
        private const float k_MaxBatteryLifeInElectricCar = 210;
        private const float k_FuelBasedCarTank = 45;
        private const float k_MaxBatteryLifeInElectricMotorcycle = 150;
        private const float k_FuelBasedMotorcycleTank = 5.5f;
        private const float k_FuelBasedTruckTank = 120;

        /// <summary>
        /// Creates a new vehicle of the specified type with the appropriate engine and wheels.
        /// </summary>
        /// <param name="i_LicenseNumber">The license plate number for the vehicle.</param>
        /// <param name="i_VehicleType">The type of vehicle to create.</param>
        /// <returns>A new vehicle instance (Car, Motorcycle, or Truck) ready for property configuration.</returns>
        /// <exception cref="ArgumentException">Thrown when vehicle creation fails.</exception>
        internal static Vehicle CreateNewVehicle(string i_LicenseNumber, eVehicleType i_VehicleType)
        {
            Vehicle vehicle;
            Engine engine = createEngine(i_VehicleType);
            Wheel[] wheels = createWheels(i_VehicleType);

            if (engine == null)
            {
                throw new ArgumentException("The system failed to create the vehicle (there was a problem creating the engine).\n" +
                    "Please check that the data you enter into the system is correct and try again.");
            }

            if (wheels == null)
            {
                throw new ArgumentException("The system failed to create the vehicle (there was a problem creating the wheels).\n" +
                    "Please check that the data you enter into the system is correct and try again.");
            }

            switch (i_VehicleType)
            {
                case eVehicleType.ElectricCar:
                    vehicle = new Car(i_LicenseNumber, (ElectricEngine)engine, wheels);
                    break;

                case eVehicleType.RegularCar:
                    vehicle = new Car(i_LicenseNumber, (FuelEngine)engine, wheels);
                    break;

                case eVehicleType.ElectricMotorcycle:
                    vehicle = new Motorcycle(i_LicenseNumber, (ElectricEngine)engine, wheels);
                    break;

                case eVehicleType.RegularMotorcycle:
                    vehicle = new Motorcycle(i_LicenseNumber, (FuelEngine)engine, wheels);
                    break;

                case eVehicleType.Truck:
                    vehicle = new Truck(i_LicenseNumber, (FuelEngine)engine, wheels);
                    break;

                default:
                    throw new ArgumentException($"Unknown vehicle type: {i_VehicleType}");
            }

            return vehicle;
        }

        /// <summary>
        /// Creates the appropriate engine (electric or fuel) for the vehicle type.
        /// </summary>
        /// <param name="i_VehicleType">The type of vehicle.</param>
        /// <returns>An engine configured for the vehicle type, or null for unknown types.</returns>
        private static Engine createEngine(eVehicleType i_VehicleType)
        {
            Engine vehicleEngine;

            switch (i_VehicleType)
            {
                case eVehicleType.ElectricCar:
                    vehicleEngine = new ElectricEngine(k_MaxBatteryLifeInElectricCar);
                    break;

                case eVehicleType.RegularCar:
                    vehicleEngine = new FuelEngine(k_FuelBasedCarTank, eFuelType.Octan95);
                    break;

                case eVehicleType.ElectricMotorcycle:
                    vehicleEngine = new ElectricEngine(k_MaxBatteryLifeInElectricMotorcycle);
                    break;

                case eVehicleType.RegularMotorcycle:
                    vehicleEngine = new FuelEngine(k_FuelBasedMotorcycleTank, eFuelType.Octan98);
                    break;

                case eVehicleType.Truck:
                    vehicleEngine = new FuelEngine(k_FuelBasedTruckTank, eFuelType.Soler);
                    break;

                default:
                    vehicleEngine = null;
                    break;
            }

            return vehicleEngine;
        }

        /// <summary>
        /// Creates the appropriate wheels array for the vehicle type.
        /// </summary>
        /// <param name="i_VehicleType">The type of vehicle.</param>
        /// <returns>An array of wheels with the correct count and max pressure for the vehicle type.</returns>
        /// <exception cref="ArgumentException">Thrown when the vehicle type is unknown.</exception>
        private static Wheel[] createWheels(eVehicleType i_VehicleType)
        {
            Wheel[] wheels;
            bool vehicleIsCar = i_VehicleType == eVehicleType.ElectricCar 
                || i_VehicleType == eVehicleType.RegularCar;
            bool vehicleIsMotorcycle = i_VehicleType == eVehicleType.RegularMotorcycle
                || i_VehicleType == eVehicleType.ElectricMotorcycle;

            if (vehicleIsCar)
            {
                wheels = new Wheel[(int)eNumberOfWheelsInVehicle.CarNumberWheels];
                
                for (int i = 0; i < wheels.Length; i++)
                {
                    wheels[i] = new Wheel((float)eWheelMaxAirPressure.CarWheel);
                }
            }

            else if (vehicleIsMotorcycle)
            {
                wheels = new Wheel[(int)eNumberOfWheelsInVehicle.MotorcycleNumberWheels];

                for (int i = 0; i < wheels.Length; i++)
                {
                    wheels[i] = new Wheel((float)eWheelMaxAirPressure.MotorcycleWheel);
                }
            }
            else if (i_VehicleType == eVehicleType.Truck)
            {
                wheels = new Wheel[(int)eNumberOfWheelsInVehicle.TruckNumberWheels];

                for (int i = 0; i < wheels.Length; i++)
                {
                    wheels[i] = new Wheel((float)eWheelMaxAirPressure.TruckWheel);
                }
            }
            else
            {
                throw new ArgumentException($"Unknown vehicle type: {i_VehicleType}");
            }

            return wheels;
        }
    }
}