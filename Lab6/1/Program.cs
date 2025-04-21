using System;

class Program
{
    static int ReadInt(string prompt, int minValue = int.MinValue, int maxValue = int.MaxValue)
    {
        int number;
        while (true)
        {
            Console.Write(prompt);
            if (int.TryParse(Console.ReadLine(), out number) && number >= minValue && number <= maxValue)
                return number;
            Console.WriteLine($"������ �����. ����������, ������� ����� ����� �� {minValue} �� {maxValue}.");
        }
    }

    static void Main(string[] args)
    {
        Console.WriteLine("������� ������ ��� ������ ThreeNumbers:");
        int n1 = ReadInt("������� ������ �����: ");
        int n2 = ReadInt("������� ������ �����: ");
        int n3 = ReadInt("������� ������ �����: ");

        ThreeNumbers nums1 = new ThreeNumbers(n1, n2, n3);
        ThreeNumbers nums2 = new ThreeNumbers(nums1);

        Console.WriteLine("\n----������������ �������� ������----");
        Console.WriteLine($"������������ �� �����: {nums1.FindMax()}");
        Console.WriteLine($"������ �� �����: {nums1.ToString()} ");
        Console.WriteLine($"���������� ������ To_string: {nums2.ToString(" ")}");

        Console.WriteLine("\n������� ������ ��� ������ StudentGrades:");
        Console.Write("������� ��� ��������: ");
        string name = Console.ReadLine();

        int g1 = ReadInt("������� ������ ������ (1-5): ", 1, 5);
        int g2 = ReadInt("������� ������ ������ (1-5): ", 1, 5);
        int g3 = ReadInt("������� ������ ������ (1-5): ", 1, 5);

        StudentGrades student1 = new StudentGrades(name, g1, g2, g3);
        StudentGrades student2 = new StudentGrades(student1);

        Console.WriteLine("\n----������������ ��������� ������----");
        Console.WriteLine(student1.ToString(" "));
        Console.WriteLine($"������� ����: {student1.CalculateAverage()}");
        Console.WriteLine($"���� �������������������� ������: {student1.HasFailedGrades()}");

    }
}