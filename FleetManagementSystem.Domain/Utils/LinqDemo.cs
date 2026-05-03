using System;
using System.Collections.Generic;
using System.Linq;
using FleetManagementSystem.Domain.Entities;

namespace FleetManagementSystem.Domain.Utils;

public static class LinqDemo
{
    public static void Run()
    {
        var cargos = new List<Cargo>
        {
            new Cargo(1, "Box", 100, "Standard"),
            new Cargo(2, "Wood", 200, "Heavy"),
            new Cargo(3, "Metal", 300, "Heavy"),
            new Cargo(4, "Glass", 50, "Fragile")
        };

        Console.WriteLine("_ _ _ WHERE _ _ _");

        var heavy = cargos.Where(c => c.Weight > 150);

        foreach (var c in heavy)
        {
            Console.WriteLine($"{c.Name} - {c.Weight}");
        }

        Console.WriteLine("\n_ _ _ SELECT _ _ _");

        var names = cargos.Select(c => c.Name);

        foreach (var name in names)
        {
            Console.WriteLine(name);
        }

        Console.WriteLine("\n_ _ _ ORDER BY _ _ _");

        var sorted = cargos.OrderBy(c => c.Weight);

        foreach (var c in sorted)
        {
            Console.WriteLine($"{c.Name} - {c.Weight}");
        }

        Console.WriteLine("\n_ _ _ GROUP BY _ _ _");

        var grouped = cargos.GroupBy(c => c.Type);

        foreach (var group in grouped)
        {
            Console.WriteLine($"Тип: {group.Key}");

            foreach (var c in group)
            {
                Console.WriteLine($"  {c.Name}");
            }
        }
    }
}