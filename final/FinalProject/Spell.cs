public class SpellCard : Card
{
    public int ManaCost { get; private set; }
    public string SpellType { get; private set; }
    public string Effect { get; private set; }
    
    public SpellCard(string name, string color, int manaCost, string spellType, string effect, string set) 
        : base(name, color, set)
    {
        ManaCost = manaCost;
        SpellType = spellType;
        Effect = effect;
    }
    
    // Polymorphism - override GetCardInfo
    public override string GetCardInfo()
    {
        return $"{Name} ({Color}) - {ManaCost} Mana - {SpellType} - {Set}";
    }
    
    public override int GetManaCost()
    {
        return ManaCost;
    }
}