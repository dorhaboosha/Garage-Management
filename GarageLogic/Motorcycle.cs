using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageLogic
{
    public class Motorcycle : Vehicle
    {
        private eMotorcycleLicenseType m_LicenseType;
        private int m_EngineVolume;

        internal Motorcycle(string i_LicenseNumber, Engine i_Engine, Wheel[] i_Wheels)
            : base(i_LicenseNumber, i_Engine, i_Wheels)
        {
        }

        public void SetMotorcycleProperties(string i_ModelName, string i_WheelManufacturerName, float i_CurrentAirPressure,
            eMotorcycleLicenseType i_LicenseType, int i_EngineVolume, float i_CurrentAmountEnergy)
        {
            SetVehicleProperties(i_ModelName, i_WheelManufacturerName, i_CurrentAirPressure, i_CurrentAmountEnergy);
            m_EngineVolume = i_EngineVolume;
            m_LicenseType = i_LicenseType;
        }

        private string licenseType
        {
            get 
            {
                return m_LicenseType.ToString();
            }
        }

        private int engineVolume
        {
            get 
            {
                return m_EngineVolume;
            }
        }

        public override string ToString()
        {
            string motorcycleInfo = string.Format("Motorcycle License Type : {0} | Motorcycle Engine Volume : {1}\n{2}",
                licenseType, engineVolume, base.ToString());

            return motorcycleInfo;
        }
    }
}
