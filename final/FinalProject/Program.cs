using System;

class Program
{
    static void Main(string[] args)
    {
        CardCollectionManager manager = new CardCollectionManager();
        
        Card fireball = new SpellCard("Fireball", "Red", 1, "Instant", "Fireball deals X damage divided as you choose among any number of targets.", "Dominaria");
        Card llanowarElves = new CreatureCard("Llanowar Elves", "Green", 1, 1, 1, "Elf Druid", "Tap: Add G to your mana pool.", "Alpha");
        Card wrathOfGod = new SpellCard("Wrath of God", "White", 4, "Sorcery", "Destroy all creatures. They can't be regenerated.", "Limited Edition");
        Card serra = new PlaneswalkerCard("Serra the Benevolent", "White", 4, 4, "Serra", "+2: Create a 4/4 white Angel creature token with flying. -3: You gain life equal to the number of creatures you control with flying.", "Modern Horizons");
        Card wasteland = new LandCard("Wasteland", "Colorless", "Land", "Tap: Add 1 colorless mana to your mana pool. Tap, Sacrifice Wasteland: Destroy target nonbasic land.", "Tempest");
        
        // some of the preset cards (these could be loaded from a file in a real application)
        manager.AddCard(fireball);
        manager.AddCard(llanowarElves);
        manager.AddCard(wrathOfGod);
        manager.AddCard(serra);
        manager.AddCard(wasteland);
        
        // Decks (same as above, could be loaded from a file)
        Deck controlDeck = new Deck("Control Deck");
        controlDeck.AddCard(wrathOfGod);
        controlDeck.AddCard(serra);
        controlDeck.AddCard(wasteland);
        
        Deck aggroDeck = new Deck("Aggro Deck");
        aggroDeck.AddCard(fireball);
        aggroDeck.AddCard(llanowarElves);
        
        manager.AddDeck(controlDeck);
        manager.AddDeck(aggroDeck);
        
        bool exit = false;
        while (!exit)
        {
            Console.Clear();
            Console.WriteLine("=== Magic: The Gathering Card Manager ===");
            Console.WriteLine("1. View All Cards");
            Console.WriteLine("2. View Cards by Color");
            Console.WriteLine("3. View Decks");
            Console.WriteLine("4. View Deck Details");
            Console.WriteLine("5. Create New Card");
            Console.WriteLine("6. Create New Deck");
            Console.WriteLine("7. Add Card to Deck");
            Console.WriteLine("8. Save Collection");
            Console.WriteLine("9. Load Collection");
            Console.WriteLine("0. Exit");
            Console.Write("\nEnter your choice: ");
            
            string choice = Console.ReadLine();
            
            switch (choice)
            {
                case "1":
                    ViewAllCards(manager);
                    break;
                case "2":
                    ViewCardsByColor(manager);
                    break;
                case "3":
                    ViewDecks(manager);
                    break;
                case "4":
                    ViewDeckDetails(manager);
                    break;
                case "5":
                    CreateNewCard(manager);
                    break;
                case "6":
                    CreateNewDeck(manager);
                    break;
                case "7":
                    AddCardToDeck(manager);
                    break;
                case "8":
                    SaveCollection(manager);
                    break;
                case "9":
                    LoadCollection(manager);
                    break;
                case "0":
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Press any key to continue...");
                    Console.ReadKey();
                    break;
            }
        }
    }
    
    static void ViewAllCards(CardCollectionManager manager)
    {
        Console.Clear();
        Console.WriteLine("=== All Cards ===");
        
        List<Card> allCards = manager.GetAllCards();
        if (allCards.Count == 0)
        {
            Console.WriteLine("No cards in collection.");
        }
        else
        {
            for (int i = 0; i < allCards.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {allCards[i].GetCardInfo()}");
            }
        }
        
        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey();
    }
    
