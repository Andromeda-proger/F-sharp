using System;

class Program
{
    static int ReadInt(string prompt)
    {
        int value;
        Console.Write(prompt);
        while (!int.TryParse(Console.ReadLine(), out value) || value <= 0)
        {
            Console.WriteLine("Ошибка ввода. Пожалуйста, введите положительное целое число.");
            Console.Write(prompt);
        }
        return value;
    }

    static void Main(string[] args)
    {
        Console.WriteLine("Тестирование базового класса:");

        // Ввод данных для базового класса
        int a = ReadInt("Введите значение a: ");
        int b = ReadInt("Введите значение b: ");
        int c = ReadInt("Введите значение c: ");

        // Создание объектов базового класса
        Base baseObj1 = new Base(a, b, c);
        Base baseObj2 = new Base(baseObj1); // копия

        Console.WriteLine("\nОбъект 1: " + baseObj1);
        Console.WriteLine("Объект 2 (копия): " + baseObj2);
        Console.WriteLine("Максимальное значение в объекте 1: " + baseObj1.GetMax());

        Console.WriteLine("\nТестирование дочернего класса (Треугольник):");

        while (true)
        {
            try
            {
                a = ReadInt("Введите сторону a треугольника: ");
                b = ReadInt("Введите сторону b треугольника: ");
                c = ReadInt("Введите сторону c треугольника: ");

                Triangle triangle1 = new Triangle(a, b, c);
                Triangle triangle2 = new Triangle(triangle1); // копия

                Console.WriteLine("\nТреугольник 1:\n" + triangle1);
                Console.WriteLine("\nТреугольник 2 (копия):\n" + triangle2);

                Console.WriteLine("\nМаксимальная сторона в треугольнике 1: " + triangle1.GetMax());
                break;
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Ошибка: " + ex.Message);
                Console.WriteLine("Пожалуйста, введите корректные стороны треугольника.");
            }
        }
    }
}