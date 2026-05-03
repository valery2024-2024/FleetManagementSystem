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
        private set
        {
            if (value <= 0)
                throw new ArgumentException("Дистанція повинна бути більше 0");

            _distanceKm = value;
        }
    }

    public Route(int id, string startPoint, string endPoint, double distanceKm)
    {
        if (string.IsNullOrWhiteSpace(startPoint))
            throw new ArgumentException("Початкова точка не може бути пустою");

        if (string.IsNullOrWhiteSpace(endPoint))
            throw new ArgumentException("Кінцева точка не може бути пустою");

        if (startPoint == endPoint)
            throw new ArgumentException("Початкова і кінцева точка не можуть співпадати");

        Id = id;
        StartPoint = startPoint;
        EndPoint = endPoint;
        DistanceKm = distanceKm;
    }
}