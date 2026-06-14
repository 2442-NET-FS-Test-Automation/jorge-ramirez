# Garage Project

C# console application to manage a small garage inventory.

The app lets you:
- List vehicles in inventory
- Service all vehicles
- Add a new car or motorcycle
- Check miles remaining until next service for a selected vehicle
- Show wash equipment instructions for a selected vehicle

## Solution Structure

- `Garage.slnx` - Solution file
- `Garage.App/` - Console application (entry point and menu)
- `Garage.Domain/` - Domain models and service contract

## Classes and Responsibilities

### Garage.App

- `Program` (`Garage.App/Program.cs`)
  - Creates the initial inventory
  - Displays the interactive menu
  - Handles user input and actions
  - Finds vehicles by ID and calls domain methods

### Garage.Domain

- `IVehicleService` (`Garage.Domain/IVehicleService.cs`)
  - Contract for service-related behavior:
    - `PerformService()`
    - `GetSummary()`

- `Vehicle` (`Garage.Domain/Vehicle.cs`)
  - Abstract base class for all vehicles
  - Shared properties:
    - `Id`, `Brand`, `Model`, `Mileage`
  - Shared behavior:
    - mileage remaining for service
    - base summary formatting
    - default wash equipment instructions
  - Abstract methods implemented by subclasses:
    - `PerformService()`
    - `GetSummary()`

- `Car` (`Garage.Domain/Car.cs`)
  - Inherits from `Vehicle`
  - Adds `NumberOfDoors`
  - Overrides service summary and wash equipment instructions

- `Motorcycle` (`Garage.Domain/Motorcycle.cs`)
  - Inherits from `Vehicle`
  - Adds `HasSidecar`
  - Overrides service summary

## Notes

- Vehicle IDs are auto-generated in memory while the app is running.
