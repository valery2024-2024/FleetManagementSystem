using System.Collections.Generic;

namespace FleetManagementSystem.Domain.Repositories;

public class Repository<T>
{
    private readonly List<T> _items = new();

    public void Add(T item)
    {
        if (item == null)
            throw new ArgumentNullException(nameof(item));

        _items.Add(item);
    }

    public void Remove(T item)
    {
        _items.Remove(item);
    }

    public List<T> GetAll()
    {
        return _items;
    }

    public T? GetByIndex(int index)
    {
        if (index < 0 || index >= _items.Count)
            return default;

        return _items[index];
    }
}