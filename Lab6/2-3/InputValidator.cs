using System;

public static class InputValidator
{
    public static double ReadDouble(string prompt)
    {
        double result;
        Console.Write(prompt);
        while (!double.TryParse(Console.ReadLine(), out result))
        {
            Console.WriteLine("������ �����. ����������, ������� �����.");
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
            Console.WriteLine("������ �����. ����������, ������� ����� �����.");
            Console.Write(prompt);
        }
        return result;
    }
}