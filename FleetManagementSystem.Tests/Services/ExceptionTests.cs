using Xunit;
using FleetManagementSystem.Domain.Entities;
using FleetManagementSystem.Domain.Exceptions;

namespace FleetManagementSystem.Tests.Services;

public class ExceptionTests
{
    [Fact]
    public void Route_Should_Throw_Exception_When_Distance_Is_Zero()
    {
        // ARRANGE + ACT + ASSERT
        Assert.Throws<ArgumentException>(() =>
        {
            new Route(1, "Рівне", "Львів", 0);
        });
    }

    [Fact]
    public void Route_Should_Throw_Exception_When_Name_Is_Empty()
    {
        Assert.Throws<ArgumentException>(() =>
        {
            new Route(1, "", "Львів", 200);
        });
    }
}