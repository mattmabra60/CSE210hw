using System;
using System.Reflection.Metadata.Ecma335;

public class Journal
{
    public List<Entry> entries = new List<Entry>();

    public Journal()
    {
    }

    public void AddEntry(Entry entry)
    {
        entries.Add(entry);
    }

    public void DisplayEntries()
    {
        foreach (Entry item in entries)
        {
            item.Display();
        }
    }

    public void SaveToFile(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            foreach (Entry item in entries)
            {
                writer.WriteLine(item.GetEntry());
            }
        }
        Console.WriteLine("Journal saved successfully!");
    }

    public void LoadFromFile(string filename)
    {
        if (File.Exists(filename))
        {
            entries.Clear();
            string[] lines = File.ReadAllLines(filename);
            foreach (string line in lines)
            {
                string[] parts = line.Split("~");
                if (parts.Length >= 3)
                {
                    Entry entry = new Entry
                    {
                        _prompt = parts[0],
                        _text = parts[1],
                        _creationDate = DateTime.Parse(parts[2])
                    };
                    entries.Add(entry);
                }
            }
        }
    }
}
