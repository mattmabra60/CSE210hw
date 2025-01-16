using System;
using System.Globalization;
using System.Net.Http.Headers;

class Program
{
    static void Main(string[] args)
    {
        // this is a comment
        string adjective = GetAdjective();
        string noun = GetNoun();

        int number = Multiply(3, 4);
        Console.WriteLine($"I looked out the window and saw {number} {adjective} {noun}s.");
    }

    static int Multiply(int number1, int number2)
    {
        int product = number1 * number2;
        return product;
    }
    static string GetAdjective()
    {
        List<string> words = new List<string>();
        words.Add("red");
        words.Add("blue");
        words.Add("green");
        words.Add("yellow");
        words.Add("big");
        words.Add("small");

        string adjective = words[2];

        return adjective;
    }   

    static string GetNoun()
    {
        string noun = "bird";

        return noun;
    }

    static string GetAmount(int number)
    { 
        string amount = "";
        if (number > 1)
        {
            amount = "s";
        }
        else 
        {
            amount = "";
        }
        return amount;
    }
}
