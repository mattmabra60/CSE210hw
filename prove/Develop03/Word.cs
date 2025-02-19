public class Word
{
    private string _text;
    private bool _isHidden;

    public Word(string text)
    {
        _text = text;
        _isHidden = false;
    }

    public bool IsHidden => _isHidden;

    public void Hide()
    {
        // gives the word at that index the hidden value hiding it
        _isHidden = true;
    }

    public string GetDisplayText()
    {
        // if the word is hidden it will return a string of underscores the same length as the word
        return _isHidden ? new string('_', _text.Length) : _text;
    }
}