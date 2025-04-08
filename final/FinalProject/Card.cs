public class Card
{
    public string Name { get; protected set; }
    public string Color { get; protected set; }
    public string Set { get; protected set; }
    
    public Card(string name, string color, string set)
    {
        Name = name;
        Color = color;
        Set = set;
    }
    
    // Polymorphism - virtual method to be overridden by subclasses
    public virtual string GetCardInfo()
    {
        return $"{Name} ({Color}) - {Set}";
    }
    
    // Polymorphism - virtual method for mana cost
    public virtual int GetManaCost()
    {
        return 0;
    }
}
