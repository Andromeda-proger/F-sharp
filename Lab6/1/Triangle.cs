using System;

public class Triangle : Base
{
    public Triangle() : base() { }

    public Triangle(int a, int b, int c) : base(a, b, c)
    {
        if (!IsValidTriangle())
            throw new ArgumentException("� ������ ��������� ����������� �� ����������");
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

    // ���������� ������� ������������ �� ������� ������
    public double CalculateArea()
    {
        double p = CalculatePerimeter() / 2.0;
        return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
    }

    public string GetTriangleType()
    {
        if (a == b && b == c)
            return "��������������";
        else if (a == b || a == c || b == c)
            return "��������������";
        else
            return "��������������";
    }

    public override string ToString()
    {
        return $"����������� �� ���������: {base.ToString()}\n���: {GetTriangleType()}\n��������: {CalculatePerimeter()}\n�������: {CalculateArea():F2}";
    }
}