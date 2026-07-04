using System;

class Program
{
    static void Main(string[] args)
    {
        string playAgain = "yes";
        while (playAgain == "yes")
        {
            
            
            Random randomGenerator =  new Random();
            int magicNumber = randomGenerator.Next(1, 101);
            int guess = -1;
            int guessCount = 0;

            while (guess != magicNumber)
            {
                Console.Write("What is the magic number? ");
                guess = int.Parse(Console.ReadLine());
                guessCount++;
                if (guess < magicNumber)
                {
                    Console.WriteLine("Higher.");
                }
                else if (guess > magicNumber)
                {
                    Console.WriteLine("Lower");
                }
                else
                {
                    Console.WriteLine("You guessed it right!");
                }   
            }
                Console.WriteLine($"You guessed {guessCount} time.");
                
                Console.Write("Do you want to play again? ");
                playAgain = Console.ReadLine();
        }
    }
}