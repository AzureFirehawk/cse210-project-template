// To exceed requirements:
// I added a randomization to the number of words hidden in each iteration.
// I added a text file with a premade list of a few scriptures for the user to choose from, as well as the option to add their own.
// I created a loop to make sure the program didn't try to hide more words than were still showing, and would supply a new message when the
// scripture is completely hidden.

using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the ScriptureMemorizer Project.\n");

        // Initialize variables
        string book = "";
        int chapter =0;
        int startVerse = 0;
        int endVerse = 0;
        Reference reference;
        Scripture scripture;
        string text = "";

        // Opening prompt
        Console.Write("Which scripture would you like to work on memorizing?\nAlma 7:11-13\nHelaman 5:12\nD&C 76:22-24\nMatthew 5:14-16\nJohn 3:5\n\nPlease type the scripture reference, or type 'new' to add your own: ");
        string input = Console.ReadLine();

        if (input == "new") // User wants to add their own
        {
            Console.Clear();
            Console.Write("Please type the scripture reference in the following format: Book Chapter:Verse(s) (e.g. Alma 7:11-13): ");
            input = Console.ReadLine();
            reference = new Reference(input);

            Console.Write("\nPlease enter the scripture text: ");
            text = Console.ReadLine();

            scripture = new Scripture(reference, text);
        }

        else // User selects from given list
        {
            string[] parts = input.Split(new char[] {' ', '-' , ':'});

            book = parts[0];
            chapter = int.Parse(parts[1]);
            startVerse = int.Parse(parts[2]);
            if (parts.Length == 4)
            {
                endVerse = int.Parse(parts[3]);
                reference = new Reference(book, chapter, startVerse, endVerse); 
            }
            else
            {
                reference = new Reference(book, chapter, startVerse);
            }
            scripture = new Scripture(reference);
        }

        

        input = "";
        while (input != "quit")
        {
            Console.Clear();
            Console.WriteLine(reference.GetDisplayText());
            Console.WriteLine(scripture.GetDisplayText());
            if (scripture.IsCompletelyHidden())
            {
                Console.WriteLine("You have finished memorizing this scripture.");
                break;
            }
            Console.WriteLine("\nPress enter to continue or type 'quit' to finish: ");
            input = Console.ReadLine();
            if (input == "")
            {
                Random random = new Random();
                scripture.HideWords(random.Next(2, 5));
            } 
            else
            {
                Console.WriteLine("\nPlease either type 'quit' or press enter to continue.");
            }
        }
        Console.ReadLine();
        Console.WriteLine("Goodbye!");
    }
}