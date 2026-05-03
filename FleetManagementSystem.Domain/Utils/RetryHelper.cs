using System;

namespace FleetManagementSystem.Domain.Utils;

public static class RetryHelper
{
    public static void Retry(Action action, int attempts = 3)
    {
        int currentAttempt = 0;

        while (currentAttempt < attempts)
        {
            try
            {
                action();
                return;
            }
            catch (Exception ex)
            {
                currentAttempt++;

                Console.WriteLine($"Спроба {currentAttempt} не вдалась: {ex.Message}");

                if (currentAttempt == attempts)
                    throw;

                // затримка
                System.Threading.Thread.Sleep(1000 * currentAttempt);
            }
        }
    }
}