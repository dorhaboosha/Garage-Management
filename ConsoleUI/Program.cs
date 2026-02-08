using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI
{
    /// <summary>
    /// Entry point for the Garage Management System console application.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Creates the garage manager UI and starts the main management loop.
        /// </summary>
        public static void Main()
        {
            GarageManagerUI garageManager = new GarageManagerUI();

            garageManager.StartManagment();
        }
    }
}