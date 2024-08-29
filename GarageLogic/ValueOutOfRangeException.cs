using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageLogic
{
    public class ValueOutOfRangeException : Exception
    {
        private readonly float r_MaxValue;
        private readonly float r_MinValue;

        public ValueOutOfRangeException(string i_Message, float i_MinValue, float i_MaxValue) :
            base(string.Format("The value for {0} is out of range, the value need to be between {1} - {2}" +
                ", therefore the operation you tried to do canceled.",
                i_Message, i_MinValue, i_MaxValue))
        {
            r_MaxValue = i_MaxValue;
            r_MinValue = i_MinValue;
        }

        public float MaxValue
        {
            get 
            { 
                return r_MaxValue; 
            }
        }

        public float MinValue
        {
            get
            {
                return r_MinValue;
            }
        }
    }
}