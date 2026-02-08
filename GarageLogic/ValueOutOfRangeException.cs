using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageLogic
{
    /// <summary>
    /// Exception thrown when a value (e.g., fuel or battery amount) is outside the valid range.
    /// </summary>
    public class ValueOutOfRangeException : Exception
    {
        private readonly float r_MaxValue;
        private readonly float r_MinValue;

        /// <summary>
        /// Creates a new value-out-of-range exception with the specified context and valid range.
        /// </summary>
        /// <param name="i_Message">Description of what value was out of range (e.g., "filling the engine with energy").</param>
        /// <param name="i_MinValue">The minimum valid value.</param>
        /// <param name="i_MaxValue">The maximum valid value.</param>
        public ValueOutOfRangeException(string i_Message, float i_MinValue, float i_MaxValue) :
            base(string.Format("The value for {0} is out of range, the value need to be between {1} - {2}" +
                ", therefore the operation you tried to do canceled.",
                i_Message, i_MinValue, i_MaxValue))
        {
            r_MaxValue = i_MaxValue;
            r_MinValue = i_MinValue;
        }

        /// <summary>
        /// Gets the maximum valid value for the range.
        /// </summary>
        public float MaxValue
        {
            get 
            { 
                return r_MaxValue; 
            }
        }

        /// <summary>
        /// Gets the minimum valid value for the range.
        /// </summary>
        public float MinValue
        {
            get
            {
                return r_MinValue;
            }
        }
    }
}