using FleetManagementSystem.Domain.Entities;
using FleetManagementSystem.Domain.Repositories;
using FleetManagementSystem.Domain.Utils;
using FleetManagementSystem.Domain.Exceptions;

// Repository
var cargoRepo = new Repository<Cargo>();

cargoRepo.Add(new Cargo(1, "Box", 100, "Standard"));
cargoRepo.Add(new Cargo(2, "Wood", 200, "Heavy"));

var cargos = cargoRepo.GetAll();

// ForEach - для кожного
Console.WriteLine("_ _ _ ForEach:_ _ _");
FunctionalHelper.ForEach(cargos, c =>
{
    Console.WriteLine($"{c.Name} - {c.Weight}");
});

// Map - карта
Console.WriteLine("\n_ _ _ Map:_ _ _");
var weights = FunctionalHelper.Map(cargos, c => c.Weight);

foreach (var w in weights)
{
    Console.WriteLine(w);
}

// Reduce - зменшити
Console.WriteLine("\n_ _ _ Reduce:_ _ _");
var totalWeight = FunctionalHelper.Reduce(cargos, 0.0, (sum, c) => sum + c.Weight);

Console.WriteLine($"Total weight: {totalWeight}");

CollectionDemo.Run();

PerformanceTest.Run();

LinqDemo.Run();

LinqAdvanced.Run();

try
{
    var route = new Route(1, "Рівне", "Львів", 0); // помилка 
    var truck = new Truck(1, "Volvo", 100, 20, true);
    var driver = new Driver(1, "Ivan", "C", 5);
    var cargo = new Cargo(1, "Metal", 500, "Heavy");

    var order = new DeliveryOrder(1, truck, driver, cargo, route);
}
catch (InvalidRouteException ex)
{
    Console.WriteLine($"Route error: {ex.Message}");
}
catch (OverweightException ex)
{
    Console.WriteLine($"Weight error: {ex.Message}");
}
catch (Exception ex)
{
    Console.WriteLine($"Unknown error: {ex.Message}");
}
finally
{
    Console.WriteLine("Завершення перевірки");
}

using (var writer = new StreamWriter("log.txt", true))
{
    writer.WriteLine("Test log");
}

int attempt = 0;

RetryHelper.Retry(() =>
{
    attempt++;

    Console.WriteLine($"Спроба {attempt}");

    if (attempt < 3)
        throw new Exception("Помилка!");

    Console.WriteLine("Успіх!");
});