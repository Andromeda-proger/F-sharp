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
            Console.WriteLine($"Ошибка ввода. Пожалуйста, введите целое число от {minValue} до {maxValue}.");
        }
    }

    static void Main(string[] args)
    {
        Console.WriteLine("Введите данные для класса ThreeNumbers:");
        int n1 = ReadInt("Введите первое число: ");
        int n2 = ReadInt("Введите второе число: ");
        int n3 = ReadInt("Введите третье число: ");

        ThreeNumbers nums1 = new ThreeNumbers(n1, n2, n3);
        ThreeNumbers nums2 = new ThreeNumbers(nums1);

        Console.WriteLine("\n----Тестирование базового класса----");
        Console.WriteLine($"Максимальное из чисел: {nums1.FindMax()}");
        Console.WriteLine($"Строка из чисел: {nums1.ToString()} ");
        Console.WriteLine($"Перегрузка метода To_string: {nums2.ToString(" ")}");

        Console.WriteLine("\nВведите данные для класса StudentGrades:");
        Console.Write("Введите имя студента: ");
        string name = Console.ReadLine();

        int g1 = ReadInt("Введите первую оценку (1-5): ", 1, 5);
        int g2 = ReadInt("Введите вторую оценку (1-5): ", 1, 5);
        int g3 = ReadInt("Введите третью оценку (1-5): ", 1, 5);

        StudentGrades student1 = new StudentGrades(name, g1, g2, g3);
        StudentGrades student2 = new StudentGrades(student1);

        Console.WriteLine("\n----Тестирование дочернего класса----");
        Console.WriteLine(student1.ToString(" "));
        Console.WriteLine($"Средний балл: {student1.CalculateAverage()}");
        Console.WriteLine($"Есть неудовлетворительные оценки: {student1.HasFailedGrades()}");

    }
}