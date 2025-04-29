using System;

class Program
{
    static int ReadInt(string prompt)
    {
        int value;
        Console.Write(prompt);
        while (!int.TryParse(Console.ReadLine(), out value) || value <= 0)
        {
            Console.WriteLine("������ �����. ����������, ������� ������������� ����� �����.");
            Console.Write(prompt);
        }
        return value;
    }

    static void Main(string[] args)
    {
        Console.WriteLine("������������ �������� ������:");

        // ���� ������ ��� �������� ������
        int a = ReadInt("������� �������� a: ");
        int b = ReadInt("������� �������� b: ");
        int c = ReadInt("������� �������� c: ");

        // �������� �������� �������� ������
        Base baseObj1 = new Base(a, b, c);
        Base baseObj2 = new Base(baseObj1); // �����

        Console.WriteLine("\n������ 1: " + baseObj1);
        Console.WriteLine("������ 2 (�����): " + baseObj2);
        Console.WriteLine("������������ �������� � ������� 1: " + baseObj1.GetMax());

        Console.WriteLine("\n������������ ��������� ������ (�����������):");

        while (true)
        {
            try
            {
                a = ReadInt("������� ������� a ������������: ");
                b = ReadInt("������� ������� b ������������: ");
                c = ReadInt("������� ������� c ������������: ");

                Triangle triangle1 = new Triangle(a, b, c);
                Triangle triangle2 = new Triangle(triangle1); // �����

                Console.WriteLine("\n����������� 1:\n" + triangle1);
                Console.WriteLine("\n����������� 2 (�����):\n" + triangle2);

                Console.WriteLine("\n������������ ������� � ������������ 1: " + triangle1.GetMax());
                break;
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("������: " + ex.Message);
                Console.WriteLine("����������, ������� ���������� ������� ������������.");
            }
        }
    }
}