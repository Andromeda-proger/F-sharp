using System;
public class ThreeNumbers
{
    public int num1;
    public int num2;
    public int num3;

    public ThreeNumbers()
    {
        num1 = 0;
        num2 = 0;
        num3 = 0;
    }

    public ThreeNumbers(int n1, int n2, int n3)
    {
        num1 = n1;
        num2 = n2;
        num3 = n3;
    }

    public ThreeNumbers(ThreeNumbers other)
    {
        num1 = other.num1;
        num2 = other.num2;
        num3 = other.num3;
    }

    public int FindMax()
    {
        return Math.Max(Math.Max(num1, num2), num3);
    }

    public override string ToString()
    {
        return $"{num1}{num2}{num3}";
    }

    public string ToString(string separator)
    {
        return $"{num1}{separator}{num2}{separator}{num3}";
    }
}