using System;

class Program
{
    static double ReadDouble(string prompt)
    {
        double result;
        Console.Write(prompt);
        while (!double.TryParse(Console.ReadLine(), out result))
        {
            Console.WriteLine("Ошибка ввода. Пожалуйста, введите число.");
            Console.Write(prompt);
        }
        return result;
    }

    static int ReadInt(string prompt)
    {
        int result;
        Console.Write(prompt);
        while (!int.TryParse(Console.ReadLine(), out result))
        {
            Console.WriteLine("Ошибка ввода. Пожалуйста, введите целое число.");
            Console.Write(prompt);
        }
        return result;
    }

    static void Main(string[] args)
    {
        Console.WriteLine("Тестирование класса Point");

        Console.WriteLine("\nВведите координаты первой точки:");
        double x1 = ReadDouble("X1: ");
        double y1 = ReadDouble("Y1: ");
        Point p1 = new Point(x1, y1);

        Console.WriteLine("\nВведите координаты второй точки:");
        double x2 = ReadDouble("X2: ");
        double y2 = ReadDouble("Y2: ");
        Point p2 = new Point(x2, y2);

        Console.WriteLine($"\nРасстояние между {p1} и {p2}: {p1.DistanceTo(p2)}");

        Console.WriteLine("\nТестирование перегруженных операций:");

        Console.WriteLine($"\nИсходная точка p1: {p1}");
        p1++;
        Console.WriteLine($"После p1++: {p1}");
        p1--;
        Console.WriteLine($"После p1--: {p1}");

        int xInt = (int)p1;
        double yDouble = p1;
        Console.WriteLine($"\nЯвное приведение p1 к int: {xInt}");
        Console.WriteLine($"Неявное приведение p1 к double: {yDouble}");

        Console.WriteLine($"\nРасстояние между {p1} и {p2} через оператор +: {p1 + p2}");

        int value = ReadInt("\nВведите целое число для операции сложения с точкой: ");
        Point p3 = p1 + value;
        Console.WriteLine($"p1 + {value} = {p3}");

        Point p4 = value + p1;
        Console.WriteLine($"{value} + p1 = {p4}");
    }
}
