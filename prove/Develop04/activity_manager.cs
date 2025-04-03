using System;

class Program
{
    static void Main(string[] args)
    {
        BreathingActivity breather = new BreathingActivity();
        ReflectionActivity reflector = new ReflectionActivity();
        ListingActivity lister = new ListingActivity();

        string choice = "";
        while (choice != "4")
        {
            Console.WriteLine("Hello and welcome to the Mindfulness program");
            Console.WriteLine("Please select an activity to begin");
            Console.WriteLine("1. Breathing activity");
            Console.WriteLine("2. Listing activity");
            Console.WriteLine("3. Reflecting activity");
            Console.WriteLine("4. Quit");
            Console.WriteLine("Enter the number of the activity you would like to do: ");

            choice = Console.ReadLine();

            if (choice == "1")
            {
                breather.Run();
            }
            else if (choice == "2")
            {
                lister.Run();
            }
            else if (choice == "3")
            {
                reflector.Run();
            }
            else if (choice == "4")
            {
                Console.WriteLine("Thank you for using the Mindfulness program");
            }
            else
            {
                Console.WriteLine("Invalid choice, please try again");
            }
        }
    }
}