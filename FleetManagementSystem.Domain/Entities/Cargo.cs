namespace FleetManagementSystem.Domain.Entities;

public class Cargo
{
    private double _weight;
    private string _name = string.Empty;

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

    // Конструктор
    public Cargo(int id, string name, double weight, string type)
    {
        Id = id;
        Name = name;
        Weight = weight;
        Type = type;
    }
}