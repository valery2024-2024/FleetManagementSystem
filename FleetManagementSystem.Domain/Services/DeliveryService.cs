using FleetManagementSystem.Domain.Entities;
using FleetManagementSystem.Domain.Interfaces;

namespace FleetManagementSystem.Domain.Services;

public class DeliveryService
{
    private readonly IDeliveryCostCalculator _calculator;

    public DeliveryService(IDeliveryCostCalculator calculator)
    {
        _calculator = calculator;
    }

    public void CalculateOrderPrice(DeliveryOrder order)
    {
        if (order == null)
            throw new ArgumentNullException(nameof(order));

        order.CalculatePrice(_calculator);
    }
}