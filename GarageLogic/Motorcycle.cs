using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageLogic
{
    /// <summary>
    /// Represents a motorcycle vehicle. Supports both fuel and electric variants via the engine type.
    /// </summary>
    public class Motorcycle : Vehicle
    {
        private eMotorcycleLicenseType m_LicenseType;
        private int m_EngineVolume;

        /// <summary>
        /// Creates a new motorcycle with the given license number, engine, and wheels.
        /// </summary>
        /// <param name="i_LicenseNumber">The vehicle's license plate number.</param>
        /// <param name="i_Engine">The engine (fuel or electric) for the motorcycle.</param>
        /// <param name="i_Wheels">The wheels array for the motorcycle.</param>
        internal Motorcycle(string i_LicenseNumber, Engine i_Engine, Wheel[] i_Wheels)
            : base(i_LicenseNumber, i_Engine, i_Wheels)
        {
        }

        /// <summary>
        /// Sets the motorcycle's properties including model, wheels, license type, engine volume, and energy level.
        /// </summary>
        /// <param name="i_ModelName">The model name of the motorcycle.</param>
        /// <param name="i_WheelManufacturerName">The manufacturer of the wheels.</param>
        /// <param name="i_CurrentAirPressure">The current air pressure in the wheels.</param>
        /// <param name="i_LicenseType">The required license type for the motorcycle.</param>
        /// <param name="i_EngineVolume">The engine volume in cubic centimeters.</param>
        /// <param name="i_CurrentAmountEnergy">The current fuel or battery level.</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when engine volume is negative.</exception>
        public void SetMotorcycleProperties(string i_ModelName, string i_WheelManufacturerName, float i_CurrentAirPressure,
            eMotorcycleLicenseType i_LicenseType, int i_EngineVolume, float i_CurrentAmountEnergy)
        {
            if (i_EngineVolume < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(i_EngineVolume), "Engine volume cannot be negative.");
            }

            SetVehicleProperties(i_ModelName, i_WheelManufacturerName, i_CurrentAirPressure, i_CurrentAmountEnergy);
            m_EngineVolume = i_EngineVolume;
            m_LicenseType = i_LicenseType;
        }

        /// <summary>
        /// Gets the license type as a string.
        /// </summary>
        private string licenseType
        {
            get 
            {
                return m_LicenseType.ToString();
            }
        }

        /// <summary>
        /// Gets the engine volume in cubic centimeters.
        /// </summary>
        private int engineVolume
        {
            get 
            {
                return m_EngineVolume;
            }
        }

        /// <summary>
        /// Returns a string representation of the motorcycle, including license type, engine volume, and base vehicle details.
        /// </summary>
        /// <returns>Formatted motorcycle information.</returns>
        public override string ToString()
        {
            string motorcycleInfo = string.Format("Motorcycle License Type : {0} | Motorcycle Engine Volume : {1}\n{2}",
                licenseType, engineVolume, base.ToString());

            return motorcycleInfo;
        }
    }
}
