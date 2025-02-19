public class MathAssignment : Assignment
{
    private string _textbookSection;
    private string _problems;

    public MathAssignment(string studentName, string subject, string textbookSection, string problems) 
        : base(studentName, subject)
    {
        _textbookSection = textbookSection;
        _problems = problems;
    }

    public string GetHomeworkList()
    {
        return $"Textbook Section: {_textbookSection} Problems: {_problems}";
    }
}