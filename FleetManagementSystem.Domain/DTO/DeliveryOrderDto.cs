namespace FleetManagementSystem.Domain.DTO;

public class DeliveryOrderDto
{
    public int Id { get; set; }

    public string VehicleBrand { get; set; } = string.Empty;

    public string DriverName { get; set; } = string.Empty;

    public string CargoName { get; set; } = string.Empty;

    public double CargoWeight { get; set; }

    public string From { get; set; } = string.Empty;

    public string To { get; set; } = string.Empty;

    public double Distance { get; set; }

    public double Price { get; set; }
}