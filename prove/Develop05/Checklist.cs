class ChecklistGoal : Goal
{
    private int timesRequired;
    private int timesCompleted;
    private int bonusPoints;

    public ChecklistGoal(string name, string description, int points, int timesRequired, int bonusPoints)
        : base(name, description, points)
    {
        this.timesRequired = timesRequired;
        this.bonusPoints = bonusPoints;
        this.timesCompleted = 0;
    }

    public override int RecordEvent()
    {
        if (timesCompleted < timesRequired)
        {
            timesCompleted++;
            if (timesCompleted == timesRequired)
                return points + bonusPoints;
            return points;
        }
        return 0;
    }

    public override string GetStatus()
    {
        return $"[{(IsComplete() ? "X" : " ")}] {name} ({timesCompleted}/{timesRequired})";
    }

    public override bool IsComplete() => timesCompleted >= timesRequired;

    public override string Serialize() =>
        $"ChecklistGoal|{name}|{description}|{points}|{timesRequired}|{bonusPoints}|{timesCompleted}";

    public override void LoadProgress(string[] data)
    {
        timesCompleted = int.Parse(data[6]);
    }
}