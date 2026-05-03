using System;
using System.Collections.Generic;
using System.Linq;
using FleetManagementSystem.Domain.Entities;
using FleetManagementSystem.Domain.Services;

namespace FleetManagementSystem.Domain.Utils;

public static class LinqAdvanced
{
    public static void Run()
    {
        var cargos = new List<Cargo>
        {
            new Cargo(1, "Box", 100, "Standard"),
            new Cargo(2, "Wood", 200, "Heavy"),
            new Cargo(3, "Metal", 300, "Heavy")
        };

        var routes = new List<Route>
        {
            new Route(1, "Київ", "Львів", 500),
            new Route(2, "Рівне", "Одеса", 700)
        };

        var orders = new List<DeliveryOrder>
        {
            new DeliveryOrder(1, new Truck(1, "Volvo", 5000, 25, true), 
                new Driver(1,"Ivan","C",5), cargos[0], routes[0]),

            new DeliveryOrder(2, new Truck(2, "MAN", 4000, 20, false), 
                new Driver(2,"Petro","C",3), cargos[1], routes[1])
        };

        orders.ForEach(o => o.CalculatePrice(new StandardDeliveryCalculator()));

        Console.WriteLine("_ _ _ JOIN _ _ _");

        var joined = orders.Join(
            cargos,
            o => o.Cargo.Id,
            c => c.Id,
            (o, c) => new
            {
                CargoName = c.Name,
                Price = o.Price
            });

        foreach (var item in joined)
        {
            Console.WriteLine($"{item.CargoName} - {item.Price}");
        }

        Console.WriteLine("\n_ _ _ AGGREGATE _ _ _");

        var total = orders.Aggregate(0.0, (sum, o) => sum + o.Price);

        Console.WriteLine($"Total price: {total}");
    }
}