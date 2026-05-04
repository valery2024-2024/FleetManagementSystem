using Xunit;
using Moq;
using FleetManagementSystem.Domain.Interfaces;

namespace FleetManagementSystem.Tests.Services;

public class LoggerTests
{
    [Fact]
    public void Logger_Should_Be_Called()
    {
        // ARRANGE
        var mockLogger = new Mock<ILogger>();

        // ACT
        mockLogger.Object.Log("Test message");

        // ASSERT
        mockLogger.Verify(
            l => l.Log("Test message"),
            Times.Once
        );
    }
}