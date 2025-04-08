public class CreatureCard : Card
{
    public int ManaCost { get; private set; }
    public int Power { get; private set; }
    public int Toughness { get; private set; }
    public string CreatureType { get; private set; }
    public string Abilities { get; private set; }
    
    public CreatureCard(string name, string color, int manaCost, int power, int toughness, string creatureType, string abilities, string set) 
        : base(name, color, set)
    {
        ManaCost = manaCost;
        Power = power;
        Toughness = toughness;
        CreatureType = creatureType;
        Abilities = abilities;
    }
    
    // Polymorphism - override GetCardInfo
    public override string GetCardInfo()
    {
        return $"{Name} ({Color}) - {ManaCost} Mana - {CreatureType} - {Power}/{Toughness} - {Set}";
    }
    
    public override int GetManaCost()
    {
        return ManaCost;
    }
}
