using FleetManagementSystem.Domain.Entities;
using FleetManagementSystem.Domain.Repositories;
using FleetManagementSystem.Domain.Utils;
using FleetManagementSystem.Domain.Exceptions;
using FleetManagementSystem.Domain.Interfaces;
using FleetManagementSystem.Domain.Services;
using FleetManagementSystem.Domain.Factories;
using FleetManagementSystem.Domain.DTO;
using System.Text.Json;

var logger = AppLogger.Instance;
logger.Log("Система запущена");

var vehicle = VehicleFactory.CreateVehicle("truck");
var calculator = DeliveryCalculatorFactory.Create("express");
var service = new DeliveryService(calculator);

var route = new Route(1, "Рівне", "Львів", 200);
var driver = new Driver(1, "Ivan", "C", 5);
var cargo = new Cargo(1, "Box", 100, "Standard");

var order = new DeliveryOrder(1, vehicle, driver, cargo, route);

service.CalculateOrderPrice(order);

Console.WriteLine($"Транспорт: {vehicle.Brand}");
Console.WriteLine($"Ціна доставки: {order.Price}");
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
    var badRoute = new Route(1, "Рівне", "Львів", 0); // помилка 
    var truck = new Truck(1, "Volvo", 100, 20, true);
    var badDriver = new Driver(1, "Ivan", "C", 5);
    var badCargo = new Cargo(1, "Metal", 500, "Heavy");

    var baOorder = new DeliveryOrder(1, truck, driver, cargo, route);
    
    service.CalculateOrderPrice(order);
    Console.WriteLine($"Ціна достав: {order.Price}");
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

Console.WriteLine(vehicle.Brand);

int attempt = 0;

RetryHelper.Retry(() =>
{
    attempt++;

    Console.WriteLine($"Спроба {attempt}");

    if (attempt < 3)
        throw new Exception("Помилка!");

    Console.WriteLine("Успіх!");
});
Console.WriteLine("\n_ _ _  PRACTICE 11 (Observer) _ _ _");

var notifier = new OrderNotifier();
var orderLogger = new OrderLogger();

// підписка
notifier.OrderCreated += orderLogger.OnOrderCreated;

// створення замовлення
var route2 = new Route(2, "Київ", "Львів", 300);
var driver2 = new Driver(2, "Petro", "C", 3);
var cargo2 = new Cargo(2, "Wood", 200, "Heavy");

var order2 = new DeliveryOrder(2, vehicle, driver2, cargo2, route2);

service.CalculateOrderPrice(order2);

// виклик події
notifier.Notify(order2);

// відписка (ВАЖЛИВО)
notifier.OrderCreated -= orderLogger.OnOrderCreated;

Console.WriteLine("\n_ _ _ PRACTICE 12 _ _ _");

// DECORATOR
var baseCalc = DeliveryCalculatorFactory.Create("standard");
var insuranceCalc = new InsuranceDecorator(baseCalc);

var serviceWithInsurance = new DeliveryService(insuranceCalc);

var route3 = new Route(3, "Рівне", "Київ", 370);
var driver3 = new Driver(3, "Oleh", "C", 4);
var cargo3 = new Cargo(3, "Glass", 100, "Fragile");

var order3 = new DeliveryOrder(3, vehicle, driver3, cargo3, route3);

serviceWithInsurance.CalculateOrderPrice(order3);
Console.WriteLine($"Ціна зі страховкою: {order3.Price}");


// FACADE
var facade = new DeliveryFacade();

var order4 = facade.CreateAndCalculate(
    4,
    "truck",
    "express",
    driver3,
    cargo3,
    route3
);

Console.WriteLine($"Facade ціна: {order4.Price}");


// COMPOSITE
var group = new CargoGroup();

group.Add(new Cargo(10, "Box", 100, "Standard"));
group.Add(new Cargo(11, "Metal", 200, "Heavy"));

Console.WriteLine($"Загальна вага групи: {group.GetWeight()}");

Console.WriteLine("\n_ _ _ PRACTICE 13 (JSON) _ _ _");

// створюємо об'єкт
var routeJson = new Route(10, "Рівне", "Київ", 300);
var driverJson = new Driver(10, "Ivan", "C", 5);
var cargoJson = new Cargo(10, "Box", 100, "Standard");

var orderJson = new DeliveryOrder(10, vehicle, driverJson, cargoJson, routeJson);

service.CalculateOrderPrice(orderJson);

// конвертація в DTO
var dto = DtoMapper.ToDto(orderJson);

// серіалізація
var json = JsonSerializer.Serialize(dto, new JsonSerializerOptions
{
    WriteIndented = true,
    Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
});

// запис у файл
File.WriteAllText("order.json", json);

Console.WriteLine("JSON записано в файл!");

// читання з файлу
var jsonFromFile = File.ReadAllText("order.json");

// десеріалізація
var loadedDto = JsonSerializer.Deserialize<DeliveryOrderDto>(jsonFromFile);

Console.WriteLine("\nЗчитано з JSON:");
Console.WriteLine($"{loadedDto.VehicleBrand} | {loadedDto.CargoName} | {loadedDto.Price}");