using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageLogic
{
    public class Vehicle
    {
        private string m_ModelName;
        private readonly string r_LicenseNumber;
        private float m_RemainingEnergyPercentage;
        private readonly Engine r_engine;
        private readonly Wheel[] r_wheels;

        public Vehicle(string i_LicenseNumber, Engine i_Engine, Wheel[] i_Wheels)
        {
            if (string.IsNullOrEmpty(i_LicenseNumber))
            {
                throw new FormatException("The license number can not be empty");
            }

            r_LicenseNumber = i_LicenseNumber; 
            r_engine = i_Engine;
            r_wheels = i_Wheels;
        }

        internal void SetVehicleProperties(string i_ModelName, string i_WheelManufacrurerName, 
            float i_WheelCurrentAirPressure,float i_CurrentAmountEnergy)
        {
            m_ModelName = i_ModelName;
            setEngineCurrentAmountOfEnergy(i_CurrentAmountEnergy);
            setWheelProperties(i_WheelManufacrurerName, i_WheelCurrentAirPressure);
        }

        private void setEngineCurrentAmountOfEnergy(float i_CurrentAmountEnergy)
        {
            Engine.FillingEnergyInEngine(i_CurrentAmountEnergy);
            UpdatingEnergyPrecentage();
        }

        private void setWheelProperties(string i_WheelManufacrurerName, float i_WheelCurrentAirPressure)
        {
            foreach (Wheel wheel in Wheels)
            {
                wheel.SetWheelProperties(i_WheelManufacrurerName, i_WheelCurrentAirPressure);
            }
        }

        private string modelName
        {
            get
            {
                return m_ModelName;
            }
        }

        public string LicenseNumber
        {
            get
            {
                return r_LicenseNumber;
            }
        }

        public Engine Engine
        {
            get
            {
                return r_engine;
            }
        }

        private Wheel[] Wheels
        {
            get 
            {
                return r_wheels;
            }
        }

        internal void UpdatingEnergyPrecentage()
        {
            m_RemainingEnergyPercentage = (r_engine.CurrentEngineAmount / r_engine.MaxEngineAmount) * 100;
        }

        internal void InflateTires()
        {
            foreach (Wheel wheel in Wheels)
            {
                wheel.InflateToMax();
            }
        }

        public override string ToString()
        {
            string vehicleInfo = string.Format("Vehicle's information -\n" +
                "Model Name : {0} | License Plate Number : {1} | Remaining engery in engine precentage : {2}%\n{3}",
                modelName, LicenseNumber, m_RemainingEnergyPercentage, Engine.ToString());
            
            foreach (Wheel wheel in Wheels) 
            {
                vehicleInfo += string.Format("\n{0}", wheel.ToString());
            }

            return vehicleInfo;
        }
    }
}