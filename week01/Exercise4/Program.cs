using System;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();
        int number = -1;
        while (number != 0)
        {
            Console.Write("Add a number to the list (or type 0 to move on): ");
            number = int.Parse(Console.ReadLine());
            if (number != 0)
            {
                numbers.Add(number);
            }
        }

        int sum = numbers.Sum();
        float mean = sum / numbers.Count();
        int max = 0;
        int smallpos = 99999;

        foreach (int item in numbers)
        {
            if (item > max)
            {
                max = item;
            }
            if (item > 0 && item < smallpos)
            {
                smallpos = item;
            }
        }

        Console.WriteLine($"The sum is: {sum}");
        Console.WriteLine($"The average is: {mean}");
        Console.WriteLine($"The largest number is {max}");
        Console.WriteLine($"The smallest positive number is: {smallpos}");
        Console.WriteLine("The sorted list is:");

        numbers.Sort();
        foreach (int x in numbers)
        {
            Console.WriteLine(x);
        }

    }
}