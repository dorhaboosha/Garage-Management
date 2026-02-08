using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageLogic
{
    /// <summary>
    /// Maximum air pressure (in PSI) for each vehicle type's wheels.
    /// </summary>
    public enum eWheelMaxAirPressure
    {
        MotorcycleWheel = 33,
        CarWheel = 31,
        TruckWheel = 28
    }

    /// <summary>
    /// Available fuel types for fuel-powered vehicles.
    /// </summary>
    public enum eFuelType
    {
        Soler = 1,
        Octan95 = 2,
        Octan96 = 3,
        Octan98 = 4
    }

    /// <summary>
    /// Number of wheels for each vehicle type.
    /// </summary>
    public enum eNumberOfWheelsInVehicle
    {
        MotorcycleNumberWheels = 2,
        CarNumberWheels = 5,
        TruckNumberWheels = 12,
    }

    /// <summary>
    /// Motorcycle license types.
    /// </summary>
    public enum eMotorcycleLicenseType 
    {
       A = 1,
       A1 = 2,
       AA = 3,
       B1 = 4
    }

    /// <summary>
    /// Available car colors.
    /// </summary>
    public enum eCarColor 
    {
        Yellow = 1,
        White = 2,
        Black = 3,
        Red = 4
    }

    /// <summary>
    /// Number of doors for a car.
    /// </summary>
    public enum eCarNumberOfDoors
    {
        TwoDoors = 2,
        ThreeDoors = 3,
        FourDoors = 4,
        FiveDoors = 5,
    }

    /// <summary>
    /// Status of a vehicle in the garage.
    /// </summary>
    public enum eVehicleStatusInGarage
    {
        InRepair = 1,
        Repaired = 2,
        PayedFor = 3
    }

    /// <summary>
    /// Types of vehicles supported by the garage.
    /// </summary>
    public enum eVehicleType
    {
        RegularCar = 1,
        ElectricCar = 2,
        RegularMotorcycle = 3,
        ElectricMotorcycle = 4,
        Truck = 5
    }

    /// <summary>
    /// Main menu options for the garage management system.
    /// </summary>
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