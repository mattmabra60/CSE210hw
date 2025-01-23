using System.ComponentModel.Design.Serialization;

public class Movie
{
    public string _title;
    public int _year;
    public int _runtime;
    public string _rating;

    public void Display()
    {
        Console.WriteLine(_title);
    }
}