using System;

public class Point
{
    public double x;
    public double y;

    public Point()
    {
        x = 0;
        y = 0;
    }

    public Point(double x, double y)
    {
        this.x = x;
        this.y = y;
    }

    public double DistanceTo(Point other)
    {
        double dx = other.x - x;
        double dy = other.y - y;
        return Math.Sqrt(dx * dx + dy * dy);
    }

    public override string ToString()
    {
        return $"�����: X = {x}, Y = {y}";
    }

    public static Point operator ++(Point p)
    {
        p.x += 1;
        return p;
    }

    public static Point operator --(Point p)
    {
        p.x -= 1;
        return p;
    }

    public static explicit operator int(Point p)
    {
        return (int)p.x;
    }

    public static implicit operator double(Point p)
    {
        return p.y;
    }

    public static double operator +(Point p1, Point p2)
    {
        return p1.DistanceTo(p2);
    }

    public static Point operator +(Point p, int num)
    {
        return new Point(p.x + num, p.y);
    }

    public static Point operator +(int num, Point p)
    {
        return p + num;
    }
}

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