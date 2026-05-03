using System;
using System.Collections.Generic;
using System.Diagnostics;
using FleetManagementSystem.Domain.Entities;

namespace FleetManagementSystem.Domain.Utils;

public static class PerformanceTest
{
    public static void Run()
    {
        int size = 5000000;

        List<Cargo> list = new();
        Dictionary<int, Cargo> dict = new();

        // Заповнення
        for (int i = 0; i < size; i++)
        {
            var cargo = new Cargo(i, $"Cargo{i}", i + 1, "Test");
            list.Add(cargo);
            dict[i] = cargo;
        }

        var stopwatch = new Stopwatch();

        // Пошук у List
        stopwatch.Start();

        var item = list.Find(c => c.Id == size - 1);

        stopwatch.Stop();
        Console.WriteLine($"List search: {stopwatch.ElapsedMilliseconds} ms");

        // Пошук у Dictionary
        stopwatch.Restart();

        dict.TryGetValue(size - 1, out var item2);

        stopwatch.Stop();
        Console.WriteLine($"Dictionary search: {stopwatch.ElapsedMilliseconds} ms");
    }
}