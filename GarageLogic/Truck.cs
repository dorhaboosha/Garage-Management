using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageLogic
{
    public class Truck : Vehicle
    {
        private bool m_ContainDangerousMaterials;
        private float m_CargoTankVolume;

        internal Truck(string i_LicenseNumber, Engine i_Engine, Wheel[] i_Wheels)
        :base(i_LicenseNumber, i_Engine, i_Wheels)
        {
        }

        public void SetTruckProperties(string i_ModelName, string i_WheelManufacturerName, float i_CurrentAirPressure,
            bool i_ContainDangerousMaterials, float i_CargoTankVolume, float i_CurrentAmountEnergy)
        {
            SetVehicleProperties(i_ModelName, i_WheelManufacturerName, i_CurrentAirPressure, i_CurrentAmountEnergy);
            m_ContainDangerousMaterials = i_ContainDangerousMaterials;
            m_CargoTankVolume = i_CargoTankVolume;
        }

        private float cargoTankVolume
        {
            get 
            {
                return m_CargoTankVolume;
            }
        }

        private bool containDangerousMaterials
        {
            get
            {
                return m_ContainDangerousMaterials;
            }
        }

        public override string ToString()
        {
            string TruckInfo = string.Format("Truck Cargo Tank Volume : {0} | Truck Contain Dangerous Materials? : {1}\n{2}",
                cargoTankVolume, containDangerousMaterials, base.ToString());

            return TruckInfo;
        }
    }
}