# FleetManagementSystem

## Тема проєкту

Система логістики та автопарку.

## Опис

Проєкт створений для навчальної практики з об'єктно-орієнтованого програмування.  
Система дозволяє працювати з транспортом, водіями, вантажами, маршрутами та замовленнями доставки.

## Основні сутності

- Vehicle — базовий клас транспорту
- Car — легковий автомобіль
- Truck — вантажівка
- Moto — мотоцикл
- Driver — водій
- Cargo — вантаж
- Route — маршрут
- DeliveryOrder — замовлення доставки
- Fleet — автопарк

## Використані принципи ООП

- Інкапсуляція
- Наслідування
- Поліморфізм
- Абстракція

## Структура рішення

- FleetManagementSystem.Domain — доменні класи
- FleetManagementSystem.App — консольний застосунок
- FleetManagementSystem.Tests — модульні тести

## UML-діаграма

```mermaid
classDiagram
    direction LR

    class Vehicle {
        <<abstract>>
        -int id
        -string brand
        -string model
        -double maxLoad
        -double fuelConsumption
        +int Id
        +string Brand
        +string Model
        +double MaxLoad
        +double FuelConsumption
        +Vehicle()
        +Vehicle(int id, string brand, string model, double maxLoad, double fuelConsumption)
        +Vehicle(Vehicle other)
        +GetInfo() string
        +CanCarry(Cargo cargo) bool
    }

    class Car {
        -int passengerSeats
        +int PassengerSeats
        +Car()
        +Car(int id, string brand, string model, double maxLoad, double fuelConsumption, int passengerSeats)
        +GetInfo() string
    }

    class Truck {
        -bool hasTrailer
        +bool HasTrailer
        +Truck()
        +Truck(int id, string brand, string model, double maxLoad, double fuelConsumption, bool hasTrailer)
        +GetInfo() string
    }

    class Moto {
        -bool hasSidecar
        +bool HasSidecar
        +Moto()
        +Moto(int id, string brand, string model, double maxLoad, double fuelConsumption, bool hasSidecar)
        +GetInfo() string
    }

    class Driver {
        -int id
        -string fullName
        -string licenseCategory
        -int experienceYears
        +int Id
        +string FullName
        +string LicenseCategory
        +int ExperienceYears
        +Driver()
        +Driver(int id, string fullName, string licenseCategory, int experienceYears)
        +Driver(Driver other)
        +GetInfo() string
    }

    class Cargo {
        -int id
        -string name
        -double weight
        -string type
        +int Id
        +string Name
        +double Weight
        +string Type
        +Cargo()
        +Cargo(int id, string name, double weight, string type)
        +Cargo(Cargo other)
        +GetInfo() string
    }

    class Route {
        -int id
        -string startPoint
        -string endPoint
        -double distanceKm
        +int Id
        +string StartPoint
        +string EndPoint
        +double DistanceKm
        +Route()
        +Route(int id, string startPoint, string endPoint, double distanceKm)
        +Route(Route other)
        +GetInfo() string
    }

    class DeliveryOrder {
        -int id
        -Vehicle vehicle
        -Driver driver
        -Cargo cargo
        -Route route
        -OrderStatus status
        -double price
        +int Id
        +Vehicle Vehicle
        +Driver Driver
        +Cargo Cargo
        +Route Route
        +OrderStatus Status
        +double Price
        +DeliveryOrder()
        +DeliveryOrder(int id, Vehicle vehicle, Driver driver, Cargo cargo, Route route)
        +CalculatePrice() double
        +ChangeStatus(OrderStatus status) void
        +GetInfo() string
    }

    class OrderStatus {
        <<enumeration>>
        New
        InProgress
        Delivered
        Cancelled
    }

    class Fleet {
        -List~Vehicle~ vehicles
        -List~Driver~ drivers
        -List~DeliveryOrder~ orders
        +AddVehicle(Vehicle vehicle) void
        +AddDriver(Driver driver) void
        +AddOrder(DeliveryOrder order) void
        +FindVehicleById(int id) Vehicle
        +GetOrders() List~DeliveryOrder~
    }

    Vehicle <|-- Car
    Vehicle <|-- Truck
    Vehicle <|-- Moto

    DeliveryOrder --> Vehicle
    DeliveryOrder --> Driver
    DeliveryOrder --> Cargo
    DeliveryOrder --> Route
    DeliveryOrder --> OrderStatus

    Fleet o-- Vehicle
    Fleet o-- Driver
    Fleet o-- DeliveryOrder