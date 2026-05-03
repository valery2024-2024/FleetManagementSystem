namespace FleetManagementSystem.Domain.Exceptions;

public class DeliveryException : Exception
{
    public DeliveryException(string message) : base(message)
    {
    }
}