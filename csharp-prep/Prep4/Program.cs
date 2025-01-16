using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();
        int number = -1; 

        Console.WriteLine("Enter a list of numbers, type 0 when finished.");
        while (number != 0)
        {   
            Console.Write("Enter a number: ");
            string response = Console.ReadLine();
            number = int.Parse(response);

            if (number == 0)
            {
                break;
            }
            numbers.Add(number);
        }
        // sum the numbers
        int sum = 0;
        foreach (int num in numbers)
        {   
            sum += num;
        }
        
        Console.WriteLine("The sum of the numbers is: " + sum);
        // average the numbers
        float average = ((float)sum) / numbers.Count;
        Console.WriteLine("The average of the numbers is: " + (average));

        // find the largest number
        int largest = numbers[0];

        foreach (int num in numbers)
        {
            if (num > largest)
            {
                largest = num;
            }
        }
        Console.WriteLine("The largest number is: " + largest);

        // sort the list
        List<int> list_of_numbers = numbers;

        list_of_numbers.Sort();

        Console.WriteLine("The sorted list of numbers is: " + string.Join(", ", list_of_numbers));
    }
}