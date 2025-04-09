class Program
{
    private List<Goal> goals = new List<Goal>();
    private int totalScore = 0;

    public void Run()
    {
        bool running = true;
        while (running)
        {
            Console.WriteLine("\nMenu Options:");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Show Score");
            Console.WriteLine("4. Save Goals");
            Console.WriteLine("5. Load Goals");
            Console.WriteLine("6. Record Event");
            Console.WriteLine("7. Quit");
            Console.Write("Select an choice from the menu: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1": CreateGoal(); break;
                case "2": ShowGoals(); break;
                case "3": Console.WriteLine($"Total Score: {totalScore}"); break;
                case "4": SaveGoals(); break;
                case "5": LoadGoals(); break;
                case "6": RecordEvent(); break;
                case "7": running = false; break;
                default: Console.WriteLine("Invalid option."); break;
            }
        }
    }

    private void CreateGoal()
    {
        Console.WriteLine(@"The types of Goals are: 
        1=Simple 
        2=Eternal 
        3=Checklist
        Which type of goal would you like to create?");
        string type = Console.ReadLine();
        Console.Write("What is the name of your goal: ");
        string name = Console.ReadLine();
        Console.Write("What is a short description of it: ");
        string desc = Console.ReadLine();
        Console.Write("How many points would you like to allocate towards this goal: ");
        int points = int.Parse(Console.ReadLine());

        if (type == "1")
        {
            goals.Add(new SimpleGoal(name, desc, points));
        }
        else if (type == "2")
        {
            goals.Add(new EternalGoal(name, desc, points));
        }
        else if (type == "3")
        {
            Console.Write("How many times does this goal need to be accomplished in order to get a bonus? ");
            int required = int.Parse(Console.ReadLine());
            Console.Write($"How many points should be awarded for completing it {required} times: ");
            int bonus = int.Parse(Console.ReadLine());
            goals.Add(new ChecklistGoal(name, desc, points, required, bonus));
        }
        else
        {
            Console.WriteLine("Unknown goal type.");
        }
    }

    private void RecordEvent()
    {
        if (goals.Count == 0)
        {
            Console.WriteLine("No goals to record.");
            return;
        }

        Console.WriteLine("Which Goal did you complete?");
        for (int i = 0; i < goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {goals[i].GetStatus()}");
        }
        int index = int.Parse(Console.ReadLine()) - 1;
        if (index >= 0 && index < goals.Count)
        {
            int pointsEarned = goals[index].RecordEvent();
            totalScore += pointsEarned;
            Console.WriteLine($"You earned {pointsEarned} points!");
        }
        else
        {
            Console.WriteLine("Invalid goal.");
        }
    }

    private void ShowGoals()
    {
        if (goals.Count == 0)
        {
            Console.WriteLine("No goals created.");
            return;
        }

        foreach (var goal in goals)
        {
            Console.WriteLine(goal.GetStatus());
        }
    }

    private void SaveGoals()
    {
        using (StreamWriter writer = new StreamWriter("goals.txt"))
        {
            writer.WriteLine(totalScore);
            foreach (var goal in goals)
            {
                writer.WriteLine(goal.Serialize());
            }
        }
        Console.WriteLine("Goals saved.");
    }

    private void LoadGoals()
    {
        if (!File.Exists("goals.txt"))
        {
            Console.WriteLine("No saved goals found.");
            return;
        }

        goals.Clear();
        string[] lines = File.ReadAllLines("goals.txt");
        totalScore = int.Parse(lines[0]);

        for (int i = 1; i < lines.Length; i++)
        {
            string[] parts = lines[i].Split('|');
            string type = parts[0];

            if (type == "SimpleGoal")
            {
                var g = new SimpleGoal(parts[1], parts[2], int.Parse(parts[3]));
                g.LoadProgress(parts);
                goals.Add(g);
            }
            else if (type == "EternalGoal")
            {
                var g = new EternalGoal(parts[1], parts[2], int.Parse(parts[3]));
                g.LoadProgress(parts);
                goals.Add(g);
            }
            else if (type == "ChecklistGoal")
            {
                var g = new ChecklistGoal(parts[1], parts[2], int.Parse(parts[3]), int.Parse(parts[4]), int.Parse(parts[5]));
                g.LoadProgress(parts);
                goals.Add(g);
            }
        }

        Console.WriteLine("Goals loaded.");
    }

    static void Main()
    {
        new Program().Run();
    }
}
