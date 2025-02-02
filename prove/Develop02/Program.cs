using System;
using System.Security.Cryptography.X509Certificates;

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        while (true)
        {
            Console.WriteLine("Welcome to the Journal Program!");
            Console.WriteLine(@"Please select one of the following choices:
            1. Write
            2. Display
            3. Save
            4. Load
            5. Quit");
            Console.Write("What would you like to do? ");
            string choice = Console.ReadLine();

            if (choice == "1")
            {   
                Entry entry = new Entry();
                string prompt = GeneratePrompt.GetRandomPrompt();
                Console.WriteLine(prompt);
                Console.Write("> ");
                entry._prompt = prompt;
                entry._text = Console.ReadLine();
                entry._creationDate = DateTime.Now;
                journal.AddEntry(entry);
            }
            else if (choice == "2")
            {
                journal.DisplayEntries();
            }
            else if (choice == "3")
            {
                Console.WriteLine("Enter filename to save journal:");
                    string filename = Console.ReadLine();
                    journal.SaveToFile(filename);
            }
            else if (choice == "4")
            {
                Console.WriteLine("Enter filename to load journal:");
                    string filename = Console.ReadLine();
                    journal.LoadFromFile(filename);
            }
            else if (choice == "5")
            {
                Console.WriteLine("Goodbye!");
                Environment.Exit(0);
            }
            else
            {
                Console.WriteLine("Invalid choice. Please try again.");
            }
        }
    }
}