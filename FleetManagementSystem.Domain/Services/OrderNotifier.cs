using FleetManagementSystem.Domain.Entities;

namespace FleetManagementSystem.Domain.Services;

public class OrderNotifier
{
    // подія
    public event EventHandler<DeliveryOrder>? OrderCreated;

    public void Notify(DeliveryOrder order)
    {
        OrderCreated?.Invoke(this, order);
    }
}