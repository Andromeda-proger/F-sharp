using System;

public class Triangle : Base
{
    public Triangle() : base() { }

    public Triangle(int a, int b, int c) : base(a, b, c)
    {
        if (!IsValidTriangle())
            throw new ArgumentException("С такими сторонами треугольник не существует");
    }

    public Triangle(Triangle other) : base(other) { }

    private bool IsValidTriangle()
    {
        return a + b > c && a + c > b && b + c > a && a > 0 && b > 0 && c > 0;
    }

    public int CalculatePerimeter()
    {
        return a + b + c;
    }

    // Вычисление площади треугольника по формуле Герона
    public double CalculateArea()
    {
        double p = CalculatePerimeter() / 2.0;
        return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
    }

    public string GetTriangleType()
    {
        if (a == b && b == c)
            return "Равносторонний";
        else if (a == b || a == c || b == c)
            return "Равнобедренный";
        else
            return "Разносторонний";
    }

    public override string ToString()
    {
        return $"Треугольник со сторонами: {base.ToString()}\nТип: {GetTriangleType()}\nПериметр: {CalculatePerimeter()}\nПлощадь: {CalculateArea():F2}";
    }
}