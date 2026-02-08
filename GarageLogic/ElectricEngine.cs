using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageLogic
{
    /// <summary>
    /// Represents an electric engine (battery) for electric vehicles.
    /// </summary>
    public class ElectricEngine : Engine
    {
        /// <summary>
        /// Creates a new electric engine with the specified maximum battery capacity.
        /// </summary>
        /// <param name="i_MaxEngineAmount">Maximum battery capacity.</param>
        internal ElectricEngine(float i_MaxEngineAmount)
            : base(i_MaxEngineAmount)
        {
        }
    }
}