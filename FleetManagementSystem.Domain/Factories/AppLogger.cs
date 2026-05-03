using FleetManagementSystem.Domain.Interfaces;

namespace FleetManagementSystem.Domain.Services;

public class AppLogger : ILogger
{
    private static AppLogger? _instance;

    private AppLogger() { }

    public static AppLogger Instance
    {
        get
        {
            if (_instance == null)
                _instance = new AppLogger();

            return _instance;
        }
    }

    public void Log(string message)
    {
        Console.WriteLine($"[LOG]: {message}");
    }
}