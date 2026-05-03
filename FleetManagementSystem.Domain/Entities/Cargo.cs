namespace FleetManagementSystem.Domain.Entities;

public class Cargo : ICargoComponent
{
    private string _name = string.Empty;
    private double _weight;
    public double GetWeight()
    {
        return Weight;
    }

    public int Id { get; private set; }

    public string Name
    {
        get => _name;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Назва вантажу не може бути пустою");

            _name = value;
        }
    }

    

    public double Weight
    {
        get => _weight;
        set
        {
            if (value <= 0)
                throw new ArgumentException("Вага повинна бути більше 0");

            _weight = value;
        }
    }

    public string Type { get; private set; }

    public Cargo(int id, string name, double weight, string type)
    {
        Id = id;
        Name = name;
        Weight = weight;
        Type = type;
    }

    // оператор +
    public static Cargo operator +(Cargo a, Cargo b)
    {
        if (a is null || b is null)
            throw new ArgumentNullException("Cargo cannot be null");

        return new Cargo(
            id: 0,
            name: a.Name + " + " + b.Name,
            weight: a.Weight + b.Weight,
            type: a.Type
        );
    }

    // оператор ==
    public static bool operator ==(Cargo a, Cargo b)
    {
        if (ReferenceEquals(a, b)) return true;
        if (a is null || b is null) return false;

        return a.Id == b.Id;
    }

    // оператор !=
    public static bool operator !=(Cargo a, Cargo b)
    {
        return !(a == b);
    }

    public override bool Equals(object? obj)
    {
        if (obj is Cargo other)
            return this == other;

        return false;
    }

    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }
}