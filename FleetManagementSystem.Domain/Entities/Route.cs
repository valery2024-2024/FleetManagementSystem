namespace FleetManagementSystem.Domain.Entities;

public class Route
{
    private double _distanceKm;

    public int Id { get; private set; }

    public string StartPoint { get; private set; }
    public string EndPoint { get; private set; }

    public double DistanceKm
    {
        get => _distanceKm;
        set
        {
            if (value <= 0)
                throw new ArgumentException("Дистанція повинна бути більше 0");

            _distanceKm = value;
        }
    }

    public Route(int id, string startPoint, string endPoint, double distanceKm)
    {
        if (string.IsNullOrWhiteSpace(startPoint) || string.IsNullOrWhiteSpace(endPoint))
            throw new ArgumentException("Маршрут не може бути пустим");

        Id = id;
        StartPoint = startPoint;
        EndPoint = endPoint;
        DistanceKm = distanceKm;
    }
}