class SimpleGoal : Goal
{
    private bool isComplete;

    public SimpleGoal(string name, string description, int points)
        : base(name, description, points)
    {
        isComplete = false;
    }

    public override int RecordEvent()
    {
        if (!isComplete)
        {
            isComplete = true;
            return points;
        }
        return 0;
    }

    public override string GetStatus()
    {
        return $"[{(isComplete ? "X" : " ")}] {name}";
    }

    public override bool IsComplete() => isComplete;

    public override string Serialize() =>
        $"SimpleGoal|{name}|{description}|{points}|{isComplete}";

    public override void LoadProgress(string[] data)
    {
        isComplete = bool.Parse(data[4]);
    }
}
