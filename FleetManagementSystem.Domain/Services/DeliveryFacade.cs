using FleetManagementSystem.Domain.Entities;
using FleetManagementSystem.Domain.Factories;
using FleetManagementSystem.Domain.Interfaces;

namespace FleetManagementSystem.Domain.Services;

public class DeliveryFacade
{
    public DeliveryOrder CreateAndCalculate(
        int id,
        string vehicleType,
        string calcType,
        Driver driver,
        Cargo cargo,
        Route route)
    {
        var vehicle = VehicleFactory.CreateVehicle(vehicleType);
        var calculator = DeliveryCalculatorFactory.Create(calcType);

        var service = new DeliveryService(calculator);

        var order = new DeliveryOrder(id, vehicle, driver, cargo, route);

        service.CalculateOrderPrice(order);

        return order;
    }
}