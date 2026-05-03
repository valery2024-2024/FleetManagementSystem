using System;
using System.Collections.Generic;
using FleetManagementSystem.Domain.Entities;

namespace FleetManagementSystem.Domain.Utils;

public static class CollectionDemo
{
    public static void Run()
    {
        Console.WriteLine("_ _ _ List _ _ _ ");

        List<Cargo> cargoList = new()
        {
            new Cargo(1, "Box", 100, "Standard"),
            new Cargo(2, "Wood", 200, "Heavy"),
            new Cargo(3, "Metal", 300, "Heavy")
        };

        foreach (var c in cargoList)
        {
            Console.WriteLine($"{c.Name} - {c.Weight}");
        }

        Console.WriteLine("\n_ _ _ Dictionary _ _ _");

        Dictionary<int, Cargo> cargoDict = new();

        foreach (var c in cargoList)
        {
            cargoDict[c.Id] = c;
        }

        // швидкий пошук
        if (cargoDict.TryGetValue(2, out var found))
        {
            Console.WriteLine($"Знайдено: {found.Name}");
        }

        Console.WriteLine("\n_ _ _ HashSet _ _ _");

        HashSet<string> cargoTypes = new();

        foreach (var c in cargoList)
        {
            cargoTypes.Add(c.Type);
        }

        foreach (var type in cargoTypes)
        {
            Console.WriteLine(type);
        }
    }
}