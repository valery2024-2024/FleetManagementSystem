using FleetManagementSystem.Domain.Interfaces;
using FleetManagementSystem.Domain.Services;

namespace FleetManagementSystem.Domain.Factories;

public static class DeliveryCalculatorFactory
{
    public static IDeliveryCostCalculator Create(string type)
    {
        return type.ToLower() switch
        {
            "standard" => new StandardDeliveryCalculator(),
            "express" => new ExpressDeliveryCalculator(),
            _ => throw new ArgumentException("Невідомий тип доставки")
        };
    }
}