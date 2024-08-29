using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace GarageLogic
{
    public class Car : Vehicle
    {
        private eCarColor m_CarColor;
        private eCarNumberOfDoors m_CarNumberDoors;

        internal Car(string i_LicenseNumber, Engine i_Engine, Wheel[] i_Wheels)
            : base(i_LicenseNumber, i_Engine, i_Wheels)
        {
        }

        public void SetCarProperties(string i_ModelName, string i_WheelManufacturerName, float i_CurrentAirPressure,
            eCarColor i_CarColor, eCarNumberOfDoors i_CarNumberDoors, float i_CurrentAmountEnergy)
        {
            SetVehicleProperties(i_ModelName, i_WheelManufacturerName, i_CurrentAirPressure, i_CurrentAmountEnergy);
            m_CarColor = i_CarColor;
            m_CarNumberDoors = i_CarNumberDoors;
        }

        private string carColor
        {
            get
            {
                return m_CarColor.ToString();
            }
        }

        private int carNumberDoors
        {
            get
            {
                return (int)m_CarNumberDoors;
            }
        }

        public override string ToString()
        {
            string carInfo = string.Format("Car Color : {0} | Car Number of Doors : {1}\n{2}",
                carColor, carNumberDoors, base.ToString());

            return carInfo;
        }
    }
}