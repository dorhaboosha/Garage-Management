using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageLogic
{
    /// <summary>
    /// Base class for vehicle engines. Manages energy capacity and current level.
    /// Implemented by <see cref="FuelEngine"/> and <see cref="ElectricEngine"/>.
    /// </summary>
    public class Engine
    {
        private readonly float r_MaxEngineAmount;
        private float m_CurrentEngineAmount;

        /// <summary>
        /// Creates a new engine with the specified maximum capacity.
        /// </summary>
        /// <param name="i_MaxEngineCapacity">The maximum energy capacity of the engine.</param>
        internal Engine(float i_MaxEngineCapacity)
        {
            r_MaxEngineAmount = i_MaxEngineCapacity;
            m_CurrentEngineAmount = 0;
        }

        /// <summary>
        /// Gets the maximum energy capacity of the engine.
        /// </summary>
        internal float MaxEngineAmount
        {
            get
            {
                return r_MaxEngineAmount;
            }
        }

        /// <summary>
        /// Gets or sets the current energy level in the engine.
        /// </summary>
        /// <exception cref="ValueOutOfRangeException">Thrown when the value is outside the valid range (0 to max capacity).</exception>
        internal float CurrentEngineAmount
        {
            get
            {
                return m_CurrentEngineAmount;
            }

            set
            {
                if (value < 0 || value > r_MaxEngineAmount)
                {
                    throw new ValueOutOfRangeException("setting engine energy", 0, r_MaxEngineAmount);
                }

                m_CurrentEngineAmount = value;
            }
        }

        /// <summary>
        /// Fills the engine with the specified amount of energy. Validates that the total does not exceed maximum capacity.
        /// </summary>
        /// <param name="i_AmountToFill">The amount of energy to add.</param>
        /// <exception cref="ValueOutOfRangeException">Thrown when the fill amount would exceed the engine's capacity or go below zero.</exception>
        internal void FillingEnergyInEngine(float i_AmountToFill)
        {
            float totalEnergyToFill = i_AmountToFill + m_CurrentEngineAmount;
            bool validEnergyAmount = totalEnergyToFill >= 0 && totalEnergyToFill <= MaxEngineAmount;
            
            if (validEnergyAmount)
            {
                CurrentEngineAmount = totalEnergyToFill;
            }
            else
            {
                throw new ValueOutOfRangeException("filling the engine with energy", 0,
                    MaxEngineAmount - CurrentEngineAmount);
            }
        }

        /// <summary>
        /// Returns a string with the engine's current and maximum energy capacity.
        /// </summary>
        /// <returns>Formatted engine information.</returns>
        public override string ToString()
        {
            string infoMessage = string.Format("Engine's information - \n" +
                "Current engine capacity to energy : {0} | engine capacity to energy : {1}",
                CurrentEngineAmount, MaxEngineAmount);

            return infoMessage;
        }
    }
}