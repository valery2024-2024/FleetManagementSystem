using FleetManagementSystem.Domain.Entities;
using FleetManagementSystem.Domain.Repositories;
using FleetManagementSystem.Domain.Utils;

// 🔹 Repository
var cargoRepo = new Repository<Cargo>();

cargoRepo.Add(new Cargo(1, "Box", 100, "Standard"));
cargoRepo.Add(new Cargo(2, "Wood", 200, "Heavy"));

var cargos = cargoRepo.GetAll();

// ForEach - для кожного
Console.WriteLine("ForEach:");
FunctionalHelper.ForEach(cargos, c =>
{
    Console.WriteLine($"{c.Name} - {c.Weight}");
});

// Map - карта
Console.WriteLine("\nMap:");
var weights = FunctionalHelper.Map(cargos, c => c.Weight);

foreach (var w in weights)
{
    Console.WriteLine(w);
}

// Reduce - зменшити
Console.WriteLine("\nReduce:");
var totalWeight = FunctionalHelper.Reduce(cargos, 0.0, (sum, c) => sum + c.Weight);

Console.WriteLine($"Total weight: {totalWeight}");