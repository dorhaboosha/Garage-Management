using GarageLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI
{
    internal static class InputGetter
    {
        private static bool optionValidation(StringBuilder i_UserOption)
        {
            bool validOption = true;
            bool inputIsNullOrEmpty = string.IsNullOrEmpty(i_UserOption.ToString());
            bool inputLengthIsNotOne = i_UserOption.Length != 1;
            int userInputNumber;
            bool inputIsDigit = int.TryParse(i_UserOption.ToString(), out userInputNumber);

            if (inputIsNullOrEmpty || inputLengthIsNotOne || !inputIsDigit)
            {
                validOption = !validOption;
            }
            else
            {
                bool userInputNumberNotInTheRange = userInputNumber < 0 || userInputNumber > 7;
                if (userInputNumberNotInTheRange)
                {
                    validOption = !validOption;
                }
            }

            return validOption;
        }

        internal static eGarageMenuOperationOption GetUserOptionToOperate()
        {
            StringBuilder userOption = new StringBuilder(Console.ReadLine());

            while (!optionValidation(userOption))
            {
                Console.WriteLine("The option you insert is not valid, please chose valid option (number between 0 - 7):");
                userOption.Clear();
                userOption.Append(Console.ReadLine());
            }

            int userInputNumber;
            int.TryParse(userOption.ToString(), out userInputNumber);
            eGarageMenuOperationOption MenuOperationChoosen = (eGarageMenuOperationOption)userInputNumber;

            return MenuOperationChoosen;
        }

        private static bool vehicleTypeValidation(StringBuilder i_UserVehicleTypeOption)
        {
            bool validVehicleTypeOption = true;
            bool inputIsNullOrEmpty = string.IsNullOrEmpty(i_UserVehicleTypeOption.ToString());
            bool inputLengthIsNotOne = i_UserVehicleTypeOption.Length != 1;
            int userVehicleTypeInputNumber;
            bool inputIsDigit = int.TryParse(i_UserVehicleTypeOption.ToString(), out userVehicleTypeInputNumber);

            if (inputIsNullOrEmpty || inputLengthIsNotOne || !inputIsDigit)
            {
                validVehicleTypeOption = !validVehicleTypeOption;
            }
            else
            {
                bool userInputNumberNotInTheRange = userVehicleTypeInputNumber < 1 || userVehicleTypeInputNumber > 5;
                if (userInputNumberNotInTheRange)
                {
                    validVehicleTypeOption = !validVehicleTypeOption;
                }
            }

            return validVehicleTypeOption;
        }

        internal static eVehicleType GetUserOptionToVehicle()
        {
            StringBuilder userVehicleType = new StringBuilder(Console.ReadLine());

            while (!vehicleTypeValidation(userVehicleType))
            {
                Console.WriteLine("The option you insert is not valid, please chose valid option (number between 1 - 5):");
                userVehicleType.Clear();
                userVehicleType.Append(Console.ReadLine());
            }

            int vehicleTypeInputNumber;
            int.TryParse(userVehicleType.ToString(), out vehicleTypeInputNumber);
            eVehicleType vehicleTypeChoosen = (eVehicleType)vehicleTypeInputNumber;

            return vehicleTypeChoosen;
        }

        private static bool stringPropertyValidation(StringBuilder i_StringProperty)
        {
            bool validStringProperty = true;
            bool inputIsNullOrEmpty = string.IsNullOrEmpty(i_StringProperty.ToString());

            if (inputIsNullOrEmpty)
            {
                validStringProperty = !validStringProperty;
            }
            else
            {
                for (int i = 0; i < i_StringProperty.Length; i++)
                {
                    if (!char.IsLetter(i_StringProperty[i]) && !char.IsDigit(i_StringProperty[i]) &&
                        !char.IsPunctuation(i_StringProperty[i]))
                    {
                        validStringProperty = !validStringProperty;
                        break;
                    }
                }
            }

            return validStringProperty;
        }

        internal static string GetStringPropertyFromUser()
        {
            StringBuilder stringProperty = new StringBuilder(Console.ReadLine());

            while (!stringPropertyValidation(stringProperty))
            {
                Console.WriteLine("The property you entered is invalid, please enter again " +
                    "(only digits, letters and punctuation marks):");
                stringProperty.Clear();
                stringProperty.Append(Console.ReadLine());
            }

            return stringProperty.ToString();
        }

        private static bool floatPropertyValidation(StringBuilder i_FloatProperty)
        {
            bool validFloatProperty = true;
            bool inputIsNullOrEmpty = string.IsNullOrEmpty(i_FloatProperty.ToString());
            float numberBiggerZero;
            bool validFloatNumber = float.TryParse(i_FloatProperty.ToString(), out numberBiggerZero);
            bool validNumberBiggerZero = numberBiggerZero >= 0;

            if (inputIsNullOrEmpty || !validFloatNumber || !validNumberBiggerZero)
            {
                validFloatProperty = !validFloatProperty;
            }

            return validFloatProperty;
        }

        internal static float GetFloatPropertyFromUser()
        {
            StringBuilder floatProperty = new StringBuilder(Console.ReadLine());

            while (!floatPropertyValidation(floatProperty))
            {
                Console.WriteLine("The property you entered is invalid, please enter again (only positive float number):");
                floatProperty.Clear();
                floatProperty.Append(Console.ReadLine());
            }

            float property;
            float.TryParse(floatProperty.ToString(), out property);
            
            return property;
        }

        private static bool carColorValidation(StringBuilder i_UserCarColor)
        {
            bool validCarColor = true;
            bool inputIsNullOrEmpty = string.IsNullOrEmpty(i_UserCarColor.ToString());
            bool inputLengthIsNotOne = i_UserCarColor.Length != 1;
            int userInputNumber;
            bool inputIsDigit = int.TryParse(i_UserCarColor.ToString(), out userInputNumber);

            if (inputIsNullOrEmpty || inputLengthIsNotOne || !inputIsDigit)
            {
                validCarColor = !validCarColor;
            }
            else
            {
                bool userInputNumberNotInTheRange = userInputNumber < 1 || userInputNumber > 4;
                if (userInputNumberNotInTheRange)
                {
                    validCarColor = !validCarColor;
                }
            }

            return validCarColor;
        }

        internal static eCarColor GetUserCarColor()
        {
            StringBuilder carColor = new StringBuilder(Console.ReadLine());

            while (!carColorValidation(carColor))
            {
                Console.WriteLine("What you insert is not valid, please chose valid car color option (number between 1 - 4):");
                carColor.Clear();
                carColor.Append(Console.ReadLine());
            }

            int userInputNumber;
            int.TryParse(carColor.ToString(), out userInputNumber);
            eCarColor carColorChoosen = (eCarColor)userInputNumber;

            return carColorChoosen;
        }

        private static bool carNumberDoorsValidation(StringBuilder i_UserCarNumberDoors)
        {
            bool validCarNumberDoors = true;
            bool inputIsNullOrEmpty = string.IsNullOrEmpty(i_UserCarNumberDoors.ToString());
            bool inputLengthIsNotOne = i_UserCarNumberDoors.Length != 1;
            int userInputNumber;
            bool inputIsDigit = int.TryParse(i_UserCarNumberDoors.ToString(), out userInputNumber);

            if (inputIsNullOrEmpty || inputLengthIsNotOne || !inputIsDigit)
            {
                validCarNumberDoors = !validCarNumberDoors;
            }
            else
            {
                bool userInputNumberNotInTheRange = userInputNumber < 1 || userInputNumber > 4;
                if (userInputNumberNotInTheRange)
                {
                    validCarNumberDoors = !validCarNumberDoors;
                }
            }

            return validCarNumberDoors;
        }

        internal static eCarNumberOfDoors GetUserCarNumberDoors()
        {
            StringBuilder carNumberDoorsString = new StringBuilder(Console.ReadLine());

            while (!carNumberDoorsValidation(carNumberDoorsString))
            {
                Console.WriteLine("What you insert is not valid, please chose valid car number of doors option (number between 2 - 4):");
                carNumberDoorsString.Clear();
                carNumberDoorsString.Append(Console.ReadLine());
            }

            int userInputNumber;
            int.TryParse(carNumberDoorsString.ToString(), out userInputNumber);
            eCarNumberOfDoors carNumberDoors = (eCarNumberOfDoors)(userInputNumber + 1);

            return carNumberDoors;
        }

        private static bool motorcycleLicenseTypeValidation(StringBuilder i_UserMotorcycleLicenseType)
        {
            bool validMotorcycleLicenseType = true;
            bool inputIsNullOrEmpty = string.IsNullOrEmpty(i_UserMotorcycleLicenseType.ToString());
            bool inputLengthIsNotOne = i_UserMotorcycleLicenseType.Length != 1;
            int userInputNumber;
            bool inputIsDigit = int.TryParse(i_UserMotorcycleLicenseType.ToString(), out userInputNumber);

            if (inputIsNullOrEmpty || inputLengthIsNotOne || !inputIsDigit)
            {
                validMotorcycleLicenseType = !validMotorcycleLicenseType;
            }
            else
            {
                bool userInputNumberNotInTheRange = userInputNumber < 1 || userInputNumber > 4;
                if (userInputNumberNotInTheRange)
                {
                    validMotorcycleLicenseType = !validMotorcycleLicenseType;
                }
            }

            return validMotorcycleLicenseType;
        }

        internal static eMotorcycleLicenseType GetUserMotorcycleLicenseType()
        {
            StringBuilder motorcycleLicenseTypeString = new StringBuilder(Console.ReadLine());

            while (!motorcycleLicenseTypeValidation(motorcycleLicenseTypeString))
            {
                Console.WriteLine("What you insert is not valid, please chose valid License type of motorcycle (number between 1 - 4):");
                motorcycleLicenseTypeString.Clear();
                motorcycleLicenseTypeString.Append(Console.ReadLine());
            }

            int userInputNumber;
            int.TryParse(motorcycleLicenseTypeString.ToString(), out userInputNumber);
            eMotorcycleLicenseType motorcycleLicenseType = (eMotorcycleLicenseType)userInputNumber;

            return motorcycleLicenseType;
        }

        private static bool intPropertyValidation(StringBuilder i_IntProperty)
        {
            bool validIntProperty = true;
            bool inputIsNullOrEmpty = string.IsNullOrEmpty(i_IntProperty.ToString());
            int numberBiggerZero;
            bool validIntNumber = int.TryParse(i_IntProperty.ToString(), out numberBiggerZero);
            bool validNumberBiggerZero = numberBiggerZero >= 0;

            if (inputIsNullOrEmpty || !validIntNumber || !validNumberBiggerZero)
            {
                validIntProperty = !validIntProperty;
            }

            return validIntProperty;
        }

        internal static int GetIntPropertyFromUser()
        {
            StringBuilder intProperty = new StringBuilder(Console.ReadLine());

            while (!intPropertyValidation(intProperty))
            {
                Console.WriteLine("The property you entered is invalid, please enter again (only positive integer number):");
                intProperty.Clear();
                intProperty.Append(Console.ReadLine());
            }

            int property;
            int.TryParse(intProperty.ToString(), out property);

            return property;
        }

        private static bool boolPropertyValidation(StringBuilder i_boolProperty)
        {
            bool validBoolProperty = true;
            bool inputIsNullOrEmpty = string.IsNullOrEmpty(i_boolProperty.ToString());
            bool validLetter = i_boolProperty.Length != 1 || !char.IsLetter(i_boolProperty[0]);

            if(inputIsNullOrEmpty || validLetter)
            {
                validBoolProperty = !validBoolProperty;
            }
            else 
            {
                char boolRepresentationLetter = i_boolProperty[0];
                bool notValidLetterToBool = boolRepresentationLetter != 'N' && boolRepresentationLetter != 'Y';

                if(notValidLetterToBool)
                {
                    validBoolProperty = !validBoolProperty;
                }
            }

            return validBoolProperty;
        }

        internal static bool GetBoolPropertyFromUser()
        {
            StringBuilder boolProperty = new StringBuilder(Console.ReadLine());

            while (!boolPropertyValidation(boolProperty))
            {
                Console.WriteLine("The property you entered is invalid, please enter again (only Y or N):");
                boolProperty.Clear();
                boolProperty.Append(Console.ReadLine());
            }

            bool property = boolProperty[0] == 'Y';
            
            return property;
        }

        private static bool ownerNameValidation(StringBuilder i_OwnerName)
        {
            bool validOwnerName = true;
            bool inputIsNullOrEmpty = string.IsNullOrEmpty(i_OwnerName.ToString());

            if (inputIsNullOrEmpty)
            {
                validOwnerName = !validOwnerName;
            }
            else
            {
                for (int i = 0; i < i_OwnerName.Length; i++)
                {
                    if (!char.IsLetter(i_OwnerName[i]))
                    {
                        validOwnerName = !validOwnerName;
                        break;
                    }
                }
            }

            return validOwnerName;
        }

        internal static string GetOwnerNameFromUser()
        {
            StringBuilder ownerName = new StringBuilder(Console.ReadLine());

            while (!ownerNameValidation(ownerName))
            {
                Console.WriteLine("The property you entered is invalid, please enter again (First Name):");
                ownerName.Clear();
                ownerName.Append(Console.ReadLine());
            }

            return ownerName.ToString();
        }

        private static bool ownerPhoneNumberValidation(StringBuilder i_OwnerPhoneNumber)
        {
            bool validOwnerPhoneNumber = true;
            bool inputIsNullOrEmpty = string.IsNullOrEmpty(i_OwnerPhoneNumber.ToString());

            if (inputIsNullOrEmpty)
            {
                validOwnerPhoneNumber = !validOwnerPhoneNumber;
            }
            else
            {
                for (int i = 0; i < i_OwnerPhoneNumber.Length; i++)
                {
                    if (!char.IsDigit(i_OwnerPhoneNumber[i]))
                    {
                        validOwnerPhoneNumber = !validOwnerPhoneNumber;
                        break;
                    }
                }
            }

            return validOwnerPhoneNumber;
        }

        internal static string GetOwnerPhoneNumberFromUser()
        {
            StringBuilder ownerPhoneNumber = new StringBuilder(Console.ReadLine());

            while (!ownerPhoneNumberValidation(ownerPhoneNumber))
            {
                Console.WriteLine("The property you entered is invalid, please enter again (only digits):");
                ownerPhoneNumber.Clear();
                ownerPhoneNumber.Append(Console.ReadLine());
            }

            return ownerPhoneNumber.ToString();
        }

        private static bool displayFilterValidation(StringBuilder i_DisplyFilter)
        {
            bool validDisplyFilter = true;
            bool inputIsNullOrEmpty = string.IsNullOrEmpty(i_DisplyFilter.ToString());
            bool inputLengthIsNotOne = i_DisplyFilter.Length != 1;
            int userInputNumber;
            bool inputIsDigit = int.TryParse(i_DisplyFilter.ToString(), out userInputNumber);

            if (inputIsNullOrEmpty || inputLengthIsNotOne || !inputIsDigit)
            {
                validDisplyFilter = !validDisplyFilter;
            }
            else
            {
                bool userInputNumberNotInTheRange = userInputNumber < 0 || userInputNumber > 3;
                if (userInputNumberNotInTheRange)
                {
                    validDisplyFilter = !validDisplyFilter;
                }
            }

            return validDisplyFilter;
        }

        internal static int GetUserDisplyFilter()
        {
            StringBuilder displyFilterOption = new StringBuilder(Console.ReadLine());

            while (!displayFilterValidation(displyFilterOption))
            {
                Console.WriteLine("The option you insert is not valid, please chose valid option (number between 0 - 3):");
                displyFilterOption.Clear();
                displyFilterOption.Append(Console.ReadLine());
            }

            int userInputNumber;
            int.TryParse(displyFilterOption.ToString(), out userInputNumber);

            return userInputNumber;
        }

        private static bool newVehiclStatusValidation(StringBuilder i_NewVehicleStatus)
        {
            bool validNewVehicleStatus = true;
            bool inputIsNullOrEmpty = string.IsNullOrEmpty(i_NewVehicleStatus.ToString());
            bool inputLengthIsNotOne = i_NewVehicleStatus.Length != 1;
            int userInputNumber;
            bool inputIsDigit = int.TryParse(i_NewVehicleStatus.ToString(), out userInputNumber);

            if (inputIsNullOrEmpty || inputLengthIsNotOne || !inputIsDigit)
            {
                validNewVehicleStatus = !validNewVehicleStatus;
            }
            else
            {
                bool userInputNumberNotInTheRange = userInputNumber < 1 || userInputNumber > 3;
                if (userInputNumberNotInTheRange)
                {
                    validNewVehicleStatus = !validNewVehicleStatus;
                }
            }

            return validNewVehicleStatus;
        }

        internal static eVehicleStatusInGarage GetNewVehicleStatusFromUser()
        {
            StringBuilder newVehicleStatus = new StringBuilder(Console.ReadLine());

            while (!newVehiclStatusValidation(newVehicleStatus))
            {
                Console.WriteLine("What you insert is not valid, please chose valid car color option (number between 1 - 3):");
                newVehicleStatus.Clear();
                newVehicleStatus.Append(Console.ReadLine());
            }

            int userInputNumber;
            int.TryParse(newVehicleStatus.ToString(), out userInputNumber);
            eVehicleStatusInGarage newVehicleStatusChoosen = (eVehicleStatusInGarage)userInputNumber;

            return newVehicleStatusChoosen;
        }

        private static bool vehicleFuelTypeValidation(StringBuilder i_VehicleFuelType)
        {
            bool validVehicleFuelType = true;
            bool inputIsNullOrEmpty = string.IsNullOrEmpty(i_VehicleFuelType.ToString());
            bool inputLengthIsNotOne = i_VehicleFuelType.Length != 1;
            int userInputNumber;
            bool inputIsDigit = int.TryParse(i_VehicleFuelType.ToString(), out userInputNumber);

            if (inputIsNullOrEmpty || inputLengthIsNotOne || !inputIsDigit)
            {
                validVehicleFuelType = !validVehicleFuelType;
            }
            else
            {
                bool userInputNumberNotInTheRange = userInputNumber < 1 || userInputNumber > 4;
                if (userInputNumberNotInTheRange)
                {
                    validVehicleFuelType = !validVehicleFuelType;
                }
            }

            return validVehicleFuelType;
        }

        internal static eFuelType GetUserVehicleFuelType()
        {
            StringBuilder vehicleFuelTypeString = new StringBuilder(Console.ReadLine());

            while (!vehicleFuelTypeValidation(vehicleFuelTypeString))
            {
                Console.WriteLine("What you insert is not valid, please chose valid vehicle fuel type (number between 1 - 4):");
                vehicleFuelTypeString.Clear();
                vehicleFuelTypeString.Append(Console.ReadLine());
            }

            int userInputNumber;
            int.TryParse(vehicleFuelTypeString.ToString(), out userInputNumber);
            eFuelType vehicleFuelType = (eFuelType)userInputNumber;

            return vehicleFuelType;
        }
    }
}
