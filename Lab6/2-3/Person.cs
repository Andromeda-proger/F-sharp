using System;
public class Point
{
    private double X { get; set; }
    private double Y { get; set; }

    public Point(double x, double y)
    {
        X = x;
        Y = y;
    }

    public double DistanceTo(Point other)
    {
        double dx = this.X - other.X;
        double dy = this.Y - other.Y;
        return Math.Sqrt(dx * dx + dy * dy);
    }

    public static Point operator ++(Point p)
    {
        p.X += 1;
        return p;
    }

    public static Point operator --(Point p)
    {
        p.X -= 1;
        return p;
    }

    public static explicit operator int(Point p)
    {
        return (int)p.X;
    }

    public static implicit operator double(Point p)
    {
        return p.Y;
    }

    public static double operator +(Point p1, Point p2)
    {
        return p1.DistanceTo(p2);
    }

    public static Point operator +(Point p, int value)
    {
        return new Point(p.X + value, p.Y);
    }

    public static Point operator +(int value, Point p)
    {
        return p + value;
    }

    // Для удобства тестирования переопределим ToString()
    public override string ToString()
    {
        return $"({X}, {Y})";
    }
}