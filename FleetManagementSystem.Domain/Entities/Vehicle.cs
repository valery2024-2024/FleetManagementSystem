namespace FleetManagementSystem.Domain.Entities;

public abstract class Vehicle
{
    private double _maxLoad;

    public int Id { get; private set; }
    public string Brand { get; private set; }

    public double MaxLoad
    {
        get => _maxLoad;
        set
        {
            if (value <= 0)
                throw new ArgumentException("Максимальне навантаження повинно бути > 0");
            _maxLoad = value;
        }
    }

    public double FuelConsumption { get; private set; }

    protected Vehicle(int id, string brand, double maxLoad, double fuelConsumption)
    {
        Id = id;
        Brand = brand;
        MaxLoad = maxLoad;
        FuelConsumption = fuelConsumption;
    }

    public bool CanCarry(Cargo cargo)
    {
        return cargo.Weight <= MaxLoad;
    }
}