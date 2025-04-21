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
            Console.WriteLine("������ �����. ����������, ������� ���������� �����.");
        }
    }

    static void Main(string[] args)
    {
        Console.WriteLine("������� ���������� ������ �����:");
        double x1 = ReadDouble("������� ���������� X: ");
        double y1 = ReadDouble("������� ���������� Y: ");

        Console.WriteLine("\n������� ���������� ������ �����:");
        double x2 = ReadDouble("������� ���������� X: ");
        double y2 = ReadDouble("������� ���������� Y: ");

        Point p1 = new Point(x1, y1);
        Point p2 = new Point(x2, y2);

        Console.WriteLine("\n������������ ������� 2:");
        Console.WriteLine(p1.ToString());
        Console.WriteLine(p2.ToString());
        Console.WriteLine($"���������� ����� �������: {p1.DistanceTo(p2)}");

        Console.WriteLine("\n������������ ������� 3:");

        Console.WriteLine("\n������� ��������:");
        Console.WriteLine("�������� p1: " + p1);
        p1++;
        Console.WriteLine("����� p1++: " + p1);
        p1--;
        Console.WriteLine("����� p1--: " + p1);

        Console.WriteLine("\n�������� ���������� �����:");
        int xInt = (int)p1;
        double yDouble = p1;
        Console.WriteLine($"����� ���������� � int: {xInt}");
        Console.WriteLine($"������� ���������� � double: {yDouble}");

        Console.WriteLine("\n�������� ��������:");
        Console.WriteLine($"p1 + p2 (����������): {p1 + p2}");

        Console.Write("\n������� ����� ����� ��� �������� � p1: ");
        int addValue = Convert.ToInt32(Console.ReadLine());
        Point p3 = p1 + addValue;
        Console.WriteLine($"p1 + {addValue}: {p3}");

        Point p4 = addValue + p1;
        Console.WriteLine($"{addValue} + p1: {p4}");
    }
}