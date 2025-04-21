using System;

class Program
{
    static double ReadDouble(string prompt)
    {
        double number;
        while (true)
        {
            Console.Write(prompt);
            if (double.TryParse(Console.ReadLine(), out number))
                return number;
            Console.WriteLine("Ошибка ввода. Пожалуйста, введите корректное число.");
        }
    }

    static void Main(string[] args)
    {
        Console.WriteLine("Введите координаты первой точки:");
        double x1 = ReadDouble("Введите координату X: ");
        double y1 = ReadDouble("Введите координату Y: ");

        Console.WriteLine("\nВведите координаты второй точки:");
        double x2 = ReadDouble("Введите координату X: ");
        double y2 = ReadDouble("Введите координату Y: ");

        Point p1 = new Point(x1, y1);
        Point p2 = new Point(x2, y2);

        Console.WriteLine("\nТестирование задания 2:");
        Console.WriteLine(p1.ToString());
        Console.WriteLine(p2.ToString());
        Console.WriteLine($"Расстояние между точками: {p1.DistanceTo(p2)}");

        Console.WriteLine("\nТестирование задания 3:");

        Console.WriteLine("\nУнарные операции:");
        Console.WriteLine("Исходная p1: " + p1);
        p1++;
        Console.WriteLine("После p1++: " + p1);
        p1--;
        Console.WriteLine("После p1--: " + p1);

        Console.WriteLine("\nОперации приведения типов:");
        int xInt = (int)p1;
        double yDouble = p1;
        Console.WriteLine($"Явное приведение к int: {xInt}");
        Console.WriteLine($"Неявное приведение к double: {yDouble}");

        Console.WriteLine("\nБинарные операции:");
        Console.WriteLine($"p1 + p2 (расстояние): {p1 + p2}");

        Console.Write("\nВведите целое число для сложения с p1: ");
        int addValue = Convert.ToInt32(Console.ReadLine());
        Point p3 = p1 + addValue;
        Console.WriteLine($"p1 + {addValue}: {p3}");

        Point p4 = addValue + p1;
        Console.WriteLine($"{addValue} + p1: {p4}");
    }
}