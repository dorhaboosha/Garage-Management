using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageLogic
{
    /// <summary>
    /// Base class for all vehicles. Manages model, license, engine, wheels, and energy percentage.
    /// Implemented by <see cref="Car"/>, <see cref="Motorcycle"/>, and <see cref="Truck"/>.
    /// </summary>
    public class Vehicle
    {
        private string m_ModelName;
        private readonly string r_LicenseNumber;
        private float m_RemainingEnergyPercentage;
        private readonly Engine r_engine;
        private readonly Wheel[] r_wheels;

        /// <summary>
        /// Creates a new vehicle with the given license number, engine, and wheels.
        /// </summary>
        /// <param name="i_LicenseNumber">The vehicle's license plate number.</param>
        /// <param name="i_Engine">The engine (fuel or electric) for the vehicle.</param>
        /// <param name="i_Wheels">The wheels array for the vehicle.</param>
        /// <exception cref="FormatException">Thrown when the license number is null or empty.</exception>
        /// <exception cref="ArgumentNullException">Thrown when engine or wheels is null or empty.</exception>
        public Vehicle(string i_LicenseNumber, Engine i_Engine, Wheel[] i_Wheels)
        {
            if (string.IsNullOrEmpty(i_LicenseNumber))
            {
                throw new FormatException("The license number can not be empty");
            }

            if (i_Engine == null)
            {
                throw new ArgumentNullException(nameof(i_Engine), "Engine cannot be null");
            }

            if (i_Wheels == null || i_Wheels.Length == 0)
            {
                throw new ArgumentNullException(nameof(i_Wheels), "Wheels cannot be null or empty");
            }

            r_LicenseNumber = i_LicenseNumber;
            r_engine = i_Engine;
            r_wheels = i_Wheels;
        }

        /// <summary>
        /// Sets the vehicle's common properties: model name, wheel details, and current energy level.
        /// </summary>
        /// <param name="i_ModelName">The model name of the vehicle.</param>
        /// <param name="i_WheelManufacrurerName">The manufacturer of the wheels.</param>
        /// <param name="i_WheelCurrentAirPressure">The current air pressure in the wheels.</param>
        /// <param name="i_CurrentAmountEnergy">The current fuel or battery level.</param>
        internal void SetVehicleProperties(string i_ModelName, string i_WheelManufacrurerName, 
            float i_WheelCurrentAirPressure, float i_CurrentAmountEnergy)
        {
            m_ModelName = i_ModelName;
            setEngineCurrentAmountOfEnergy(i_CurrentAmountEnergy);
            setWheelProperties(i_WheelManufacrurerName, i_WheelCurrentAirPressure);
        }

        /// <summary>
        /// Sets the engine's current energy level and updates the energy percentage.
        /// </summary>
        /// <param name="i_CurrentAmountEnergy">The current fuel or battery level to set.</param>
        private void setEngineCurrentAmountOfEnergy(float i_CurrentAmountEnergy)
        {
            Engine.FillingEnergyInEngine(i_CurrentAmountEnergy);
            UpdatingEnergyPrecentage();
        }

        /// <summary>
        /// Sets the manufacturer and air pressure for all wheels.
        /// </summary>
        /// <param name="i_WheelManufacrurerName">The wheel manufacturer name.</param>
        /// <param name="i_WheelCurrentAirPressure">The current air pressure to set.</param>
        private void setWheelProperties(string i_WheelManufacrurerName, float i_WheelCurrentAirPressure)
        {
            foreach (Wheel wheel in Wheels)
            {
                wheel.SetWheelProperties(i_WheelManufacrurerName, i_WheelCurrentAirPressure);
            }
        }

        /// <summary>
        /// Gets the model name.
        /// </summary>
        private string modelName
        {
            get
            {
                return m_ModelName;
            }
        }

        /// <summary>
        /// Gets the license plate number.
        /// </summary>
        public string LicenseNumber
        {
            get
            {
                return r_LicenseNumber;
            }
        }

        /// <summary>
        /// Gets the vehicle's engine (fuel or electric).
        /// </summary>
        public Engine Engine
        {
            get
            {
                return r_engine;
            }
        }

        /// <summary>
        /// Gets the vehicle's wheels.
        /// </summary>
        private Wheel[] Wheels
        {
            get 
            {
                return r_wheels;
            }
        }

        /// <summary>
        /// Recalculates the remaining energy percentage based on current vs. max engine capacity.
        /// </summary>
        internal void UpdatingEnergyPrecentage()
        {
            m_RemainingEnergyPercentage = r_engine.MaxEngineAmount > 0
                ? (r_engine.CurrentEngineAmount / r_engine.MaxEngineAmount) * 100
                : 0;
        }

        /// <summary>
        /// Inflates all wheels to their maximum pressure.
        /// </summary>
        internal void InflateTires()
        {
            foreach (Wheel wheel in Wheels)
            {
                wheel.InflateToMax();
            }
        }

        /// <summary>
        /// Returns a string with model, license, energy percentage, engine info, and wheel details.
        /// </summary>
        /// <returns>Formatted vehicle information.</returns>
        public override string ToString()
        {
            string vehicleInfo = string.Format("Vehicle's information -\n" +
                "Model Name : {0} | License Plate Number : {1} | Remaining energy in engine percentage : {2}%\n{3}",
                modelName, LicenseNumber, m_RemainingEnergyPercentage, Engine.ToString());
            
            foreach (Wheel wheel in Wheels) 
            {
                vehicleInfo += string.Format("\n{0}", wheel.ToString());
            }

            return vehicleInfo;
        }
    }
}