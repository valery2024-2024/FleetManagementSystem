using FleetManagementSystem.Domain.Entities;

namespace FleetManagementSystem.Domain.Factories;

public static class VehicleFactory
{
    public static Vehicle CreateVehicle(string type)
    {
        return type.ToLower() switch
        {
            "truck" => new Truck(1, "Volvo", 5000, 25, true),
            "car" => new Car(2, "Toyota", 500, 8, 5),
            _ => throw new ArgumentException("Невідомий тип транспорту")
        };
    }
}