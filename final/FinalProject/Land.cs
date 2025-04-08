public class LandCard : Card
{
    public string LandType { get; private set; }
    public string Abilities { get; private set; }
    
    public LandCard(string name, string color, string landType, string abilities, string set) 
        : base(name, color, set)
    {
        LandType = landType;
        Abilities = abilities;
    }
    
    // Polymorphism - override GetCardInfo
    public override string GetCardInfo()
    {
        return $"{Name} ({Color}) - Land: {LandType} - {Set}";
    }
    
    // Lands typically cost 0 mana
    public override int GetManaCost()
    {
        return 0;
    }
}