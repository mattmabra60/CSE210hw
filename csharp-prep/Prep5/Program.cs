using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

class Program
{
    static void Main(string[] args)
    {
        DipslayWelcome();
        string name = PromptUserName();
        int number = PromptUserNumber();
        int squaredNumber = SquareNumber(number);
        DisplayResults(name, squaredNumber);
    }

    static void DipslayWelcome()
        {
            Console.WriteLine("Welcome to the Program!");
        }

    static string PromptUserName()
        {
            Console.Write("Please enter your name: ");
        
            return Console.ReadLine();
        }

    static int PromptUserNumber()
        {
            Console.Write("Please enter your favorite number: ");
            int number = int.Parse(Console.ReadLine());
        
            return number;
        }

    static int SquareNumber(int number)
        {
            return number * number;
        }

    static void DisplayResults(string name, int squaredNumber)
        {
            Console.WriteLine($"{name}, and the square of your number is {squaredNumber}");
        }
}