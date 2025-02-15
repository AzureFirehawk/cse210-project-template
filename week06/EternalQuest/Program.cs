using System;

// Exceeding requirements:
// I changed the point system to instead ask the user for the relative difficulty of the goal, and assigned points based on that.
// I also added a leveling system so the user can level up as they complete goals. The program will display their current level and the points needed
// to level up.

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the EternalQuest Project.");

        GoalManager program = new GoalManager();
        program.Start();
    }
}