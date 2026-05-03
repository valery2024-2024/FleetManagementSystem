using System;
using System.Collections.Generic;

namespace FleetManagementSystem.Domain.Utils;

public static class FunctionalHelper
{
    // ForEach - для кожного
    public static void ForEach<T>(List<T> items, Action<T> action)
    {
        foreach (var item in items)
        {
            action(item);
        }
    }

    // Map - карта
    public static List<TResult> Map<T, TResult>(List<T> items, Func<T, TResult> func)
    {
        var result = new List<TResult>();

        foreach (var item in items)
        {
            result.Add(func(item));
        }

        return result;
    }

    // Reduce - зменшити
    public static TResult Reduce<T, TResult>(
        List<T> items,
        TResult initialValue,
        Func<TResult, T, TResult> func)
    {
        TResult result = initialValue;

        foreach (var item in items)
        {
            result = func(result, item);
        }

        return result;
    }
}