using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI
{
    internal static class MassageSender
    {
        internal static void SendOpenMessage()
        {
            Console.WriteLine("Welcome to Garage Managment System!");
            Console.WriteLine("Here is the operation's menu (choose 1 option):");
            
            string[] menuOperationOption = new string[8] {"Exit the system." , "Insert new vehicle to system.",
            "Show all license numbers with option to filter.", "Change vehicle status in the system.", 
                "Inflate vehicle's wheels to maxium air pressure.","Refuel fuel-based vehicle.",
                "Recharge electric-based vehicle.", "Show vehicle's information."};

            for (int i = 0; i < menuOperationOption.Length; i++)
            {
                Console.WriteLine("{0}. {1}", i, menuOperationOption[i]);
            }
        }

        internal static void SendShowPropertiesMessage()
        {
            Console.WriteLine("\nYou chose to show the properties of a vehicle.");
            Console.WriteLine("Please enter the license number of the vehicle and then press enter:");
        }

        internal static void SendInsertVehicleMessage()
        {
            Console.WriteLine("\nYou chose to insert a vehicle to the system.");
            Console.WriteLine("Please enter the license number of the vehicle and then press enter:");
        }

        internal static void SendVehicleAlreadyInGarageMessage()
        {
            Console.WriteLine("\nThe system already has the information of this vehicle.");
            Console.WriteLine("Therefore, we will put the vehicle in repair at the garage.");
            Console.WriteLine("We move you now to the main menu.\n");
        }

        internal static void SendNewVehicleInserationMessage()
        {
            Console.WriteLine("\nLet's insert the vehicle to the system.");
            Console.WriteLine("Here is the vehicle's Menu (choose 1 vehicle's option):");
            
            string[] menuVehiclesOption = new string[5] {"Regular Car." , "Electric Car.", "Regular Motorcycle.",
                "Electric Motorcycle.", "Truck."};

            for (int i = 0; i < menuVehiclesOption.Length; i++)
            {
                Console.WriteLine("{0}. {1}", i+1, menuVehiclesOption[i]);
            }
        }

        internal static void SendCarColorOptionMessage()
        {
            Console.WriteLine("\nHere is the car's color options (choose 1 option):");
            
            string[] carColorOptions = new string[4] {"Yellow." , "White.", "Red.", "Black."};

            for (int i = 0; i < carColorOptions.Length; i++)
            {
                Console.WriteLine("{0}. {1}", i + 1, carColorOptions[i]);
            }
        }

        internal static void SendCarNumberOfDoorsOptionMessage()
        {
            Console.WriteLine("\nHere is the car's number of doors options (choose 1 option):");
            
            string[] carColorOptions = new string[4] { "2 Doors.", "3 Doors.", "4 Doors.", "5 Doors." };

            for (int i = 0; i < carColorOptions.Length; i++)
            {
                Console.WriteLine("{0}. {1}", i + 1, carColorOptions[i]);
            }
        }

        internal static void SendMotorcycleLicenseTypeOptionMessage()
        {
            Console.WriteLine("\nHere is the motorcycle's license type options (choose 1 option):");
            
            string[] carColorOptions = new string[4] { "A.", "A1.", "AA.", "B1." };

            for (int i = 0; i < carColorOptions.Length; i++)
            {
                Console.WriteLine("{0}. {1}", i + 1, carColorOptions[i]);
            }
        }

        internal static void SendOwnerVehicleInfoMessage()
        {
            Console.WriteLine("\nNow let take the owner information.");
            Console.WriteLine("Please enter the following data:");
        }

        internal static void SendSuccessRegisterVehicleMessage()
        {
            Console.WriteLine("\nThe vehicle registered in the system.");
            Console.WriteLine("We move you now to the main menu.\n");
        }

        internal static void SendDisplayLicenseNumbersMessage()
        {
            Console.WriteLine("\nYou chose to display the license number of vehicles in the garage.");
            Console.WriteLine("Here is the filter display menu (choose 1 option):");
            
            string[] menuOperationOption = new string[4] {"Show all License number of vehicles." ,
                "Show all License number of vehicles that in repair.", "Show all License number of vehicles that repaired.",
                "Show all License number of vehicles that payed for the repair."};

            for (int i = 0; i < menuOperationOption.Length; i++)
            {
                Console.WriteLine("{0}. {1}", i, menuOperationOption[i]);
            }

        }

        internal static void SendChangeStatusVehicleMessage()
        {
            Console.WriteLine("\nYou chose to change the status of the vehicle.");
            Console.WriteLine("Please enter the license number of the vehicle and then press enter:");
        }

        internal static void SendWhichNewStatusMessage()
        {
            Console.WriteLine("\nHere is the vehicle status menu (choose 1 option):");
            
            string[] menuOperationOption = new string[3] {"In Repair." , "Repaired.", "Payed for."};

            for (int i = 0; i < menuOperationOption.Length; i++)
            {
                Console.WriteLine("{0}. {1}", i + 1, menuOperationOption[i]);
            }

        }

        internal static void SendInflateWheelsMessage()
        {
            Console.WriteLine("\nYou chose to inflate the wheels of the vehicle.");
            Console.WriteLine("Please enter the license number of the vehicle and then press enter:");
        }

        internal static void SendSuccessChangeVehicleStatusMessage()
        {
            Console.WriteLine("\nThe vehicle status changed successfully.");
            Console.WriteLine("We move you now to the main menu.\n");
        }

        internal static void SendSuccessInflateVehicleWheelsMessage()
        {
            Console.WriteLine("\nThe inflation of the vehicle's wheels succeed.");
            Console.WriteLine("We move you now to the main menu.\n");
        }

        internal static void SendRefulingMessage()
        {
            Console.WriteLine("\nYou chose to refuel the vehicle.");
            Console.WriteLine("Please enter the license number of the vehicle and then press enter:");
        }

        internal static void SendRechargingMessage()
        {
            Console.WriteLine("\nYou chose to recharge the vehicle.");
            Console.WriteLine("Please enter the license number of the vehicle and then press enter:");
        }

        internal static void SendWhichFuelTypeMessage()
        {
            Console.WriteLine("\nHere is the Vehicle's Fuel type menu (choose 1 option):");
            
            string[] menuOperationOption = new string[4] { "Soler.", "Octan95.", "Octan96.", "Octan98." };

            for (int i = 0; i < menuOperationOption.Length; i++)
            {
                Console.WriteLine("{0}. {1}", i + 1, menuOperationOption[i]);
            }

        }

        internal static void SendSuccessRefuelingVehicleMessage()
        {
            Console.WriteLine("\nThe refueling of the vehicle succeed.");
            Console.WriteLine("We move you now to the main menu.\n");
        }

        internal static void SendSuccessRechargingVehicleMessage()
        {
            Console.WriteLine("\nThe recharging of the vehicle succeed.");
            Console.WriteLine("We move you now to the main menu.\n");
        }
    }
}