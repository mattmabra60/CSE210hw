public class Assignment
{
    private string _studentName;
    private string _subject;

    public Assignment(string studentName, string subject)
    {
        _studentName = studentName;
        _subject = subject;
    }

    public string GetStudentName()
    {
        return _studentName;
    }

    public string GetSummary()
    {
        return $"{_studentName} - {_subject}";
    }
}