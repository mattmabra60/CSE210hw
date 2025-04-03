public class Specialist: Staff
{
    private string _specialty;

    public Specialist(string firstName, string lastName, string gender, string specialty)
    : base(firstName, lastName, gender)
    {
        _specialty = specialty;
    }

    public string DisplayGreeting()
    {
        return($"Hello, my name is {Getproffesionalname()} and I am a {_specialty} at the school.");
    }
}