using System.ComponentModel.DataAnnotations;

public class Volunteer : Staff
{
    public Volunteer(string firstName, string lastName, string gender)
    : base(firstName, lastName, gender)
    {
    }

    public string DisplayGreeting()
    {
        return($"Hello, my name is {Getproffesionalname()} and I am a volunteer at the school.");
    }
}