    static void ViewCardsByColor(CardCollectionManager manager)
    {
        Console.Clear();
        Console.WriteLine("=== View Cards by Color ===");
        Console.WriteLine("Enter color (White, Blue, Black, Red, Green, Colorless, or All):");
        string color = Console.ReadLine();
        
        Console.Clear();
        Console.WriteLine($"=== {color} Cards ===");
        
        List<Card> cards;
        if (color.ToLower() == "all")
        {
            cards = manager.GetAllCards();
        }
        else
        {
            cards = manager.GetCardsByColor(color);
        }
        
        if (cards.Count == 0)
        {
            Console.WriteLine("No cards found with that color.");
        }
        else
        {
            for (int i = 0; i < cards.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {cards[i].GetCardInfo()}");
            }
        }
        
        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey();
    }
    
    static void ViewDecks(CardCollectionManager manager)
    {
        Console.Clear();
        Console.WriteLine("=== All Decks ===");
        
        List<Deck> allDecks = manager.GetAllDecks();
        if (allDecks.Count == 0)
        {
            Console.WriteLine("No decks created yet.");
        }
        else
        {
            for (int i = 0; i < allDecks.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {allDecks[i].Name} (Cards: {allDecks[i].CardCount})");
            }
        }
        
        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey();
    }
    
    static void ViewDeckDetails(CardCollectionManager manager)
    {
        Console.Clear();
        Console.WriteLine("=== Deck Details ===");
        
        List<Deck> allDecks = manager.GetAllDecks();
        if (allDecks.Count == 0)
        {
            Console.WriteLine("No decks created yet.");
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
            return;
        }
        
        for (int i = 0; i < allDecks.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {allDecks[i].Name}");
        }
        
        Console.Write("\nEnter deck number to view details: ");
        if (int.TryParse(Console.ReadLine(), out int deckIndex) && deckIndex >= 1 && deckIndex <= allDecks.Count)
        {
            Deck selectedDeck = allDecks[deckIndex - 1];
            
            Console.Clear();
            Console.WriteLine($"=== {selectedDeck.Name} Details ===");
            Console.WriteLine($"Total Cards: {selectedDeck.CardCount}");
            Console.WriteLine($"Color Distribution: {selectedDeck.GetColorDistribution()}");
            Console.WriteLine($"Average Mana Cost: {selectedDeck.GetAverageCost():F2}");
            Console.WriteLine("\nCards:");
            
            List<Card> deckCards = selectedDeck.GetAllCards();
            for (int i = 0; i < deckCards.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {deckCards[i].GetCardInfo()}");
            }
        }
        else
        {
            Console.WriteLine("Invalid deck number.");
        }
        
        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey();
    }
    
    static void CreateNewCard(CardCollectionManager manager)
    {
        Console.Clear();
        Console.WriteLine("=== Create New Card ===");
        Console.WriteLine("Select card type:");
        Console.WriteLine("1. Creature");
        Console.WriteLine("2. Spell");
        Console.WriteLine("3. Planeswalker");
        Console.WriteLine("4. Land");
        
        Console.Write("\nEnter choice: ");
        string typeChoice = Console.ReadLine();
        
        Console.Write("Enter card name: ");
        string name = Console.ReadLine();
        
        Console.Write("Enter card color (White, Blue, Black, Red, Green, Colorless): ");
        string color = Console.ReadLine();
        
        Console.Write("Enter card set: ");
        string set = Console.ReadLine();
        
        Card newCard = null;
        
        switch (typeChoice)
        {
            case "1": // Creature
                Console.Write("Enter mana cost: ");
                int cost = int.Parse(Console.ReadLine());
                
                Console.Write("Enter power: ");
                int power = int.Parse(Console.ReadLine());
                
                Console.Write("Enter toughness: ");
                int toughness = int.Parse(Console.ReadLine());
                
                Console.Write("Enter creature type: ");
                string creatureType = Console.ReadLine();
                
                Console.Write("Enter abilities: ");
                string abilities = Console.ReadLine();
                
                newCard = new CreatureCard(name, color, cost, power, toughness, creatureType, abilities, set);
                break;
                
            case "2": // Spell
                Console.Write("Enter mana cost: ");
                int spellCost = int.Parse(Console.ReadLine());
                
                Console.Write("Enter spell type (Instant, Sorcery, Enchantment, Artifact): ");
                string spellType = Console.ReadLine();
                
                Console.Write("Enter effect: ");
                string effect = Console.ReadLine();
                
                newCard = new SpellCard(name, color, spellCost, spellType, effect, set);
                break;
                
            case "3": // Planeswalker
                Console.Write("Enter mana cost: ");
                int pwCost = int.Parse(Console.ReadLine());
                
                Console.Write("Enter loyalty: ");
                int loyalty = int.Parse(Console.ReadLine());
                
                Console.Write("Enter planeswalker type: ");
                string pwType = Console.ReadLine();
                
                Console.Write("Enter abilities: ");
                string pwAbilities = Console.ReadLine();
                
                newCard = new PlaneswalkerCard(name, color, pwCost, loyalty, pwType, pwAbilities, set);
                break;
                
            case "4": // Land
                Console.Write("Enter land type: ");
                string landType = Console.ReadLine();
                
                Console.Write("Enter abilities: ");
                string landAbilities = Console.ReadLine();
                
                newCard = new LandCard(name, color, landType, landAbilities, set);
                break;
                
            default:
                Console.WriteLine("Invalid card type.");
                break;
        }
        
        if (newCard != null)
        {
            manager.AddCard(newCard);
            Console.WriteLine($"\nCard '{name}' created and added to collection!");
        }
        
        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey();
    }
    
