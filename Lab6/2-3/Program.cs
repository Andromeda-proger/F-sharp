using System;

class Program
{
    static double ReadDouble(string prompt)
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

    static int ReadInt(string prompt)
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

    static void Main(string[] args)
    {
        Console.WriteLine("������������ ������ Point");

        Console.WriteLine("\n������� ���������� ������ �����:");
        double x1 = ReadDouble("X1: ");
        double y1 = ReadDouble("Y1: ");
        Point p1 = new Point(x1, y1);

        Console.WriteLine("\n������� ���������� ������ �����:");
        double x2 = ReadDouble("X2: ");
        double y2 = ReadDouble("Y2: ");
        Point p2 = new Point(x2, y2);

        Console.WriteLine($"\n���������� ����� {p1} � {p2}: {p1.DistanceTo(p2)}");

        Console.WriteLine("\n������������ ������������� ��������:");

        Console.WriteLine($"\n�������� ����� p1: {p1}");
        p1++;
        Console.WriteLine($"����� p1++: {p1}");
        p1--;
        Console.WriteLine($"����� p1--: {p1}");

        int xInt = (int)p1;
        double yDouble = p1;
        Console.WriteLine($"\n����� ���������� p1 � int: {xInt}");
        Console.WriteLine($"������� ���������� p1 � double: {yDouble}");

        Console.WriteLine($"\n���������� ����� {p1} � {p2} ����� �������� +: {p1 + p2}");

        int value = ReadInt("\n������� ����� ����� ��� �������� �������� � ������: ");
        Point p3 = p1 + value;
        Console.WriteLine($"p1 + {value} = {p3}");

        Point p4 = value + p1;
        Console.WriteLine($"{value} + p1 = {p4}");
    }
}
