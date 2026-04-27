using FleetManagementSystem.Domain.Entities;

var cargo1 = new Cargo(1, "Box", 100, "Standard");
var cargo2 = new Cargo(2, "Wood", 200, "Heavy");

// оператор +
var totalCargo = cargo1 + cargo2;
Console.WriteLine($"Total weight: {totalCargo.Weight}");

// оператор ==
Console.WriteLine(cargo1 == cargo2);

// індексатор
var fleet = new Fleet();
fleet.AddVehicle(new Truck(1, "Volvo", 1000, 20, true));

Console.WriteLine(fleet[0].Brand);