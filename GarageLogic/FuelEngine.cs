using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageLogic
{
    /// <summary>
    /// Represents a fuel-powered engine for vehicles that use gasoline/diesel.
    /// </summary>
    public class FuelEngine : Engine
    {
        private readonly eFuelType r_FuelType;

        /// <summary>
        /// Creates a new fuel engine with the specified capacity and fuel type.
        /// </summary>
        /// <param name="i_MaxEngineAmount">Maximum fuel tank capacity.</param>
        /// <param name="i_FuelType">The type of fuel this engine uses.</param>
        internal FuelEngine(float i_MaxEngineAmount, eFuelType i_FuelType)
            :base(i_MaxEngineAmount)
        {
           r_FuelType = i_FuelType;
        }

        /// <summary>
        /// Gets the fuel type this engine uses as an enum.
        /// </summary>
        internal eFuelType FuelTypeEnum
        {
            get
            {
                return r_FuelType;
            }
        }

        /// <summary>
        /// Gets the fuel type this engine uses as a string (for display).
        /// </summary>
        internal string FuelType
        {
            get
            {
                return r_FuelType.ToString();
            }
        }

        /// <summary>
        /// Returns a string with the fuel type and base engine information.
        /// </summary>
        /// <returns>Formatted fuel engine information.</returns>
        public override string ToString()
        {
            string FuelEngineInfo = string.Format("Fuel Type : {0}\n{1}", FuelType, base.ToString());

            return FuelEngineInfo;
        }
    }
}