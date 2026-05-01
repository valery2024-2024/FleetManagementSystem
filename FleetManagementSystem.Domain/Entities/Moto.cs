namespace FleetManagementSystem.Domain.Entities;

public class Moto : Vehicle
{
    public bool HasSidecar { get; private set; }

    public Moto(int id, string brand, double maxLoad, double fuelConsumption, bool hasSidecar)
        : base(id, brand, maxLoad, fuelConsumption)
    {
        HasSidecar = hasSidecar;
    }

    public override string GetInfo()
    {
        string sidecarInfo = HasSidecar ? "з коляскою" : "без коляски";

        return base.GetInfo() + $", тип: мотоцикл, {sidecarInfo}";
    }

    public override double CalculateDeliveryCost(Route route)
    {
        double baseCost = base.CalculateDeliveryCost(route);

        if (HasSidecar)
            return baseCost * 1.2;

        return baseCost;
    }

    public override string GetVehicleType()
    {
        return "Мотоцикл";
    }
}