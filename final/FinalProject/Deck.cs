public class Deck
{
    public string Name { get; private set; }
    private List<Card> _cards;
    
    public int CardCount
    {
        get { return _cards.Count; }
    }
    
    public Deck(string name)
    {
        Name = name;
        _cards = new List<Card>();
    }
    
    public void AddCard(Card card)
    {
        _cards.Add(card);
    }
    
    public bool RemoveCard(Card card)
    {
        return _cards.Remove(card);
    }
    
    public List<Card> GetAllCards()
    {
        return new List<Card>(_cards);
    }
    
    public string GetColorDistribution()
    {
        int white = 0;
        int blue = 0;
        int black = 0;
        int red = 0;
        int green = 0;
        int colorless = 0;
        
        foreach (Card card in _cards)
        {
            string color = card.Color.ToLower();
            if (color == "white") white++;
            else if (color == "blue") blue++;
            else if (color == "black") black++;
            else if (color == "red") red++;
            else if (color == "green") green++;
            else colorless++;
        }
        
        return $"W:{white} U:{blue} B:{black} R:{red} G:{green} C:{colorless}";
    }
    
    public double GetAverageCost()
    {
        if (_cards.Count == 0) return 0;
        
        int totalCost = 0;
        int countedCards = 0;
        
        foreach (Card card in _cards)
        {
            int cost = card.GetManaCost();
            if (cost > 0) 
            {
                totalCost += cost;
                countedCards++;
            }
        }
        
        return countedCards > 0 ? (double)totalCost / countedCards : 0;
    }
}