public class Activity
{
    protected string _name;
    protected string _description;
    protected int _duration;

    public void DisplayStartingMessage()
    {
        Console.WriteLine($"\nHello and welcome to the {_name} activity");
        Console.WriteLine($"Description {_description}\n");

        Console.WriteLine("How long would you like to do this activity for?");
        _duration = int.Parse(Console.ReadLine());
    }

   public void DisplayEndingMessage()
    {
        Console.WriteLine("\nWell done!!");
        ShowSpinner(3);
        Console.WriteLine($"\nYou have completed another {_duration} seconds of the {_name}.");
        ShowSpinner(5);
        Console.Clear();
    }
    
    protected void ShowSpinner(int seconds)
    {
        List<string> spinnerStrings = new List<string> { "|", "/", "-", "\\" };
        
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(seconds);
        
        int i = 0;
        while (DateTime.Now < endTime)
        {
            Console.Write(spinnerStrings[i]);
            Thread.Sleep(200);
            Console.Write("\b \b");
            
            i++;
            if (i >= spinnerStrings.Count)
            {
                i = 0;
            }
        }
    }
    
    protected void ShowCountDown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }
}