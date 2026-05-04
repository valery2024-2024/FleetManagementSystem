using Xunit;
using Moq;
using FleetManagementSystem.Domain.Entities;
using FleetManagementSystem.Domain.Services;
using FleetManagementSystem.Domain.Interfaces;

namespace FleetManagementSystem.Tests.Services;

public class DeliveryServiceTests
{
    [Fact]
    public void CalculateOrderPrice_Should_SetPrice()
    {
        // ARRANGE
        var mockCalculator = new Mock<IDeliveryCostCalculator>();

        mockCalculator
            .Setup(c => c.CalculateCost(It.IsAny<Vehicle>(), It.IsAny<Route>()))
            .Returns(5000);

        var service = new DeliveryService(mockCalculator.Object);

        var route = new Route(1, "Рівне", "Львів", 200);
        var truck = new Truck(1, "Volvo", 1000, 20, true);
        var driver = new Driver(1, "Ivan", "C", 5);
        var cargo = new Cargo(1, "Box", 100, "Standard");

        var order = new DeliveryOrder(1, truck, driver, cargo, route);

        // ACT
        service.CalculateOrderPrice(order);

        // ASSERT
        Assert.Equal(5000, order.Price);
    }

    [Fact]
    public void CalculateOrderPrice_Should_CallCalculator()
    {
        // ARRANGE
        var mockCalculator = new Mock<IDeliveryCostCalculator>();

        mockCalculator
            .Setup(c => c.CalculateCost(It.IsAny<Vehicle>(), It.IsAny<Route>()))
            .Returns(3000);

        var service = new DeliveryService(mockCalculator.Object);

        var route = new Route(1, "Рівне", "Львів", 200);
        var truck = new Truck(1, "Volvo", 1000, 20, true);
        var driver = new Driver(1, "Ivan", "C", 5);
        var cargo = new Cargo(1, "Box", 100, "Standard");

        var order = new DeliveryOrder(1, truck, driver, cargo, route);

        // ACT
        service.CalculateOrderPrice(order);

        // ASSERT
        mockCalculator.Verify(
            c => c.CalculateCost(It.IsAny<Vehicle>(), It.IsAny<Route>()),
            Times.Once
        );
    }
}