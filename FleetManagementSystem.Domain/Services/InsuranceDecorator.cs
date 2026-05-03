using FleetManagementSystem.Domain.Entities;
using FleetManagementSystem.Domain.Interfaces;

namespace FleetManagementSystem.Domain.Services;

public class InsuranceDecorator : IDeliveryCostCalculator
{
    private readonly IDeliveryCostCalculator _inner;

    public InsuranceDecorator(IDeliveryCostCalculator inner)
    {
        _inner = inner;
    }

    public double CalculateCost(Vehicle vehicle, Route route)
    {
        var basePrice = _inner.CalculateCost(vehicle, route);

        // +10% страхування
        return basePrice * 1.1;
    }
}