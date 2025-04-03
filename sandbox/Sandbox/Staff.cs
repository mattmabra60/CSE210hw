using System;
using System.Reflection;
using System.Runtime.CompilerServices;

public class Staff
{
    private string _firstName;
    private string _lastName;
    private string _gender;

    public Staff(string firstName, string lastName, string gender)
    {
        _firstName = firstName;
        _lastName = lastName;
        _gender = gender;
    }

    public string GetTitle()
    {
        if (_gender == "male")
        {
            return "Mr.";
        }
        else return "Ms.";
    }
    public string Getproffesionalname()
    {
        string Title = GetTitle();

        return $"{Title}{_lastName}";
    }

}