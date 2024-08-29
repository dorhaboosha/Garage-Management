using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageLogic
{
    internal static class VehicleCreator
    {
        private const float k_MaxBatteryLifeInElectricCar = 210;
        private const float k_FuelBasedCarleTank = 45;
        private const float k_MaxBatteryLifeInElectricMotorcycle = 150;
        private const float k_FuelBasedMotorcycleTank = (float)5.5;
        private const float k_FuelBasedTruckleTank = 120;

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
                    vehicle = new Car(i_LicenseNumber, engine as ElectricEngine, wheels);
                    break;
                
                case eVehicleType.RegularCar:
                    vehicle = new Car(i_LicenseNumber, engine as FuelEngine, wheels);
                    break;

                case eVehicleType.ElectricMotorcycle:
                    vehicle = new Motorcycle(i_LicenseNumber, engine as ElectricEngine, wheels);
                    break;

                case eVehicleType.RegularMotorcycle:
                    vehicle = new Motorcycle(i_LicenseNumber, engine as FuelEngine, wheels);
                    break;

                case eVehicleType.Truck:
                    vehicle = new Truck(i_LicenseNumber, engine as FuelEngine, wheels);
                    break;

                default:
                    vehicle = null;
                    break;
            }

            if (vehicle == null)
            {
                throw new ArgumentException("The system failed to create the vehicle.\n" +
                    "Please check that the data you enter into the system is correct and try again.");
            }
            else
            {
                return vehicle;
            }
        }

        private static Engine createEngine(eVehicleType i_VehicleType)
        {
            Engine vehicleEngine;

            switch (i_VehicleType)
            {
                case eVehicleType.ElectricCar:
                    vehicleEngine = new ElectricEngine(k_MaxBatteryLifeInElectricCar);
                    break;

                case eVehicleType.RegularCar:
                    vehicleEngine = new FuelEngine(k_FuelBasedCarleTank, eFuelType.Octan95);
                    break;

                case eVehicleType.ElectricMotorcycle:
                    vehicleEngine = new ElectricEngine(k_MaxBatteryLifeInElectricMotorcycle);
                    break;

                case eVehicleType.RegularMotorcycle:
                    vehicleEngine = new FuelEngine(k_FuelBasedMotorcycleTank, eFuelType.Octan98);
                    break;

                case eVehicleType.Truck:
                    vehicleEngine = new FuelEngine(k_FuelBasedTruckleTank, eFuelType.Soler);
                    break;

                default:
                    vehicleEngine = null;
                    break;
            }

            return vehicleEngine;
        }

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

            else if(vehicleIsMotorcycle)
            {
                wheels = new Wheel[(int)eNumberOfWheelsInVehicle.MotorcycleNumberWheels];

                for (int i = 0; i < wheels.Length; i++)
                {
                    wheels[i] = new Wheel((float)eWheelMaxAirPressure.MotorcycleWheel);
                }
            }
            else 
            {
                wheels = new Wheel[(int)eNumberOfWheelsInVehicle.TruckNumberWheels];

                for (int i = 0; i < wheels.Length; i++)
                {
                    wheels[i] = new Wheel((float)eWheelMaxAirPressure.TruckWheel);
                }
            }

            return wheels;
        }
    }
}