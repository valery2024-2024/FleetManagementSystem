namespace FleetManagementSystem.Domain.Entities;

public abstract class Vehicle
{
    private string _brand = string.Empty;
    private double _maxLoad;
    private double _fuelConsumption;

    public int Id { get; private set; }

    public string Brand
    {
        get => _brand;
        private set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Марка транспорту не може бути пустою");

            _brand = value;
        }
    }

    public double MaxLoad
    {
        get => _maxLoad;
        private set
        {
            if (value <= 0)
                throw new ArgumentException("Максимальне навантаження повинно бути більше 0");

            _maxLoad = value;
        }
    }

    public double FuelConsumption
    {
        get => _fuelConsumption;
        private set
        {
            if (value <= 0)
                throw new ArgumentException("Витрата палива повинна бути більше 0");

            _fuelConsumption = value;
        }
    }

    protected Vehicle(int id, string brand, double maxLoad, double fuelConsumption)
    {
        Id = id;
        Brand = brand;
        MaxLoad = maxLoad;
        FuelConsumption = fuelConsumption;
    }

    public bool CanCarry(Cargo cargo)
    {
        if (cargo is null)
            throw new ArgumentNullException(nameof(cargo));

        return cargo.Weight <= MaxLoad;
    }

    // virtual — метод можна перевизначити у дочірніх класах
    public virtual string GetInfo()
    {
        return $"Транспорт: {Brand}, вантажопідйомність: {MaxLoad} кг, витрата палива: {FuelConsumption} л/100км";
    }

    // virtual — базовий розрахунок вартості
    public virtual double CalculateDeliveryCost(Route route)
    {
        if (route == null)
            throw new ArgumentNullException(nameof(route));

        return route.DistanceKm * FuelConsumption;
    }

    // virtual — тип транспорту
    public virtual string GetVehicleType()
    {
        return "Звичайний транспорт";
    }
}