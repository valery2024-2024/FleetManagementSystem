namespace FleetManagementSystem.Domain.Exceptions;

public class OverweightException : DeliveryException
{
    public OverweightException(string message) : base(message)
    {
    }
}