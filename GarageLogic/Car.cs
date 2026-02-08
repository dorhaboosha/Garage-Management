using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace GarageLogic
{
    /// <summary>
    /// Represents a car vehicle. Supports both fuel and electric variants via the engine type.
    /// </summary>
    public class Car : Vehicle
    {
        private eCarColor m_CarColor;
        private eCarNumberOfDoors m_CarNumberDoors;

        /// <summary>
        /// Creates a new car with the given license number, engine, and wheels.
        /// </summary>
        /// <param name="i_LicenseNumber">The vehicle's license plate number.</param>
        /// <param name="i_Engine">The engine (fuel or electric) for the car.</param>
        /// <param name="i_Wheels">The wheels array for the car.</param>
        internal Car(string i_LicenseNumber, Engine i_Engine, Wheel[] i_Wheels)
            : base(i_LicenseNumber, i_Engine, i_Wheels)
        {
        }

        /// <summary>
        /// Sets the car's properties including model, wheels, color, door count, and energy level.
        /// </summary>
        /// <param name="i_ModelName">The model name of the car.</param>
        /// <param name="i_WheelManufacturerName">The manufacturer of the wheels.</param>
        /// <param name="i_CurrentAirPressure">The current air pressure in the wheels.</param>
        /// <param name="i_CarColor">The color of the car.</param>
        /// <param name="i_CarNumberDoors">The number of doors.</param>
        /// <param name="i_CurrentAmountEnergy">The current fuel or battery level.</param>
        public void SetCarProperties(string i_ModelName, string i_WheelManufacturerName, float i_CurrentAirPressure,
            eCarColor i_CarColor, eCarNumberOfDoors i_CarNumberDoors, float i_CurrentAmountEnergy)
        {
            SetVehicleProperties(i_ModelName, i_WheelManufacturerName, i_CurrentAirPressure, i_CurrentAmountEnergy);
            m_CarColor = i_CarColor;
            m_CarNumberDoors = i_CarNumberDoors;
        }

        /// <summary>
        /// Gets the car color as a string.
        /// </summary>
        private string carColor
        {
            get
            {
                return m_CarColor.ToString();
            }
        }

        /// <summary>
        /// Gets the number of doors as an integer.
        /// </summary>
        private int carNumberDoors
        {
            get
            {
                return (int)m_CarNumberDoors;
            }
        }

        /// <summary>
        /// Returns a string representation of the car, including color, door count, and base vehicle details.
        /// </summary>
        /// <returns>Formatted car information.</returns>
        public override string ToString()
        {
            string carInfo = string.Format("Car Color : {0} | Car Number of Doors : {1}\n{2}",
                carColor, carNumberDoors, base.ToString());

            return carInfo;
        }
    }
}