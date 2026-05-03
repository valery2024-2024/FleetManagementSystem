using FleetManagementSystem.Domain.Entities;
using FleetManagementSystem.Domain.Repositories;
using FleetManagementSystem.Domain.Utils;

// 🔹 Repository
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