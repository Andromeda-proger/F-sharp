using System;
public class StudentGrades : ThreeNumbers
{
    public string studentName;

    public StudentGrades() : base()
    {
        studentName = "Неизвестно";
    }

    public StudentGrades(string name, int grade1, int grade2, int grade3)
        : base(grade1, grade2, grade3)
    {
        studentName = name;
    }

    public StudentGrades(StudentGrades other) : base(other)
    {
        studentName = other.studentName;
    }

    public double CalculateAverage()
    {
        return (num1 + num2 + num3) / 3.0;
    }

    public bool HasFailedGrades()
    {
        return num1 < 3 || num2 < 3 || num3 < 3;
    }

    public override string ToString()
    {
        return $"Студент: {studentName}, Оценки: {num1}, {num2}, {num3}";
    }
}