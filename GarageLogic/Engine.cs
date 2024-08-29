using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageLogic
{
    public class Engine
    {
        private readonly float r_MaxEngineAmount;
        private float m_CurrentEngineAmount;

        internal Engine(float i_MaxEngineCapacity)
        {
            r_MaxEngineAmount = i_MaxEngineCapacity;
            m_CurrentEngineAmount = 0;
        }

        internal float MaxEngineAmount
        {
            get
            {
                return r_MaxEngineAmount;
            }
        }

        internal float CurrentEngineAmount
        {
            get
            {
                return m_CurrentEngineAmount;
            }

            set 
            {
                m_CurrentEngineAmount = value;
            }
        }

        internal void FillingEnergyInEngine(float i_AmountToFill)
        {
            float totalEnergyToFill = i_AmountToFill + m_CurrentEngineAmount;
            bool validEnergyAmount = totalEnergyToFill >= 0 && totalEnergyToFill <= MaxEngineAmount;
            
            if (validEnergyAmount)
            {
                CurrentEngineAmount = totalEnergyToFill;
            }
            else
            {
                throw new ValueOutOfRangeException("filling the engine with energy", 0,
                    MaxEngineAmount - CurrentEngineAmount);
            }
        }

        public override string ToString()
        {
            string infoMessage = string.Format("Engine's information - \n" +
                "Current engine capacity to energy : {0} | engine capacity to energy : {1}",
                CurrentEngineAmount, MaxEngineAmount);

            return infoMessage;
        }
    }
}