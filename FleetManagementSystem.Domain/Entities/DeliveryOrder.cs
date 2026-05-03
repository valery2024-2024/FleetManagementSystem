namespace FleetManagementSystem.Domain.Entities;
using FleetManagementSystem.Domain.Interfaces;
using FleetManagementSystem.Domain.Exceptions;
public class DeliveryOrder
{
    public int Id { get; private set; }
    public Vehicle Vehicle { get; private set; }
    public Driver Driver { get; private set; }
    public Cargo Cargo { get; private set; }
    public Route Route { get; private set; }

    public double Price { get; private set; }

    public DeliveryOrder(int id, Vehicle vehicle, Driver driver, Cargo cargo, Route route)
    {
        Vehicle = vehicle ?? throw new ArgumentNullException(nameof(vehicle));
        Driver = driver ?? throw new ArgumentNullException(nameof(driver));
        Cargo = cargo ?? throw new ArgumentNullException(nameof(cargo));
        Route = route ?? throw new ArgumentNullException(nameof(route));

        if (!vehicle.CanCarry(cargo))
            throw new OverweightException("Транспорт не може перевезти цей вантаж");

        if (route.DistanceKm <= 0)
            throw new InvalidRouteException("Некоректний маршрут");    

        Id = id;
    }

    public void CalculatePrice(IDeliveryCostCalculator calculator)
    {
        if (calculator == null)throw new ArgumentNullException(nameof(calculator));
        Price = calculator.CalculateCost(Vehicle, Route);
    }
}