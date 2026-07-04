using System;

class Program
{
    static void Main(string[] args)
    {
        DisplayWelcome();
        
        string name = PromptUserName();
        int FavoriteNumber = PromptUserNumber();

        int squared = SquareNumber(FavoriteNumber);
        Displayresult(name, squared);
    }

    static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the program!");
    }
    static string PromptUserName()
    {
        Console.WriteLine("Please enter your name: ");
        return Console.ReadLine();
    }
    static int PromptUserNumber()
    {
        Console.Write("Please enter your favorite number: ");
        string input = Console.ReadLine();
        return int.Parse(input);
    }
    static int SquareNumber(int number)
    {
        return number*number;
    }
    static void Displayresult(string name, int squaredNumber)
    {
        Console.WriteLine($"{name}, your number squared is {squaredNumber}.");
    }
}