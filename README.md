# Garage Management
The Garage Management System is a console-based application developed in **C#** and **.NET** that simulates the management of a vehicle garage.
It allows users to manage various types of vehicles, including fuel-based and electric motorcycles, cars, and trucks.
The system handles tasks such as inserting new vehicles, updating their status, refueling or recharging them, inflating their tires, and displaying detailed information about each vehicle.

The application is built using **Visual Studio**.

It consists of two main projects: 
1. Ex03.GarageLogic, **a Class Library (.dll)** that encapsulates the business logic and is designed to be reusable.
2. Ex03.ConsoleUI, which handles the console-based user interface.

The system makes extensive use of **C#** for implementing object-oriented programming principles like **inheritance** and **polymorphism**.
It employs **Collections** such as **List<T>** and **Dictionary<K,V>** for managing and organizing data.
**Enums** are used to define named constants for vehicle types, fuel types, and other properties.

Custom exceptions are implemented to handle specific error conditions, such as invalid input or exceeding allowed ranges, using a **Custom Exceptions** class.
**String Formatting** is used to generate user-friendly outputs in the console interface, ensuring clear communication of information to the user.

This approach provides a well-structured application that separates the business logic from the user interface, enabling easy future expansions and modifications.
