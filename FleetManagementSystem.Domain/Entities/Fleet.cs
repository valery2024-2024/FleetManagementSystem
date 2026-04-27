using System.Collections.Generic;
using System.Linq;

namespace FleetManagementSystem.Domain.Entities;

public class Fleet
{
    private List<Vehicle> _vehicles = new();

    // додати транспорт
    public void AddVehicle(Vehicle vehicle)
    {
        if (vehicle == null)
            throw new ArgumentNullException(nameof(vehicle));

        _vehicles.Add(vehicle);
    }

    // індексатор
    public Vehicle this[int index]
    {
        get
        {
            if (index < 0 || index >= _vehicles.Count)
                throw new IndexOutOfRangeException("Невірний індекс");

            return _vehicles[index];
        }
    }

    // агрегація (сума ваги)
    public double GetTotalCargoWeight(List<Cargo> cargos)
    {
        return cargos.Sum(c => c.Weight);
    }
}