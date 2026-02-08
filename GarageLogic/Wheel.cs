using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageLogic
{
    /// <summary>
    /// Represents a vehicle wheel with manufacturer, current air pressure, and maximum pressure.
    /// </summary>
    public class Wheel
    {
        private string m_ManufacturerName;
        private float m_CurrentAirPressure;
        private readonly float r_MaxAirPressure;

        /// <summary>
        /// Creates a new wheel with the specified maximum air pressure.
        /// </summary>
        /// <param name="i_MaxAirPressure">The maximum air pressure the wheel can hold.</param>
        internal Wheel(float i_MaxAirPressure)
        {
            r_MaxAirPressure = i_MaxAirPressure;
        }

        /// <summary>
        /// Sets the manufacturer name and current air pressure.
        /// </summary>
        /// <param name="i_ManufacturerName">The wheel manufacturer name.</param>
        /// <param name="i_CurrentAirPressure">The current air pressure to set.</param>
        internal void SetWheelProperties(string i_ManufacturerName, float i_CurrentAirPressure)
        {
            m_ManufacturerName = i_ManufacturerName;
            CurrentAirPressure = i_CurrentAirPressure;
        }

        /// <summary>
        /// Gets the maximum air pressure the wheel can hold.
        /// </summary>
        internal float MaxAirPressure
        {
            get 
            {
                return r_MaxAirPressure;
            }
        }

        /// <summary>
        /// Gets or sets the current air pressure. Validates that the value is between 0 and max pressure.
        /// </summary>
        /// <exception cref="ValueOutOfRangeException">Thrown when the value is outside the valid range.</exception>
        internal float CurrentAirPressure
        {
            get
            {
                return m_CurrentAirPressure;
            }
            set
            {
                bool validValue = value >= 0 && value <= MaxAirPressure;

                if (validValue)
                {
                    m_CurrentAirPressure = value;
                }
                else
                {
                    throw new ValueOutOfRangeException("current air pressure to wheel", 0, MaxAirPressure);
                }
            }
        }

        /// <summary>
        /// Gets the wheel manufacturer name.
        /// </summary>
        internal string ManufacturerName
        {
            get 
            {
                return m_ManufacturerName;
            }
        }

        /// <summary>
        /// Inflates the wheel to its maximum air pressure.
        /// </summary>
        internal void InflateToMax()
        {
            CurrentAirPressure = MaxAirPressure;
        }

        /// <summary>
        /// Returns a string with manufacturer, current pressure, and max pressure.
        /// </summary>
        /// <returns>Formatted wheel information.</returns>
        public override string ToString()
        {
            string WheelInfo = string.Format("Wheel's information -\n" +
                "Wheel Manufacturer : {0}   |   Current Air Pressure : {1}   |   Max Air Pressure : {2}",
               ManufacturerName, CurrentAirPressure, MaxAirPressure);

            return WheelInfo;
        }
    }
}