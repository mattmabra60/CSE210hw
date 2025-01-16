using System;
using System.Net;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is the magic number? ");
        int response = int.Parse(Console.ReadLine());
        int guess;

        do
        {
            Console.Write("What is your guess? ");
            guess = int.Parse(Console.ReadLine());
        
            if (response > guess)
            {
                Console.WriteLine("Too low!");
            }
            else if (response < guess)
            {
                Console.WriteLine("Too high!");
            }
            else
            {
                Console.WriteLine("You got it!");
            }
        }while (response != guess);
        
    }
}