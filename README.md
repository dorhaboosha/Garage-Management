# Garage Management System (C# / .NET)

A console-based **Garage Management System** built in **C#/.NET** to demonstrate **OOP design** (inheritance, polymorphism), **collections**, **enums**, and **exception handling**, with a clear separation between the **UI layer** and the **logical/domain layer**.

This project follows the exercise requirements: a reusable logic **Class Library** and a separate **Console UI** executable.

---

## What the system supports

### Vehicle types
- Fuel Motorcycle (2 wheels, max 33 PSI, Octane 98, 5.5L tank)
- Electric Motorcycle (2 wheels, max 33 PSI, 2.5h battery)
- Fuel Car (4 wheels, max 31 PSI, Octane 95, 45L tank)
- Electric Car (4 wheels, max 31 PSI, 3.5h battery)
- Fuel Truck (12 wheels, max 28 PSI, Soler, 120L tank)

### Vehicle data
Every vehicle contains:
- Model name
- License number
- Remaining energy percentage
- Wheels (manufacturer + current/max pressure, with inflate action)

Additional fields by type:
- Motorcycle: license type (A / A1 / AA / B1), engine volume
- Car: color (Yellow / White / Red / Gray), number of doors (2–5)
- Truck: hazardous materials (bool), cargo volume 

### Garage record data
Each vehicle in the garage also stores:
- Owner name
- Owner phone number
- Status: **In Repair / Repaired / Paid** (new vehicles start **In Repair**) 

---

## Main features (menu actions)
1. Insert a new vehicle (or update status to *In Repair* if it already exists)
2. Display license numbers in the garage (with optional status filtering)
3. Change a vehicle status
4. Inflate tires to maximum
5. Refuel a fuel-based vehicle (validate fuel type + range)
6. Charge an electric vehicle (minutes → hours conversion, validate range)
7. Display full vehicle information

---

## Solution structure
- **GarageLogic** – Class Library: domain model + business logic only (no Console access)
- **ConsoleUI** – Console application: user interaction + menus, referencing `GarageLogic` 

---

## Tech & concepts used
- C#, .NET
- Inheritance & polymorphism
- `List<T>` / `Dictionary<TKey, TValue>`
- Enums
- String formatting
- Exceptions:
  - `FormatException`
  - `ArgumentException`
  - `ValueOutOfRangeException` (custom) 

---

## Run locally (Visual Studio)
1. Clone the repo:
   ```bash
   git clone https://github.com/dorhaboosha/Garage-Management.git
   cd Garage-Management
   ```
2. Open the solution: `Garage Management.sln`
3. Set **ConsoleUI** as the Startup Project
4. Run (Ctrl+F5)

---

## Download (Windows EXE)
You can download a ready-to-run published build (Windows) from the repository:

1. Go to **Releases** (recommended):  
   https://github.com/dorhaboosha/Garage-Management/releases/latest
2. Download the latest `Garage-Management-Publish.zip`
3. Extract the zip file
4. Run the `ConsoleUI.exe` file
