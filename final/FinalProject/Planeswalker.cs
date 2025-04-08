public class PlaneswalkerCard : Card
{
    public int ManaCost { get; private set; }
    public int Loyalty { get; private set; }
    public string PlaneswalkerType { get; private set; }
    public string Abilities { get; private set; }
    
    public PlaneswalkerCard(string name, string color, int manaCost, int loyalty, string planeswalkerType, string abilities, string set) 
        : base(name, color, set)
    {
        ManaCost = manaCost;
        Loyalty = loyalty;
        PlaneswalkerType = planeswalkerType;
        Abilities = abilities;
    }
    
    // Polymorphism - override GetCardInfo
    public override string GetCardInfo()
    {
        return $"{Name} ({Color}) - {ManaCost} Mana - Planeswalker: {PlaneswalkerType} - Loyalty: {Loyalty} - {Set}";
    }
    
    public override int GetManaCost()
    {
        return ManaCost;
    }
}