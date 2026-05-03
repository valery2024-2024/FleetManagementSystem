using FleetManagementSystem.Domain.Entities;
using FleetManagementSystem.Domain.Services;
using FleetManagementSystem.Domain.Interfaces;

var route = new Route(1, "Рівне", "Львів", 200);
var truck = new Truck(1, "Volvo", 5000, 25, true);
var driver = new Driver(1, "Ivan", "C", 5);
var cargo = new Cargo(1, "Wood", 300, "Heavy");

var order = new DeliveryOrder(1, truck, driver, cargo, route);

// 🔥 різні реалізації
IDeliveryCostCalculator standard = new StandardDeliveryCalculator();
IDeliveryCostCalculator express = new ExpressDeliveryCalculator();

order.CalculatePrice(standard);
Console.WriteLine($"Standard: {order.Price}");

order.CalculatePrice(express);
Console.WriteLine($"Express: {order.Price}");