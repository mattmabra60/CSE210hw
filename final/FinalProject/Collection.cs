public class CardCollectionManager
{
    private List<Card> _collection;
    private List<Deck> _decks;
    
    public CardCollectionManager()
    {
        _collection = new List<Card>();
        _decks = new List<Deck>();
    }
    
    public void AddCard(Card card)
    {
        _collection.Add(card);
    }
    
    public void AddDeck(Deck deck)
    {
        _decks.Add(deck);
    }
    
    public List<Card> GetAllCards()
    {
        return new List<Card>(_collection);
    }
    
    public List<Deck> GetAllDecks()
    {
        return new List<Deck>(_decks);
    }
    
    public List<Card> GetCardsByColor(string color)
    {
        List<Card> result = new List<Card>();
        
        for (int i = 0; i < _collection.Count; i++)
        {
            if (_collection[i].Color.ToLower() == color.ToLower())
            {
                result.Add(_collection[i]);
            }
        }
        
        return result;
    }
    
    public bool SaveToFile(string filename)
    {
        try
        {
            using (StreamWriter writer = new StreamWriter(filename))
            {
                writer.WriteLine(_collection.Count);
                
                foreach (Card card in _collection)
                {
                    if (card is CreatureCard creature)
                    {
                        writer.WriteLine("Creature");
                        writer.WriteLine(creature.Name);
                        writer.WriteLine(creature.Color);
                        writer.WriteLine(creature.ManaCost);
                        writer.WriteLine(creature.Power);
                        writer.WriteLine(creature.Toughness);
                        writer.WriteLine(creature.CreatureType);
                        writer.WriteLine(creature.Abilities);
                        writer.WriteLine(creature.Set);
                    }
                    else if (card is SpellCard spell)
                    {
                        writer.WriteLine("Spell");
                        writer.WriteLine(spell.Name);
                        writer.WriteLine(spell.Color);
                        writer.WriteLine(spell.ManaCost);
                        writer.WriteLine(spell.SpellType);
                        writer.WriteLine(spell.Effect);
                        writer.WriteLine(spell.Set);
                    }
                    else if (card is PlaneswalkerCard planeswalker)
                    {
                        writer.WriteLine("Planeswalker");
                        writer.WriteLine(planeswalker.Name);
                        writer.WriteLine(planeswalker.Color);
                        writer.WriteLine(planeswalker.ManaCost);
                        writer.WriteLine(planeswalker.Loyalty);
                        writer.WriteLine(planeswalker.PlaneswalkerType);
                        writer.WriteLine(planeswalker.Abilities);
                        writer.WriteLine(planeswalker.Set);
                    }
                    else if (card is LandCard land)
                    {
                        writer.WriteLine("Land");
                        writer.WriteLine(land.Name);
                        writer.WriteLine(land.Color);
                        writer.WriteLine(land.LandType);
                        writer.WriteLine(land.Abilities);
                        writer.WriteLine(land.Set);
                    }
                }
                
                writer.WriteLine(_decks.Count);
                
                foreach (Deck deck in _decks)
                {
                    writer.WriteLine(deck.Name);
                    List<Card> deckCards = deck.GetAllCards();
                    writer.WriteLine(deckCards.Count);
                    
                    foreach (Card card in deckCards)
                    {
                        for (int i = 0; i < _collection.Count; i++)
                        {
                            if (_collection[i].Name == card.Name)
                            {
                                writer.WriteLine(i);
                                break;
                            }
                        }
                    }
                }
            }
            
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }
    
    public bool LoadFromFile(string filename)
    {
        try
        {
            if (!File.Exists(filename))
            {
                return false;
            }
            
            _collection.Clear();
            _decks.Clear();
            
            using (StreamReader reader = new StreamReader(filename))
            {
                int cardCount = int.Parse(reader.ReadLine());
                
                for (int i = 0; i < cardCount; i++)
                {
                    string cardType = reader.ReadLine();
                    
                    if (cardType == "Creature")
                    {
                        string name = reader.ReadLine();
                        string color = reader.ReadLine();
                        int manaCost = int.Parse(reader.ReadLine());
                        int power = int.Parse(reader.ReadLine());
                        int toughness = int.Parse(reader.ReadLine());
                        string creatureType = reader.ReadLine();
                        string abilities = reader.ReadLine();
                        string set = reader.ReadLine();
                        
                        _collection.Add(new CreatureCard(name, color, manaCost, power, toughness, creatureType, abilities, set));
                    }
                    else if (cardType == "Spell")
                    {
                        string name = reader.ReadLine();
                        string color = reader.ReadLine();
                        int manaCost = int.Parse(reader.ReadLine());
                        string spellType = reader.ReadLine();
                        string effect = reader.ReadLine();
                        string set = reader.ReadLine();
                        
                        _collection.Add(new SpellCard(name, color, manaCost, spellType, effect, set));
                    }
                    else if (cardType == "Planeswalker")
                    {
                        string name = reader.ReadLine();
                        string color = reader.ReadLine();
                        int manaCost = int.Parse(reader.ReadLine());
                        int loyalty = int.Parse(reader.ReadLine());
                        string pwType = reader.ReadLine();
                        string abilities = reader.ReadLine();
                        string set = reader.ReadLine();
                        
                        _collection.Add(new PlaneswalkerCard(name, color, manaCost, loyalty, pwType, abilities, set));
                    }
                    else if (cardType == "Land")
                    {
                        string name = reader.ReadLine();
                        string color = reader.ReadLine();
                        string landType = reader.ReadLine();
                        string abilities = reader.ReadLine();
                        string set = reader.ReadLine();
                        
                        _collection.Add(new LandCard(name, color, landType, abilities, set));
                    }
                }
                
                int deckCount = int.Parse(reader.ReadLine());
                
                for (int i = 0; i < deckCount; i++)
                {
                    string deckName = reader.ReadLine();
                    Deck deck = new Deck(deckName);
                    
                    int deckCardCount = int.Parse(reader.ReadLine());
                    
                    for (int j = 0; j < deckCardCount; j++)
                    {
                        int cardIndex = int.Parse(reader.ReadLine());
                        deck.AddCard(_collection[cardIndex]);
                    }
                    
                    _decks.Add(deck);
                }
            }
            
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }
}