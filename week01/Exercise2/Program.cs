using System;


class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your grade percentage (just the number)? ");
        string percent = Console.ReadLine();
        string letter = "";
        string modifier = "";

        int score = int.Parse(percent);
        int remainder = score % 10;

        if (score >= 90)
        {
            letter = "A";
        }
        else if (score >= 80)
        {
            letter = "B";
        }
        else if (score >= 70)
        {
            letter = "C";
        }
        else if (score >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }
        if (score < 90 && score >=60)
        {
            if (remainder >= 7) 
            {
                modifier = "+";
            }
            else if (remainder < 3)
            {
                modifier = "-";
            }
        }

        Console.WriteLine($"Your letter grade is {letter}{modifier}");

        

        if (score >= 70)
        {
            Console.WriteLine("Congratulations! You passed the class!");
        }
        else
        {
            Console.WriteLine("I'm sorry, you will need to retake the class");
        }
    }
}