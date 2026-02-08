using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageLogic
{
    /// <summary>
    /// Represents a truck vehicle. Trucks use fuel engines only.
    /// </summary>
    public class Truck : Vehicle
    {
        private bool m_ContainDangerousMaterials;
        private float m_CargoTankVolume;

        /// <summary>
        /// Creates a new truck with the given license number, engine, and wheels.
        /// </summary>
        /// <param name="i_LicenseNumber">The vehicle's license plate number.</param>
        /// <param name="i_Engine">The fuel engine for the truck.</param>
        /// <param name="i_Wheels">The wheels array for the truck.</param>
        internal Truck(string i_LicenseNumber, Engine i_Engine, Wheel[] i_Wheels)
        :base(i_LicenseNumber, i_Engine, i_Wheels)
        {
        }

        /// <summary>
        /// Sets the truck's properties including model, wheels, cargo capacity, dangerous materials flag, and energy level.
        /// </summary>
        /// <param name="i_ModelName">The model name of the truck.</param>
        /// <param name="i_WheelManufacturerName">The manufacturer of the wheels.</param>
        /// <param name="i_CurrentAirPressure">The current air pressure in the wheels.</param>
        /// <param name="i_ContainDangerousMaterials">True if the truck carries dangerous materials.</param>
        /// <param name="i_CargoTankVolume">The cargo tank volume capacity.</param>
        /// <param name="i_CurrentAmountEnergy">The current fuel level.</param>
        public void SetTruckProperties(string i_ModelName, string i_WheelManufacturerName, float i_CurrentAirPressure,
            bool i_ContainDangerousMaterials, float i_CargoTankVolume, float i_CurrentAmountEnergy)
        {
            SetVehicleProperties(i_ModelName, i_WheelManufacturerName, i_CurrentAirPressure, i_CurrentAmountEnergy);
            m_ContainDangerousMaterials = i_ContainDangerousMaterials;
            m_CargoTankVolume = i_CargoTankVolume;
        }

        /// <summary>
        /// Gets the cargo tank volume capacity.
        /// </summary>
        private float cargoTankVolume
        {
            get 
            {
                return m_CargoTankVolume;
            }
        }

        /// <summary>
        /// Gets whether the truck carries dangerous materials.
        /// </summary>
        private bool containDangerousMaterials
        {
            get
            {
                return m_ContainDangerousMaterials;
            }
        }

        /// <summary>
        /// Returns a string representation of the truck, including cargo volume, dangerous materials flag, and base vehicle details.
        /// </summary>
        /// <returns>Formatted truck information.</returns>
        public override string ToString()
        {
            string TruckInfo = string.Format("Truck Cargo Tank Volume : {0} | Truck Contain Dangerous Materials? : {1}\n{2}",
                cargoTankVolume, containDangerousMaterials, base.ToString());

            return TruckInfo;
        }
    }
}