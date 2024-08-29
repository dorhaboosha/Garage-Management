using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageLogic
{
    public enum eWheelMaxAirPressure
    {
        MotorcycleWheel = 33,
        CarWheel = 31,
        TruckWheel = 28
    }

    public enum eFuelType
    {
        Soler = 1,
        Octan95 = 2,
        Octan96 = 3,
        Octan98 = 4
    }

    public enum eNumberOfWheelsInVehicle
    {
        MotorcycleNumberWheels = 2,
        CarNumberWheels = 5,
        TruckNumberWheels = 12,
    }

    public enum eMotorcycleLicenseType 
    {
       A = 1,
       A1 = 2,
       AA = 3,
       B1 = 4
    }

    public enum eCarColor 
    {
        Yellow = 1,
        White = 2,
        Black = 3,
        Red = 4
    }

    public enum eCarNumberOfDoors
    {
        TwoDoors = 2,
        ThreeDoors = 3,
        FourDoors = 4,
        FiveDoors = 5,
    }

    public enum eVehicleStatusInGarage
    {
        InRepair = 1,
        Repaired = 2,
        PayedFor = 3
    }

    public enum eVehicleType
    {
        RegularCar = 1,
        ElectricCar = 2,
        RegularMotorcycle = 3,
        ElectricMotorcycle = 4,
        Truck = 5
    }

    public enum eGarageMenuOperationOption
    {
        ExitProgram = 0,
        InsertNewVehicle = 1,
        ShowAllVehicles = 2,
        ChangeVehicleStatus = 3,
        InflateVehicleWheels = 4,
        RefuelVehicle = 5,
        RechargeVehicle = 6,
        ShowVehicleInformation = 7
    }
}