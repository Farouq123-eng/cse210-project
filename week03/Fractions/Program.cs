using System;
using System.Diagnostics.CodeAnalysis;
using System.IO.Pipes;

class Program
{
    static void Main(string[] args)
    {
        Fraction f1 = new Fraction();
        Console.WriteLine("fraction f1:" + f1.GetFractionString());
        Console.WriteLine("Decimal value: " + f1.GetDecimalValue());
        // using second constructor 
        Fraction f2 = new Fraction(6);
        Console.WriteLine("\nFraction f2: " + f2.GetFractionString());
        Console.WriteLine("Decimal Value: " + f2.GetDecimalValue());
        // using the third constructor
        Fraction f3 = new Fraction(6,7);
        Console.WriteLine("\nFraction f3:" + f3.GetFractionString());
        Console.WriteLine("Decimal value: " + f3.GetDecimalValue());
        // testing getters ans setters
        f3.SetTop(3);
        f3.SetBottom(4);
        Console.WriteLine("\nUpdated  f3: " + f3.GetFractionString());
        Console.WriteLine("Decimal value: " + f3.GetDecimalValue());
    }
} 