using System;
using System.Reactive.Linq;

class Program
{
    static void Main()
    {
        Random random = new Random();

        var randomNumbers = Observable
            .Interval(TimeSpan.FromMilliseconds(500))
            .Select(_ => random.Next(1, 101))
            .Where(x => x > 50)
            .TakeUntil(
                Observable.Timer(TimeSpan.FromSeconds(10))
            );

        randomNumbers.Subscribe(
            x => Console.WriteLine($"Полученное число: {x}"),
            ex => Console.WriteLine($"Ошибка: {ex.Message}"),
            () => Console.WriteLine("Конец генерации")
        );

        Console.ReadLine();
    }
}
