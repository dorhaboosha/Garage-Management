using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageLogic
{
    public class GarageTicket
    {
        private string m_OwnerName;
        private string m_OwnerPhoneNumber;
        private eVehicleStatusInGarage m_VehicleStatus;

        public GarageTicket()
        {
            m_VehicleStatus = eVehicleStatusInGarage.InRepair;
        }

        public void SetOwnerInfoProperties(string i_OwnerName, string i_OwnerPhoneNumber)
        {
            m_OwnerName = i_OwnerName;
            m_OwnerPhoneNumber = i_OwnerPhoneNumber;
        }

        private string ownerName
        {
            get
            {
                return m_OwnerName;
            }
        }

        private string ownerPhoneNumber
        {
            get 
            {
                return m_OwnerPhoneNumber;
            }
        }

        internal eVehicleStatusInGarage VehicleStatus
        {
            get 
            {
                return m_VehicleStatus;
            }
            set 
            {
                m_VehicleStatus = value;
            }
        }

        public override string ToString()
        {
            string OwnerInfo = string.Format("Garage Ticket Info -\n" +
                "Owner Name : {0} | Owner Phone Number : {1} | Owner's vehicle status : {2}",
                ownerName, ownerPhoneNumber, VehicleStatus.ToString());

            return OwnerInfo;
        }

    }
}