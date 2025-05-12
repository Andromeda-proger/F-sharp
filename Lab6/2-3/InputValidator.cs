using System;

public static class InputValidator
{
    public static double ReadDouble(string prompt)
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

    public static int ReadInt(string prompt)
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
}