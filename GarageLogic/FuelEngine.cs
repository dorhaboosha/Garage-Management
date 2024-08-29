using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageLogic
{
    public class FuelEngine : Engine
    {
        private readonly eFuelType r_FuelType;

        internal FuelEngine(float i_MaxEngineAmount, eFuelType i_FuelType)
            :base(i_MaxEngineAmount)
        {
           r_FuelType = i_FuelType;
        }

        internal string FuelType
        {
            get 
            {
                return r_FuelType.ToString();
            }
        }

        public override string ToString()
        {
            string FuelEngineInfo = string.Format("Fuel Type : {0}\n{1}", FuelType, base.ToString());

            return FuelEngineInfo;
        }
    }
}