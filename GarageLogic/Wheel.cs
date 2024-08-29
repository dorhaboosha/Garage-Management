using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageLogic
{
    public class Wheel
    {
        private string m_ManufcturerName;
        private float m_CurrentAirPressure;
        private readonly float r_MaxAirPressure;

        internal Wheel(float i_MaxAirPressure)
        {
            r_MaxAirPressure = i_MaxAirPressure;
        }

        internal void SetWheelProperties(string i_ManufcturerName, float i_CurrentAirPressure)
        {
            m_ManufcturerName = i_ManufcturerName;
            CurrentAirPressure = i_CurrentAirPressure;
        }

        internal float MaxAirPressure
        {
            get 
            {
                return r_MaxAirPressure;
            }
        }

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

        internal string ManufcturerName
        {
            get 
            {
                return m_ManufcturerName;
            }
        }

        internal void InflateToMax()
        {
            CurrentAirPressure = MaxAirPressure;
        }

        public override string ToString()
        {
            string WheelInfo = string.Format("Wheel's information -\n" +
                "Wheel Manufacturer : {0}   |   Current Air Pressure : {1}   |   Max Air Pressure : {2}",
               ManufcturerName, CurrentAirPressure, MaxAirPressure);

            return WheelInfo;
        }
    }
}