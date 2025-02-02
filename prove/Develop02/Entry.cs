using System;

public class Entry
{
    public string _prompt;
    public string _text;
    public DateTime _creationDate;

    public void Display()
    {
        Console.WriteLine($"{_prompt}");
        Console.WriteLine($"{_text}");
        Console.WriteLine($"Created on: {_creationDate}\n");
    }

    public string GetEntry()
    {
        return $"{_prompt}~{_text}~{_creationDate}";
    }
}