namespace FleetManagementSystem.Domain.Exceptions;

public class InvalidRouteException : DeliveryException
{
    public InvalidRouteException(string message) : base(message)
    {
    }
}