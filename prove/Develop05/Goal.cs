abstract class Goal
{
    protected string name;
    protected string description;
    protected int points;

    public Goal(string name, string description, int points)
    {
        this.name = name;
        this.description = description;
        this.points = points;
    }

    public abstract int RecordEvent();
    public abstract string GetStatus();
    public abstract bool IsComplete();
    public abstract string Serialize();
    public abstract void LoadProgress(string[] data);
}