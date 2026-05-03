namespace FleetManagementSystem.Domain.Interfaces;

using FleetManagementSystem.Domain.Entities;

public interface IDeliveryCostCalculator
{
    double CalculateCost(Vehicle vehicle, Route route);
}