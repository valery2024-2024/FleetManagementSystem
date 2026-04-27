namespace FleetManagementSystem.Domain.Entities;
public class Truck : Vehicle
{
    public bool HasTrailer { get; private set; }

    public Truck(int id, string brand, double maxLoad, double fuelConsumption, bool hasTrailer)
        : base(id, brand, maxLoad, fuelConsumption)
    {
        HasTrailer = hasTrailer;
    }
}