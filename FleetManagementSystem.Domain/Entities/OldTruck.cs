namespace FleetManagementSystem.Domain.Entities;

public class OldTruck : Vehicle
{
    public OldTruck(int id, string brand, double maxLoad, double fuelConsumption)
        : base(id, brand, maxLoad, fuelConsumption)
    {
    }

    // new — застосування методу, який не перевизначає, а приховує його
    public new string GetVehicleType()
    {
        return "Старий вантажний транспорт";
    }
}