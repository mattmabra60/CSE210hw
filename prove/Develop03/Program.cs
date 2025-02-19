public class Program
{
    public static void Main(string[] args)
    {
        // Scripture Library
        var scriptures = new List<Scripture>
        {
            new Scripture(
                new Reference("John", 3, 16),
                "For God so loved the world that he gave his one and only Son, that whoever believes in him shall not perish but have eternal life"
            ),
            new Scripture(
                new Reference("Proverbs", 3, 5, 6),
                "Trust in the LORD with all your heart and lean not on your own understanding; in all your ways submit to him, and he will make your paths straight"
            ),
            new Scripture(
                new Reference("Psalms", 23, 1),
                "The LORD is my shepherd, I lack nothing"
            ),
            new Scripture(
                new Reference("Matthew", 5, 14, 16),
                "You are the light of the world. A town built on a hill cannot be hidden. Neither do people light a lamp and put it under a bowl. Instead they put it on its stand, and it gives light to everyone in the house. In the same way, let your light shine before others, that they may see your good deeds and glorify your Father in heaven"
            )
        };
        // Random scriputre generator (I grabbed this from the prompt generator for the last assignement)
        Random random = new Random();
        var scripture = scriptures[random.Next(scriptures.Count)];

        while (!scripture.IsCompletelyHidden())
        {
            // clear the console and display the scripture
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine("\nPress Enter to continue or type 'quit' to exit:");

            string input = Console.ReadLine();
            if (input.ToLower() == "quit")
                break;

            // allows us to adjust the number of words to hide in the scripture if needed
            scripture.HideRandomWords(3);
        }
    }
}