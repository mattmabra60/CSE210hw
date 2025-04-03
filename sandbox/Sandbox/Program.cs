using System;
using System.Globalization;
using System.Net.Http.Headers;

class Program
{
    static void Main(string[] args)
    {
        Teacher T1 = new Teacher ("Jhon", "Jhonson", "male", 220);
        Console.WriteLine(T1.DisplayGreeting());

        Specialist S1 = new Specialist ("Jane", "Fester", "Female", "Councilor");
        Console.WriteLine(S1.DisplayGreeting());

        Volunteer V1 = new Volunteer("Hillary", "Chester", "Female");
        Console.WriteLine(V1.DisplayGreeting());
    }
}
