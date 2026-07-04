using System;
using System.Collections.Generic;
using System.Globalization;
class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();
        int userNumber = -1;

        while (userNumber != 0)
        {
            Console.Write("Enter a number (0 to quit): ");
            string userResponse = Console.ReadLine();
            userNumber = int.Parse(userResponse);

            if(userNumber != 0)
            {
                numbers.Add(userNumber);
            }


        }

            int sum = 0;
            foreach(int number in numbers)
            {
                sum += number;
            }
            Console.WriteLine($"The sum is: {sum}.");

            float average = ((float)sum) / numbers.Count;
            Console.WriteLine($"The average is: {average}.");
            int max = numbers[0];

            foreach (int number in numbers)
            {
                if(number>max)
                {
                    max = number;
                }
            }
            Console.WriteLine($"The maximum number is: {max}.");

            int smallestPositive = int.MaxValue;

            foreach(int number in numbers)
            {
                if(number > 0 && number < smallestPositive)
                {
                    smallestPositive = number;
                }
            }
            if(smallestPositive == int.MaxValue)
            {
                Console.WriteLine("There are no positive number.");
            }
            else
            {
                Console.WriteLine($"The smallest positive number is: {smallestPositive}.");

            }
            numbers.Sort();
            Console.WriteLine("The sorted list file is: ");
            foreach(int number in numbers)
            {
                Console.WriteLine(number);
            }
    
            
        
    }
}