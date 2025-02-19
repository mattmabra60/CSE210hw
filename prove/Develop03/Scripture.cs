public class Scripture
{
    private Reference _reference;
    private List<Word> _words;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        
        // Split the text into individual words
        string[] word_list = text.Split(' ');
        
        // Create a new list to store our Word objects
        _words = new List<Word>();
        
        // For each word in our array, create a new Word object and add it to our list
        foreach (string word in word_list)
        {
            Word newWord = new Word(word);
            _words.Add(newWord);
        }
    }

    public void HideRandomWords(int count)
    {
        Random random = new Random();
        
        // Create a new list for visible words
        List<Word> visibleWords = new List<Word>();
        
        // Loop through all words and add the non-hidden ones to our visibleWords list
        foreach (Word word in _words)
        {
            if (!word.IsHidden)
            {
                visibleWords.Add(word);
            }
        }
        
        // Hide random words
           for (int i = 0; i < count && visibleWords.Count > 0; i++)
        {
            // Get a random index within the visible words list
            int index = random.Next(visibleWords.Count);
            
            // Hide the word at that index
            visibleWords[index].Hide();
            
            // Remove the word from our visible words list since it's now hidden
            visibleWords.RemoveAt(index);
        }
    }

    public bool IsCompletelyHidden()
    {
        // go through and check if all words are hidden
        foreach (Word word in _words)
        {
            if (!word.IsHidden)
            {
                return false;
            }
        }
        return true;
    }

public string GetDisplayText()
{
    List<string> displayWords = new List<string>();
    foreach (Word word in _words)
    {
        string displayText = word.GetDisplayText();
        displayWords.Add(displayText);
    }
    
    return $"{_reference}\n{string.Join(" ", displayWords)}";
}
}