using FleetManagementSystem.Domain.Entities;
using FleetManagementSystem.Domain.Factories;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using System.Text.Json;

Console.WriteLine("[LOG] Система запущена");

Console.WriteLine("\n===== СТВОРЕННЯ ЗАМОВЛЕННЯ =====");

// Підказка
Console.WriteLine("\nДоступні типи доставки:");
Console.WriteLine("✔ standard - звичайна");
Console.WriteLine("✔ express - швидка");

// Тип доставки
string deliveryType;
while (true)
{
    Console.Write("Введіть тип доставки: ");
    deliveryType = Console.ReadLine()?.ToLower()!;

    if (deliveryType == "standard" || deliveryType == "express")
        break;

    Console.WriteLine("= = = Введіть тільки: standard або express = = =");
}

// Міста
Console.Write("Введіть місто відправки: ");
string from = Console.ReadLine()!;

Console.Write("Введіть місто прибуття: ");
string to = Console.ReadLine()!;

// Дистанція
double distance;
while (true)
{
    Console.Write("Введіть дистанцію (км): ");
    if (double.TryParse(Console.ReadLine(), out distance) && distance > 0)
        break;

    Console.WriteLine("= = = Введіть коректне число! = = =");
}

// Водій
Console.Write("Введіть ім'я водія: ");
string driverName = Console.ReadLine()!;

Console.Write("Введіть категорію прав водія: ");
string license = Console.ReadLine()!;

// Стаж
int experience;
while (true)
{
    Console.Write("Введіть стаж водія (роки): ");
    if (int.TryParse(Console.ReadLine(), out experience) && experience >= 0)
        break;

    Console.WriteLine("= = = Введіть число! = = =");
}

// Назва вантажу
string cargoName;
while (true)
{
    Console.Write("Введіть назву вантажу: ");
    cargoName = Console.ReadLine()!;

    if (!string.IsNullOrWhiteSpace(cargoName))
        break;

    Console.WriteLine("= = = Назва не може бути пустою! = = =");
}

// Вага
double cargoWeight;
while (true)
{
    Console.Write("Введіть вагу вантажу (кг): ");
    if (double.TryParse(Console.ReadLine(), out cargoWeight) && cargoWeight > 0)
        break;

    Console.WriteLine("= = = Введіть коректну вагу! = = =");
}

// Тип вантажу (будь-який текст)
Console.Write("Введіть тип вантажу (наприклад: папери, техніка): ");
string cargoType = Console.ReadLine()!;

// Створення об'єктів
var route = new Route(1, from, to, distance);
var driver = new Driver(1, driverName, license, experience);
var cargo = new Cargo(1, cargoName, cargoWeight, cargoType);

// Підказка по транспорту
Console.WriteLine("\nПідбір транспорту:");
Console.WriteLine("до 50 кг = мото");
Console.WriteLine("до 500 кг = авто");
Console.WriteLine("більше = вантажівка");

// Транспорт
var fleet = new List<Vehicle>
{
    VehicleFactory.CreateVehicle("moto"),
    VehicleFactory.CreateVehicle("car"),
    VehicleFactory.CreateVehicle("truck")
};

// Вибір транспорту
Vehicle selectedVehicle = fleet.FirstOrDefault(v => v.CanCarry(cargo))!;

if (selectedVehicle == null)
{
    Console.WriteLine("= = = Немає транспорту для цього вантажу! = = =");
    return;
}

try
{
    var order = new DeliveryOrder(1, selectedVehicle, driver, cargo, route);
    Console.WriteLine("= = = Замовлення успішно створено = = =");
}
catch (Exception ex)
{
    Console.WriteLine($"Помилка: {ex.Message}");
    return;
}

// Розрахунок ціни
double cost = selectedVehicle.CalculateDeliveryCost(route);

// Express
if (deliveryType == "express")
{
    cost *= 1.2;
}

// Вивід
Console.WriteLine("\n===== РЕЗУЛЬТАТ =====");
Console.WriteLine($"Маршрут: {from} → {to}");
Console.WriteLine($"Дистанція: {distance} км");
Console.WriteLine($"Транспорт: {selectedVehicle.Brand}");
Console.WriteLine($"Тип транспорту: {selectedVehicle.GetVehicleType()}");
Console.WriteLine($"Водій: {driverName}");
Console.WriteLine($"Вантаж: {cargoName}");
Console.WriteLine($"Вага: {cargoWeight} кг");
Console.WriteLine($"Тип доставки: {deliveryType}");
Console.WriteLine($"Ціна доставки: {cost}");

// JSON
Console.WriteLine("\n===== ЗБЕРЕЖЕННЯ В JSON =====");

var orderJson = new
{
    From = from,
    To = to,
    Distance = distance,
    Vehicle = selectedVehicle.Brand,
    Cargo = cargoName,
    Cost = cost
};

string json = JsonSerializer.Serialize(orderJson, new JsonSerializerOptions 
{ 
    WriteIndented = true, 
    Encoder = JavaScriptEncoder.Create(UnicodeRanges.All)
});
File.WriteAllText("order.json", json);

Console.WriteLine("✔ Збережено у order.json");

// Читання
Console.WriteLine("\n===== ЗЧИТУВАННЯ JSON =====");
string readJson = File.ReadAllText("order.json");
Console.WriteLine(readJson);

Console.WriteLine("\n[LOG] Завершення роботи системи");