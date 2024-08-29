using GarageLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI
{
    public class GarageManagerUI
    {
        private readonly static GarageManagerLogic sr_GarageManager = new GarageManagerLogic();

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

            catch (Exception exception) 
            {
                Console.WriteLine(string.Format("\n{0}", exception.Message));
                Console.WriteLine("We move you now to the main menu.\n");
            }
        }

        private static void showLicenses()
        {
            MassageSender.SendDisplayLicenseNumbersMessage();
            int userChoice = InputGetter.GetUserDisplyFilter();

            try
            {
                if (userChoice == 0)
                {
                    List<RegisteredVehicle> vehiclesinGarage = sr_GarageManager.VehiclesInGarage;
                    int numberOfVehicle = 1;
                    Console.WriteLine();
                    
                    foreach (RegisteredVehicle registeredVehicle in vehiclesinGarage)
                    {
                        Console.WriteLine("{0}. {1}", numberOfVehicle, registeredVehicle.Vehicle.LicenseNumber);
                        numberOfVehicle++;
                    }

                    Console.WriteLine();
                }
                else
                {
                    eVehicleStatusInGarage statusFilter = (eVehicleStatusInGarage)userChoice;
                    List<RegisteredVehicle> vehiclesinGarageByStatus = sr_GarageManager.GetVehiclesByStatus(statusFilter);
                    int numberOfVehicle = 1;
                    Console.WriteLine();

                    foreach (RegisteredVehicle registeredVehicle in vehiclesinGarageByStatus)
                    {
                        Console.WriteLine("{0}. {1}", numberOfVehicle, registeredVehicle.Vehicle.LicenseNumber);
                        numberOfVehicle++;
                    }

                    Console.WriteLine();
                }
            }
            catch (Exception exception) 
            {
                Console.WriteLine(string.Format("\n{0}", exception.Message));
                Console.WriteLine("We move you now to the main menu.\n");
            }
        }

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

            catch (Exception exception)
            {
                Console.WriteLine(string.Format("\n{0}", exception.Message));
                Console.WriteLine("We move you now to the main menu.\n");
            }
        }

        private static void inflateVehicleWheels()
        {
            MassageSender.SendInflateWheelsMessage();
            string UserLicenseNumber = InputGetter.GetStringPropertyFromUser();

            try
            {
                sr_GarageManager.InflateVehicleWheelsToMax(UserLicenseNumber);
                MassageSender.SendSuccessInflateVehicleWheelsMessage();
            }

            catch (Exception exception)
            {
                Console.WriteLine(string.Format("\n{0}", exception.Message));
                Console.WriteLine("We move you now to the main menu.\n");
            }
        }

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

            catch (Exception exception)
            {
                Console.WriteLine(string.Format("\n{0}", exception.Message));
                Console.WriteLine("We move you now to the main menu.\n");
            }
        }

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

            catch (Exception exception)
            {
                Console.WriteLine(string.Format("\n{0}", exception.Message));
                Console.WriteLine("We move you now to the main menu.\n");
            }
        }

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

            catch (Exception exception) 
            {
                Console.WriteLine(string.Format("\n{0}", exception.Message));
                Console.WriteLine("We move you now to the main menu.\n");
            }
        }

        private static Vehicle generateVehicle(string i_LicenseNumber)
        {
            MassageSender.SendNewVehicleInserationMessage();
            eVehicleType vehicleType = InputGetter.GetUserOptionToVehicle();
            Vehicle userVehicleInseration = sr_GarageManager.CreateVehicle(i_LicenseNumber, vehicleType);

            Console.WriteLine("\nPlease write the model name of the vehicle:");
            string vehicleModelName = InputGetter.GetStringPropertyFromUser();
            
            Console.WriteLine("\nPlease write the wheel manufacturer name of the vehicle:");
            string vehicleWheelManufacturerName = InputGetter.GetStringPropertyFromUser();
            
            Console.WriteLine("\nPlease write the air prussure in the wheels of the vehicle:");
            float vehicleWheelAirPressure = InputGetter.GetFloatPropertyFromUser();

            float vehicleCurrentEnergy;

            if (userVehicleInseration.Engine is FuelEngine)
            {
                Console.WriteLine("\nPlease write the current amount of fuel in vehicle:");
                vehicleCurrentEnergy = InputGetter.GetFloatPropertyFromUser();
            }
            else 
            {
                Console.WriteLine("\nPlease write the current amount of battery in vehicle:");
                vehicleCurrentEnergy = InputGetter.GetFloatPropertyFromUser();
            }

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
            else
            {
                Truck userTruck = (Truck)userVehicleInseration;

                Console.WriteLine("\nPlease enter 'Y' if the truck contain dangerous materials and 'N' if not:");
                bool containDangerousMaterials = InputGetter.GetBoolPropertyFromUser();

                Console.WriteLine("\nPlease write the cargo tank volume of the truck:");
                float cargoTankVolume = InputGetter.GetFloatPropertyFromUser();

                userTruck.SetTruckProperties(vehicleModelName, vehicleWheelManufacturerName, vehicleWheelAirPressure,
                    containDangerousMaterials, cargoTankVolume, vehicleCurrentEnergy);
            }

            return userVehicleInseration;
        }

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
