using System;
public class GeneratePrompt
{
    private static readonly List<string> prompts = new List<string>
    {
        "How are you today?",
        "What was the best part of your day?",
        "If you could travel anywhere right now where would you go?",
        "What's one thing you're grateful for?",
        "Tell me about a recent accomplishment you're proud of.",
        "What’s something new you’ve learned recently?",
        "If you could have dinner with any historical figure who would it be and why?",
        "Describe your perfect weekend.",
        "What's a hobby or activity you enjoy?",
        "What’s a challenge you’ve recently overcome?"
    };

    private static readonly Random random = new Random();

    public static string GetRandomPrompt()
    {
        int index = random.Next(prompts.Count);
        return prompts[index];
    }
}