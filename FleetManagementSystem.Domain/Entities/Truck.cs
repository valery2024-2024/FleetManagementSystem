namespace FleetManagementSystem.Domain.Entities;

public class Truck : Vehicle
{
    public bool HasTrailer { get; private set; }

    public Truck(int id, string brand, double maxLoad, double fuelConsumption, bool hasTrailer)
        : base(id, brand, maxLoad, fuelConsumption)
    {
        HasTrailer = hasTrailer;
    }

    public override string GetInfo()
    {
        string trailerInfo = HasTrailer ? "з причепом" : "без причепа";

        return base.GetInfo() + $", тип: вантажівка, {trailerInfo}";
    }

    public override double CalculateDeliveryCost(Route route)
    {
        double baseCost = base.CalculateDeliveryCost(route);

        if (HasTrailer)
            return baseCost * 1.5;

        return baseCost * 1.3;
    }

    public override string GetVehicleType()
    {
        return "Вантажівка";
    }
}