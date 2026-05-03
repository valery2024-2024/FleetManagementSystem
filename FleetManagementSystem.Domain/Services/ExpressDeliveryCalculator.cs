using FleetManagementSystem.Domain.Entities;
using FleetManagementSystem.Domain.Interfaces;

namespace FleetManagementSystem.Domain.Services;

public class ExpressDeliveryCalculator : IDeliveryCostCalculator
{
    public double CalculateCost(Vehicle vehicle, Route route)
    {
        return route.DistanceKm * vehicle.FuelConsumption * 1.5;
    }
}