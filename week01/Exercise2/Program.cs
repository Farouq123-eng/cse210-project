using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your grade percentage? ");
        string grade = Console.ReadLine();
        int gradePercentage = int.Parse(grade);
        
        string letterGrade = "";
        string sign = "";
        if (gradePercentage >= 90)
        {
            letterGrade = "A";
        }
        else if (gradePercentage >= 80)
        {
            letterGrade ="B";
        }
        else if (gradePercentage >= 70)
        {
            letterGrade = "C";
        }
        else if (gradePercentage >=60)
        {
            letterGrade = "D";
        }
        else 
        {
            letterGrade = "F";
        }
        int lastDigit = gradePercentage %10 ;
        if (letterGrade == "A")
        {
            if (lastDigit <3)
            {
                sign = "-";
            }
            else
            {
                sign="";
            }
        }
        else if (letterGrade == "F")
        {
            sign="";
        }
        else
        {
            if (lastDigit >= 7)
            {
                sign= "+";
            }
            else if (lastDigit < 3)
            {
                sign = "-";
            }
            else
            {
                sign="";
            }
        }
        Console.WriteLine($"Your grade is: {letterGrade}{sign}.");
        if (gradePercentage >= 70)
        {
            Console.WriteLine("Congratulations! You passed the class!");
        }
        else
        {
            Console.WriteLine("Sorry, you did not pass the class.");
        }

    
    }
}