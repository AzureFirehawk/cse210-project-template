using System;

// Exceeding requirements:
// I added a function to the ending message to save the activity and duration to a text file.
// The ending message will be slightly different if the user has completed that activity before.
// Initializing each activity calcuates total duration from the text file.
// Both the Listing and Reflection activities keep track of which prompts have been used while the program is running,
// and will only repeat after all have been used.
// The Reflection activity also tracks which questions have been asked for the given prompt, and will only repeat 
// if all have been asked.

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Mindfulness Project.");
        Thread.Sleep(5000);
        Console.Clear();
        BreathingActivity breathingActivity = new BreathingActivity();
        ListingActivity listingActivity = new ListingActivity();
        ReflectionActivity reflectionActivity = new ReflectionActivity();

        string input = "";
        while (input != "5")
        {
            Console.Clear();
            Console.WriteLine("Please choose an activity:\n1. Breathing Activity\n2. Listing Activity\n3. Reflection Activity\n4. Clear Logs\n5. Quit\n");
            input = Console.ReadLine();
            if (input == "1")
            {
                breathingActivity.Run();
            }
            else if (input == "2")
            {
                listingActivity.Run();
            }
            else if (input == "3")
            {
                reflectionActivity.Run();
            }
            else if (input == "4")
            {
                Console.Clear();
                Console.WriteLine("Are you sure you want to clear the logs? (Y/N)");
                Thread.Sleep(2000);
                input = Console.ReadLine();
                if (input == "Y" || input == "y")
                {
                    Console.WriteLine("Clearing Logs...");
                    Thread.Sleep(2000);
                    File.Delete("Times.txt");
                    Console.WriteLine("Logs have been cleared.");
                    Thread.Sleep(2000);
                    Console.Clear();
                }
                else
                {
                    Console.WriteLine("Returning to main menu...");
                    Thread.Sleep(2000);
                    Console.Clear();
                }
            }
            else if (input == "5")
            {
            Console.WriteLine("Goodbye!");
            }
            else
            {
                Console.WriteLine("That is not a valid option.");
                Thread.Sleep(2000);
                Console.Clear();
            }
        }
    }
}