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
        return $"Точка: X = {x}, Y = {y}";
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
