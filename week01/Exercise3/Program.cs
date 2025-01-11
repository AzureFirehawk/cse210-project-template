using System;
using System.Runtime.CompilerServices;

class Program
{
    static void Main(string[] args)
    {
        string reply = "yes";
        do
        {
            Console.WriteLine("I have a secret number. Can you guess it?");
        
            Random randomGenerator = new Random();
            int magic = randomGenerator.Next(1, 101);

            int guess = -1;
            int count = 0;
            string plural = "try";

            do 
            {
                Console.Write("What is your guess? ");
                guess = int.Parse(Console.ReadLine());

                if (guess > magic)
                {
                    Console.WriteLine("Lower");
                }
                else if (guess < magic)
                {
                    Console.WriteLine("Higher");
                }
                count++;
            } while (guess != magic);
            
            if (count > 1)
            {
                plural = "tries";
            }

            Console.WriteLine("You guessed it!");
            Console.WriteLine($"It took you {count} {plural}.");
            Console.WriteLine();
            Console.Write("Would you like to play again? ");
            reply = Console.ReadLine().ToLower();
        } while (reply != "no");
    }
}