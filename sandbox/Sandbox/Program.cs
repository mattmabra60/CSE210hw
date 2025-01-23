using System;
using System.Globalization;
using System.Net.Http.Headers;

class Program
{
    static void Main(string[] args)
    {
        Movie favoriteMovie = new Movie();
        favoriteMovie._title = "Star wars";
        favoriteMovie._year = 1977;
        favoriteMovie._runtime = 150;
        favoriteMovie._rating = "PG";

        Movie otherMovie = new Movie();
        otherMovie._title = "Avatar";
        otherMovie._year = 2009;
        otherMovie._runtime = 162;
        otherMovie._rating = "PG-13";

        favoriteMovie.Display();

        DisplayMovie(favoriteMovie);
        DisplayMovie(otherMovie);

        Console.WriteLine("My favorite movie is " + favoriteMovie._title + ".");

        static void DisplayMovie(Movie aMovie)
        {
            Console.WriteLine($"{aMovie._title} - {aMovie._year}");
        }
    }
}
