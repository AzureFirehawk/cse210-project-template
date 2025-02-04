using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Homework Project.");

        Assignment assignment1 = new Assignment("Samuel Bennett", "Multiplication");

        Console.WriteLine(assignment1.GetSummary());

        MathAssignment mathAssignment = new MathAssignment("Roberto Rodriguez", "Fractions", "7.3", "8-19");
        Console.WriteLine($"\n{mathAssignment.GetHomeworkList()}");

        WritingAssignment writingAssignment = new WritingAssignment("Mary Waters", "European History", "The Cause of World War II");
        Console.WriteLine($"\n{writingAssignment.GetWritingInformation()}");

    }
}