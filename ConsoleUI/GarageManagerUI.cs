using GarageLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI
{
    /// <summary>
    /// Console-based user interface for the garage management system.
    /// Handles user interaction, menu navigation, and delegates operations to the garage logic layer.
    /// </summary>
    public class GarageManagerUI
    {
        private readonly static GarageManagerLogic sr_GarageManager = new GarageManagerLogic();

        /// <summary>
        /// Starts the main management loop. Displays the menu and processes user choices until the user exits.
        /// </summary>
        public void StartManagment()
        {
            bool garageStillWorking = true;

            while (garageStillWorking)
            {
                MassageSender.SendOpenMessage();
                eGarageMenuOperationOption userChoice = InputGetter.GetUserOptionToOperate();

                switch (userChoice)
                {
                    case eGarageMenuOperationOption.ExitProgram:
                        garageStillWorking = !garageStillWorking;
                        break;
                    
                    case eGarageMenuOperationOption.InsertNewVehicle:
                        insertNewVehicle();
                        break;

                    case eGarageMenuOperationOption.ShowAllVehicles:
                        showLicenses();
                        break;

                    case eGarageMenuOperationOption.ChangeVehicleStatus:
                        changeVehicleStatus();
                        break;

                    case eGarageMenuOperationOption.InflateVehicleWheels:
                        inflateVehicleWheels();
                        break;

                    case eGarageMenuOperationOption.RefuelVehicle:
                        refuelVehicle();
                        break;

                    case eGarageMenuOperationOption.RechargeVehicle:
                        rechargeVehicle();
                        break;

                    case eGarageMenuOperationOption.ShowVehicleInformation:
                        showVehicleInformation();
                        break;
                }
            }
        }

        /// <summary>
        /// Prompts for a license number and either registers a new vehicle or updates the status of an existing one.
        /// </summary>
        private static void insertNewVehicle()
        {
            MassageSender.SendInsertVehicleMessage();
            string UserLicenseNumber = InputGetter.GetStringPropertyFromUser();

            try
            {
                if (sr_GarageManager.ContainVehicle(UserLicenseNumber))
                {
                    MassageSender.SendVehicleAlreadyInGarageMessage();
                    sr_GarageManager.ChangeVehicleStatus(UserLicenseNumber, eVehicleStatusInGarage.InRepair);
                }
                else
                {
                    Vehicle userVehicle = generateVehicle(UserLicenseNumber);
                    GarageTicket userTicket = generateGarageTicket();

                    sr_GarageManager.RegisterVehicleInGarage(userVehicle, userTicket);
                    MassageSender.SendSuccessRegisterVehicleMessage();
                }
            }

            catch (ArgumentException exception)
            {
                handleOperationError(exception);
            }
            catch (InvalidOperationException exception)
            {
                handleOperationError(exception);
            }
            catch (ValueOutOfRangeException exception)
            {
                handleOperationError(exception);
            }
        }

        /// <summary>
        /// Displays vehicle license numbers, optionally filtered by status (all vehicles, in repair, repaired, or paid).
        /// </summary>
        private static void showLicenses()
        {
            MassageSender.SendDisplayLicenseNumbersMessage();
            int userChoice = InputGetter.GetUserDisplyFilter();

            try
            {
                IEnumerable<RegisteredVehicle> vehicles;
                if (userChoice == 0)
                {
                    vehicles = sr_GarageManager.VehiclesInGarage;
                }
                else
                {
                    eVehicleStatusInGarage statusFilter = (eVehicleStatusInGarage)userChoice;
                    vehicles = sr_GarageManager.GetVehiclesByStatus(statusFilter);
                }

                Console.WriteLine();
                if (!vehicles.Any())
                {
                    Console.WriteLine(userChoice == 0
                        ? "There are no vehicles in the garage to show."
                        : "There are no vehicles in the garage with this status.");
                }
                else
                {
                    displayLicenseNumbers(vehicles);
                }
                Console.WriteLine();
            }
            catch (ArgumentException exception)
            {
                handleOperationError(exception);
            }
        }

        /// <summary>
        /// Displays the exception message and returns the user to the main menu.
        /// </summary>
        private static void handleOperationError(Exception i_Exception)
        {
            Console.WriteLine(string.Format("\n{0}", i_Exception.Message));
            Console.WriteLine("We move you now to the main menu.\n");
        }

        /// <summary>
        /// Displays license numbers for a collection of registered vehicles.
        /// </summary>
        private static void displayLicenseNumbers(IEnumerable<RegisteredVehicle> vehicles)
        {
            int numberOfVehicle = 1;
            foreach (RegisteredVehicle registeredVehicle in vehicles)
            {
                Console.WriteLine("{0}. {1}", numberOfVehicle, registeredVehicle.Vehicle.LicenseNumber);
                numberOfVehicle++;
            }
        }

        /// <summary>
        /// Changes the status of a vehicle in the garage (e.g., from "In Repair" to "Repaired").
        /// </summary>
        private static void changeVehicleStatus()
        {
            MassageSender.SendChangeStatusVehicleMessage();
            string UserLicenseNumber = InputGetter.GetStringPropertyFromUser();
            MassageSender.SendWhichNewStatusMessage();
            eVehicleStatusInGarage newVehicleStatus = InputGetter.GetNewVehicleStatusFromUser();

            try
            {
                sr_GarageManager.ChangeVehicleStatus(UserLicenseNumber, newVehicleStatus);
                MassageSender.SendSuccessChangeVehicleStatusMessage();
            }

            catch (ArgumentException exception)
            {
                handleOperationError(exception);
            }
            catch (InvalidOperationException exception)
            {
                handleOperationError(exception);
            }
        }

        /// <summary>
        /// Inflates all wheels of a vehicle to their maximum pressure.
        /// </summary>
        private static void inflateVehicleWheels()
        {
            MassageSender.SendInflateWheelsMessage();
            string UserLicenseNumber = InputGetter.GetStringPropertyFromUser();

            try
            {
                sr_GarageManager.InflateVehicleWheelsToMax(UserLicenseNumber);
                MassageSender.SendSuccessInflateVehicleWheelsMessage();
            }

            catch (ArgumentException exception)
            {
                handleOperationError(exception);
            }
            catch (InvalidOperationException exception)
            {
                handleOperationError(exception);
            }
            catch (ValueOutOfRangeException exception)
            {
                handleOperationError(exception);
            }
        }

        /// <summary>
        /// Refuels a fuel-powered vehicle with the specified amount and fuel type.
        /// </summary>
        private static void refuelVehicle()
        {
            MassageSender.SendRefulingMessage();
            string UserLicenseNumber = InputGetter.GetStringPropertyFromUser();
            Console.WriteLine("Please enter the amount of fuel you want to refuel in the vehicle:");
            float fuelAmount = InputGetter.GetFloatPropertyFromUser();
            MassageSender.SendWhichFuelTypeMessage();
            eFuelType fuelType = InputGetter.GetUserVehicleFuelType();

            try
            {
                sr_GarageManager.Refueling(UserLicenseNumber, fuelAmount, fuelType);
                MassageSender.SendSuccessRefuelingVehicleMessage();
            }

            catch (ArgumentException exception)
            {
                Console.WriteLine(string.Format("\n{0}", exception.Message));
                Console.WriteLine("We move you now to the main menu.\n");
            }
            catch (InvalidOperationException exception)
            {
                Console.WriteLine(string.Format("\n{0}", exception.Message));
                Console.WriteLine("We move you now to the main menu.\n");
            }
            catch (ValueOutOfRangeException exception)
            {
                Console.WriteLine(string.Format("\n{0}", exception.Message));
                Console.WriteLine("We move you now to the main menu.\n");
            }
        }

        /// <summary>
        /// Recharges an electric vehicle's battery for the specified number of minutes.
        /// </summary>
        private static void rechargeVehicle()
        {
            MassageSender.SendRechargingMessage();
            string UserLicenseNumber = InputGetter.GetStringPropertyFromUser();
            Console.WriteLine("Please enter the amount of minutes you want to recharge the vehicle:");
            float chargeAmount = InputGetter.GetFloatPropertyFromUser();

            try
            {
                sr_GarageManager.Recharge(UserLicenseNumber, chargeAmount);
                MassageSender.SendSuccessRechargingVehicleMessage();
            }

            catch (ArgumentException exception)
            {
                handleOperationError(exception);
            }
            catch (InvalidOperationException exception)
            {
                handleOperationError(exception);
            }
            catch (ValueOutOfRangeException exception)
            {
                handleOperationError(exception);
            }
        }

        /// <summary>
        /// Displays full details of a vehicle in the garage by license number.
        /// </summary>
        private static void showVehicleInformation()
        {
            MassageSender.SendShowPropertiesMessage();
            string UserLicenseNumber = InputGetter.GetStringPropertyFromUser();

            try 
            {
                string printProperties = string.Format("\n{0}\n",
                    sr_GarageManager.GetVehicleByLicenseNumber(UserLicenseNumber).ToString());
                Console.WriteLine(printProperties);
            }

            catch (ArgumentException exception)
            {
                handleOperationError(exception);
            }
            catch (InvalidOperationException exception)
            {
                handleOperationError(exception);
            }
        }

        /// <summary>
        /// Prompts the user for vehicle details and creates a new vehicle instance.
        /// Handles different vehicle types (car, motorcycle, truck) with type-specific properties.
        /// </summary>
        /// <param name="i_LicenseNumber">The license plate number for the vehicle.</param>
        /// <returns>A fully configured vehicle ready for registration.</returns>
        private static Vehicle generateVehicle(string i_LicenseNumber)
        {
            MassageSender.SendNewVehicleInserationMessage();
            eVehicleType vehicleType = InputGetter.GetUserOptionToVehicle();
            Vehicle userVehicleInseration = sr_GarageManager.CreateVehicle(i_LicenseNumber, vehicleType);

            Console.WriteLine("\nPlease write the model name of the vehicle:");
            string vehicleModelName = InputGetter.GetStringPropertyFromUser();
            
            Console.WriteLine("\nPlease write the wheel manufacturer name of the vehicle:");
            string vehicleWheelManufacturerName = InputGetter.GetStringPropertyFromUser();
            
            Console.WriteLine("\nPlease write the air pressure in the wheels of the vehicle:");
            float vehicleWheelAirPressure = InputGetter.GetFloatPropertyFromUser();

            string energyPrompt = userVehicleInseration.Engine is FuelEngine
                ? "\nPlease write the current amount of fuel in vehicle:"
                : "\nPlease write the current amount of battery in vehicle:";
            Console.WriteLine(energyPrompt);
            float vehicleCurrentEnergy = InputGetter.GetFloatPropertyFromUser();

            if (userVehicleInseration is Car userCar)
            {
                MassageSender.SendCarColorOptionMessage();
                eCarColor carColor = InputGetter.GetUserCarColor();

                MassageSender.SendCarNumberOfDoorsOptionMessage();
                eCarNumberOfDoors carNumberDoors = InputGetter.GetUserCarNumberDoors();

                userCar.SetCarProperties(vehicleModelName, vehicleWheelManufacturerName, 
                    vehicleWheelAirPressure, carColor, carNumberDoors, vehicleCurrentEnergy);

            }

            else if (userVehicleInseration is Motorcycle userMotorcycle)
            {
                MassageSender.SendMotorcycleLicenseTypeOptionMessage();
                eMotorcycleLicenseType motorcycleLicenseType = InputGetter.GetUserMotorcycleLicenseType();

                Console.WriteLine("\nPlease write the engine volume of the motorcycle:");
                int engineVolume = InputGetter.GetIntPropertyFromUser();

                userMotorcycle.SetMotorcycleProperties(vehicleModelName, vehicleWheelManufacturerName, vehicleWheelAirPressure,
                    motorcycleLicenseType, engineVolume, vehicleCurrentEnergy);
            }
            else if (userVehicleInseration is Truck userTruck)
            {
                Console.WriteLine("\nPlease enter 'Y' if the truck contain dangerous materials and 'N' if not:");
                bool containDangerousMaterials = InputGetter.GetBoolPropertyFromUser();

                Console.WriteLine("\nPlease write the cargo tank volume of the truck:");
                float cargoTankVolume = InputGetter.GetFloatPropertyFromUser();

                userTruck.SetTruckProperties(vehicleModelName, vehicleWheelManufacturerName, vehicleWheelAirPressure,
                    containDangerousMaterials, cargoTankVolume, vehicleCurrentEnergy);
            }
            else
            {
                throw new ArgumentException($"Unrecognized vehicle type: {userVehicleInseration.GetType().Name}");
            }

            return userVehicleInseration;
        }

        /// <summary>
        /// Prompts for owner information and creates a garage ticket for the vehicle.
        /// </summary>
        /// <returns>A garage ticket with owner name and phone number.</returns>
        private static GarageTicket generateGarageTicket()
        {
            MassageSender.SendOwnerVehicleInfoMessage();
            Console.WriteLine("\nPlease enter the name of vehicle's owner:");
            string ownerVehicleName = InputGetter.GetOwnerNameFromUser();

            Console.WriteLine("\nPlease enter the phone number of vehicle's owner:");
            string ownerPhoneNumber = InputGetter.GetOwnerPhoneNumberFromUser();

            GarageTicket garageTicket = new GarageTicket();
            garageTicket.SetOwnerInfoProperties(ownerVehicleName, ownerPhoneNumber);

            return garageTicket;
        }
    }
}
