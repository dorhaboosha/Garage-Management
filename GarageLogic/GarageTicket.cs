using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageLogic
{
    /// <summary>
    /// Represents a garage ticket with owner information and vehicle status.
    /// </summary>
    public class GarageTicket
    {
        private string m_OwnerName;
        private string m_OwnerPhoneNumber;
        private eVehicleStatusInGarage m_VehicleStatus;

        /// <summary>
        /// Creates a new garage ticket with default status "In Repair".
        /// </summary>
        public GarageTicket()
        {
            m_VehicleStatus = eVehicleStatusInGarage.InRepair;
        }

        /// <summary>
        /// Sets the owner's name and phone number.
        /// </summary>
        /// <param name="i_OwnerName">The vehicle owner's name.</param>
        /// <param name="i_OwnerPhoneNumber">The vehicle owner's phone number.</param>
        public void SetOwnerInfoProperties(string i_OwnerName, string i_OwnerPhoneNumber)
        {
            m_OwnerName = i_OwnerName;
            m_OwnerPhoneNumber = i_OwnerPhoneNumber;
        }

        /// <summary>
        /// Gets the owner's name.
        /// </summary>
        private string ownerName
        {
            get
            {
                return m_OwnerName;
            }
        }

        /// <summary>
        /// Gets the owner's phone number.
        /// </summary>
        private string ownerPhoneNumber
        {
            get 
            {
                return m_OwnerPhoneNumber;
            }
        }

        /// <summary>
        /// Gets or sets the vehicle's status in the garage.
        /// </summary>
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

        /// <summary>
        /// Returns a string with owner info and vehicle status.
        /// </summary>
        /// <returns>Formatted garage ticket information.</returns>
        public override string ToString()
        {
            string OwnerInfo = string.Format("Garage Ticket Info -\n" +
                "Owner Name : {0} | Owner Phone Number : {1} | Owner's vehicle status : {2}",
                ownerName, ownerPhoneNumber, VehicleStatus.ToString());

            return OwnerInfo;
        }

    }
}