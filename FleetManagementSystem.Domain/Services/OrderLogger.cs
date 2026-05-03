using FleetManagementSystem.Domain.Entities;

namespace FleetManagementSystem.Domain.Services;

public class OrderLogger
{
    public void OnOrderCreated(object? sender, DeliveryOrder order)
    {
        Console.WriteLine($"[EVENT] Створено замовлення #{order.Id}, ціна: {order.Price}");
    }
}