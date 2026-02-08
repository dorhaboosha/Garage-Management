using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI
{
    /// <summary>
    /// Sends user-facing messages to the console. Handles all menu displays, prompts, and status feedback for the garage UI.
    /// </summary>
    internal static class MassageSender
    {
        /// <summary>
        /// Displays the welcome message and main operation menu (options 0-7).
        /// </summary>
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

        /// <summary>
        /// Prompts the user to enter a license number to view vehicle properties.
        /// </summary>
        internal static void SendShowPropertiesMessage()
        {
            Console.WriteLine("\nYou chose to show the properties of a vehicle.");
            Console.WriteLine("Please enter the license number of the vehicle and then press enter:");
        }

        /// <summary>
        /// Prompts the user to enter a license number for vehicle insertion.
        /// </summary>
        internal static void SendInsertVehicleMessage()
        {
            Console.WriteLine("\nYou chose to insert a vehicle to the system.");
            Console.WriteLine("Please enter the license number of the vehicle and then press enter:");
        }

        /// <summary>
        /// Informs the user that the vehicle already exists in the garage and will be set to "In Repair".
        /// </summary>
        internal static void SendVehicleAlreadyInGarageMessage()
        {
            Console.WriteLine("\nThe system already has the information of this vehicle.");
            Console.WriteLine("Therefore, we will put the vehicle in repair at the garage.");
            Console.WriteLine("We move you now to the main menu.\n");
        }

        /// <summary>
        /// Displays the vehicle type selection menu (car, motorcycle, truck variants).
        /// </summary>
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

        /// <summary>
        /// Displays the car color options (Yellow, White, Black, Red).
        /// </summary>
        internal static void SendCarColorOptionMessage()
        {
            Console.WriteLine("\nHere is the car's color options (choose 1 option):");
            
            string[] carColorOptions = new string[4] {"Yellow." , "White.", "Black.", "Red."};

            for (int i = 0; i < carColorOptions.Length; i++)
            {
                Console.WriteLine("{0}. {1}", i + 1, carColorOptions[i]);
            }
        }

        /// <summary>
        /// Displays the car door count options (2-5 doors).
        /// </summary>
        internal static void SendCarNumberOfDoorsOptionMessage()
        {
            Console.WriteLine("\nHere is the car's number of doors options (choose 1 option):");
            
            string[] carColorOptions = new string[4] { "2 Doors.", "3 Doors.", "4 Doors.", "5 Doors." };

            for (int i = 0; i < carColorOptions.Length; i++)
            {
                Console.WriteLine("{0}. {1}", i + 1, carColorOptions[i]);
            }
        }

        /// <summary>
        /// Displays the motorcycle license type options (A, A1, AA, B1).
        /// </summary>
        internal static void SendMotorcycleLicenseTypeOptionMessage()
        {
            Console.WriteLine("\nHere is the motorcycle's license type options (choose 1 option):");
            
            string[] carColorOptions = new string[4] { "A.", "A1.", "AA.", "B1." };

            for (int i = 0; i < carColorOptions.Length; i++)
            {
                Console.WriteLine("{0}. {1}", i + 1, carColorOptions[i]);
            }
        }

        /// <summary>
        /// Prompts the user to enter owner information (name and phone).
        /// </summary>
        internal static void SendOwnerVehicleInfoMessage()
        {
            Console.WriteLine("\nNow let take the owner information.");
            Console.WriteLine("Please enter the following data:");
        }

        /// <summary>
        /// Confirms successful vehicle registration and returns to main menu.
        /// </summary>
        internal static void SendSuccessRegisterVehicleMessage()
        {
            Console.WriteLine("\nThe vehicle registered in the system.");
            Console.WriteLine("We move you now to the main menu.\n");
        }

        /// <summary>
        /// Displays the license number filter menu (all, in repair, repaired, paid).
        /// </summary>
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

        /// <summary>
        /// Prompts the user to enter a license number to change vehicle status.
        /// </summary>
        internal static void SendChangeStatusVehicleMessage()
        {
            Console.WriteLine("\nYou chose to change the status of the vehicle.");
            Console.WriteLine("Please enter the license number of the vehicle and then press enter:");
        }

        /// <summary>
        /// Displays the vehicle status options (In Repair, Repaired, Paid for).
        /// </summary>
        internal static void SendWhichNewStatusMessage()
        {
            Console.WriteLine("\nHere is the vehicle status menu (choose 1 option):");
            
            string[] menuOperationOption = new string[3] {"In Repair." , "Repaired.", "Payed for."};

            for (int i = 0; i < menuOperationOption.Length; i++)
            {
                Console.WriteLine("{0}. {1}", i + 1, menuOperationOption[i]);
            }

        }

        /// <summary>
        /// Prompts the user to enter a license number to inflate vehicle wheels.
        /// </summary>
        internal static void SendInflateWheelsMessage()
        {
            Console.WriteLine("\nYou chose to inflate the wheels of the vehicle.");
            Console.WriteLine("Please enter the license number of the vehicle and then press enter:");
        }

        /// <summary>
        /// Confirms successful status change and returns to main menu.
        /// </summary>
        internal static void SendSuccessChangeVehicleStatusMessage()
        {
            Console.WriteLine("\nThe vehicle status changed successfully.");
            Console.WriteLine("We move you now to the main menu.\n");
        }

        /// <summary>
        /// Confirms successful wheel inflation and returns to main menu.
        /// </summary>
        internal static void SendSuccessInflateVehicleWheelsMessage()
        {
            Console.WriteLine("\nThe inflation of the vehicle's wheels succeed.");
            Console.WriteLine("We move you now to the main menu.\n");
        }

        /// <summary>
        /// Prompts the user to enter a license number for refueling.
        /// </summary>
        internal static void SendRefulingMessage()
        {
            Console.WriteLine("\nYou chose to refuel the vehicle.");
            Console.WriteLine("Please enter the license number of the vehicle and then press enter:");
        }

        /// <summary>
        /// Prompts the user to enter a license number for recharging.
        /// </summary>
        internal static void SendRechargingMessage()
        {
            Console.WriteLine("\nYou chose to recharge the vehicle.");
            Console.WriteLine("Please enter the license number of the vehicle and then press enter:");
        }

        /// <summary>
        /// Displays the fuel type options (Soler, Octan95, Octan96, Octan98).
        /// </summary>
        internal static void SendWhichFuelTypeMessage()
        {
            Console.WriteLine("\nHere is the Vehicle's Fuel type menu (choose 1 option):");
            
            string[] menuOperationOption = new string[4] { "Soler.", "Octan95.", "Octan96.", "Octan98." };

            for (int i = 0; i < menuOperationOption.Length; i++)
            {
                Console.WriteLine("{0}. {1}", i + 1, menuOperationOption[i]);
            }

        }

        /// <summary>
        /// Confirms successful refueling and returns to main menu.
        /// </summary>
        internal static void SendSuccessRefuelingVehicleMessage()
        {
            Console.WriteLine("\nThe refueling of the vehicle succeed.");
            Console.WriteLine("We move you now to the main menu.\n");
        }

        /// <summary>
        /// Confirms successful recharging and returns to main menu.
        /// </summary>
        internal static void SendSuccessRechargingVehicleMessage()
        {
            Console.WriteLine("\nThe recharging of the vehicle succeed.");
            Console.WriteLine("We move you now to the main menu.\n");
        }
    }
}