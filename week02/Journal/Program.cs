// To exceed expectations, I added a confirmation to the quit option to warn about losing unsaved data.
// I also added a feature to load entries by a specific date, with a message to warn if no entries are found.
// Lastly I added a loop to make sure prompts are only displayed once each per run.

using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();

        // Initialize variables
        string menu = "0";
        while (menu != "5")
        {   
            // Prompt user for input
            Console.WriteLine("\nPlease select from the following options:");
            Console.WriteLine("1. Write a new entry\n2. Display your entries\n3. Load previous entries\n4. Save current entries\n5. Quit");
            Console.Write("What would you like to do? ");
            menu = Console.ReadLine();

            if (menu == "1")
            {
                // Add a new entry
                journal.AddEntry();
            }
            else if (menu == "2")
            {
                // Display all entries
                journal.DisplayAll();
            }
            else if (menu == "3")
            {
                // Load previous entries from file
                Console.WriteLine("Please enter the file name: ");
                string file = Console.ReadLine();
                Console.WriteLine("\nWhat date do you want to load (m/d/yyyy or 'all')? ");
                string date = $"Date: {Console.ReadLine()}";
                journal.LoadFromFile(file, date);
            }
            else if (menu == "4")
            {
                // Save current entries to file
                Console.WriteLine("Please enter the file name: ");
                string file = Console.ReadLine();
                journal.SaveToFile(file);
            }
            else if (menu == "5")
            {
                // Close program after confirmation
                Console.WriteLine("Are you sure you want to quit? All unsaved progress will be lost.");
                string quit = Console.ReadLine();
                if (quit.ToLower() == "yes")
                {
                    Console.WriteLine("Goodbye!");
                    break;
                }   
                else
                {
                    Console.WriteLine("\nReturning to menu.");
                    menu = "0";
                    continue;
                }
            }
            else
            {
                // Cover invalid input
                Console.WriteLine("Invalid input.");
            }
        }
    }
}
