using FleetManagementSystem.Domain.DTO;
using FleetManagementSystem.Domain.Entities;


namespace FleetManagementSystem.Domain.Utils;

public static class DtoMapper
{
    public static DeliveryOrderDto ToDto(DeliveryOrder order)
    {
        return new DeliveryOrderDto
        {
            Id = order.Id,
            VehicleBrand = order.Vehicle.Brand,
            DriverName = order.Driver.FullName,
            CargoName = order.Cargo.Name,
            CargoWeight = order.Cargo.Weight,
            From = order.Route.StartPoint,
            To = order.Route.EndPoint,
            Distance = order.Route.DistanceKm,
            Price = order.Price
        };
    }
}