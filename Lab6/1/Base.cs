using System;

public class Base
{
    protected int a;
    protected int b;
    protected int c;

    protected Base()
    {
        a = 0;
        b = 0;
        c = 0;
    }

    public Base(int a, int b, int c)
    {
        this.a = a;
        this.b = b;
        this.c = c;
    }

    public Base(Base other)
    {
        a = other.a;
        b = other.b;
        c = other.c;
    }

    public int GetMax()
    {
        return Math.Max(Math.Max(a, b), c);
    }

    public override string ToString()
    {
        return $"a = {a}, b = {b}, c = {c}";
    }
}

