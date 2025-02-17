using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the ExerciseTracking Project.\n");

        List<Activity> activities = new List<Activity>();
        activities.Add(new Running(30, 2.5));
        activities.Add(new Bicycles(40, 15.0));
        activities.Add(new Running(25, 3.0));
        activities.Add(new Swimming(20, 17));
        activities.Add(new Bicycles(30, 12.0));
        activities.Add(new Swimming(30, 15));

        foreach (Activity activity in activities)
        {
            activity.GetSummary();
        }
    }
}