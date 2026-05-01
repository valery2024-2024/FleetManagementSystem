namespace FleetManagementSystem.Domain.Entities;

public class Car : Vehicle
{
    public int PassengerSeats { get; private set; }

    public Car(int id, string brand, double maxLoad, double fuelConsumption, int passengerSeats)
        : base(id, brand, maxLoad, fuelConsumption)
    {
        if (passengerSeats <= 0)
            throw new ArgumentException("Кількість місць повинна бути більше 0");

        PassengerSeats = passengerSeats;
    }

    // override - перевизначення методу батьківського класу
    public override string GetInfo()
    {
        return base.GetInfo() + $", тип: легковий автомобіль, місць: {PassengerSeats}";
    }

    public override double CalculateDeliveryCost(Route route)
    {
        return base.CalculateDeliveryCost(route) * 1.1;
    }

    public override string GetVehicleType()
    {
        return "Легковий автомобіль";
    }
}