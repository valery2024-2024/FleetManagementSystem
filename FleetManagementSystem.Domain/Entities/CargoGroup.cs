namespace FleetManagementSystem.Domain.Entities;

public class CargoGroup : ICargoComponent
{
    private readonly List<ICargoComponent> _items = new();

    public void Add(ICargoComponent item)
    {
        _items.Add(item);
    }

    public double GetWeight()
    {
        return _items.Sum(i => i.GetWeight());
    }
}