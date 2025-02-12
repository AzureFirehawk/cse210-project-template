using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the EternalQuest Project.");

        SimpleGoal simpleGoal = new SimpleGoal("Simple Goal", "Simple Description", 10);
        EternalGoal eternalGoal = new EternalGoal("Eternal Goal", "Eternal Description", 100);
        ChecklistGoal checklistGoal = new ChecklistGoal("Checklist Goal", "Checklist Description", 50, 500, 4);
        Console.WriteLine(simpleGoal.GetDetailsString());
        Console.WriteLine(eternalGoal.GetDetailsString());
        Console.WriteLine(checklistGoal.GetDetailsString());

        simpleGoal.RecordEvent();
        eternalGoal.RecordEvent();
        checklistGoal.RecordEvent();
        checklistGoal.RecordEvent();
        checklistGoal.RecordEvent();
        checklistGoal.RecordEvent();

        Console.WriteLine();
        Console.WriteLine(simpleGoal.GetDetailsString());
        Console.WriteLine(eternalGoal.GetDetailsString());
        Console.WriteLine(checklistGoal.GetDetailsString());

    }
}