    static void CreateNewDeck(CardCollectionManager manager)
    {
        Console.Clear();
        Console.WriteLine("=== Create New Deck ===");
        
        Console.Write("Enter deck name: ");
        string deckName = Console.ReadLine();
        
        Deck newDeck = new Deck(deckName);
        manager.AddDeck(newDeck);
        
        Console.WriteLine($"\nDeck '{deckName}' created!");
        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey();
    }
    
    static void AddCardToDeck(CardCollectionManager manager)
    {
        Console.Clear();
        Console.WriteLine("=== Add Card to Deck ===");
        
        List<Deck> allDecks = manager.GetAllDecks();
        if (allDecks.Count == 0)
        {
            Console.WriteLine("No decks created yet. Create a deck first.");
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
            return;
        }
        
        Console.WriteLine("Select deck:");
        for (int i = 0; i < allDecks.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {allDecks[i].Name}");
        }
        
        Console.Write("\nEnter deck number: ");
        if (int.TryParse(Console.ReadLine(), out int deckIndex) && deckIndex >= 1 && deckIndex <= allDecks.Count)
        {
            Deck selectedDeck = allDecks[deckIndex - 1];
            
            Console.Clear();
            Console.WriteLine($"=== Add Card to {selectedDeck.Name} ===");
            
            List<Card> allCards = manager.GetAllCards();
            if (allCards.Count == 0)
            {
                Console.WriteLine("No cards in collection. Add cards first.");
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
                return;
            }
            
            for (int i = 0; i < allCards.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {allCards[i].GetCardInfo()}");
            }
            
            Console.Write("\nEnter card number to add: ");
            if (int.TryParse(Console.ReadLine(), out int cardIndex) && cardIndex >= 1 && cardIndex <= allCards.Count)
            {
                Card selectedCard = allCards[cardIndex - 1];
                selectedDeck.AddCard(selectedCard);
                Console.WriteLine($"\nAdded '{selectedCard.Name}' to '{selectedDeck.Name}'!");
            }
            else
            {
                Console.WriteLine("Invalid card number.");
            }
        }
        else
        {
            Console.WriteLine("Invalid deck number.");
        }
        
        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey();
    }
    
    static void SaveCollection(CardCollectionManager manager)
    {
        Console.Clear();
        Console.WriteLine("=== Save Collection ===");
        
        Console.Write("Enter filename to save: ");
        string filename = Console.ReadLine();
        
        if (manager.SaveToFile(filename))
        {
            Console.WriteLine($"\nCollection saved to '{filename}'!");
        }
        else
        {
            Console.WriteLine("\nFailed to save collection.");
        }
        
        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey();
    }
    
    static void LoadCollection(CardCollectionManager manager)
    {
        Console.Clear();
        Console.WriteLine("=== Load Collection ===");
        
        Console.Write("Enter filename to load: ");
        string filename = Console.ReadLine();
        
        if (manager.LoadFromFile(filename))
        {
            Console.WriteLine($"\nCollection loaded from '{filename}'!");
        }
        else
        {
            Console.WriteLine("\nFailed to load collection.");
        }
        
        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey();
    }
}