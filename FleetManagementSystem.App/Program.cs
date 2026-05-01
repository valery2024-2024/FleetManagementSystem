using FleetManagementSystem.Domain.Entities;

Vehicle normalTruck = new Truck(1, "Volvo", 5000, 25, true);
Vehicle oldTruckAsVehicle = new OldTruck(2, "MAN", 4000, 22);

OldTruck oldTruckAsOldTruck = new OldTruck(3, "DAF", 3500, 20);

Console.WriteLine("override");
Console.WriteLine(normalTruck.GetVehicleType());

Console.WriteLine();

Console.WriteLine("new через Vehicle");
Console.WriteLine(oldTruckAsVehicle.GetVehicleType());

Console.WriteLine();

Console.WriteLine("new через OldTruck");
Console.WriteLine(oldTruckAsOldTruck.GetVehicleType());