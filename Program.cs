// See https://aka.ms/new-console-template for more information

// -------------------------------
// Extra Credit Note:
// This journal program exceeds core requirements by including:
// - Mood tracking: the user selects how they feel after writing
// - Gratitude reflection: the user adds one thing they're thankful for
// These features encourage emotional reflection and improve journaling consistency.
// -------------------------------

using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        List<string> prompts = new List<string>
        {
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?"
        };

        string? choice = "";
        while (choice != "5")
        {
            Console.WriteLine("\nPlease select one of the following choices:");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Quit");
            Console.Write("What would you like to do? ");
            choice = Console.ReadLine()?.Trim();

            switch (choice)
            {
                case "1":
                    string prompt = GetRandomPrompt(prompts);
                    Console.WriteLine($"\nPrompt: {prompt}");
                    Console.Write("Your response: ");
                    string? response = Console.ReadLine();

                    Console.Write("How are you feeling? (Happy, Sad, Stressed, etc.): ");
                    string? mood = Console.ReadLine();

                    Console.Write("One thing you're grateful for today: ");
                    string? gratitude = Console.ReadLine();

                    string date = DateTime.Now.ToString("MM/dd/yyyy");
                    Entry newEntry = new Entry(date, prompt, response, mood, gratitude);
                    journal.AddEntry(newEntry);
                    break;

                case "2":
                    journal.DisplayAll();
                    break;

                case "3":
                    Console.Write("Enter filename to load: ");
                    string? loadFile = Console.ReadLine();
                    journal.LoadFromFile(loadFile);
                    break;

                case "4":
                    Console.Write("Enter filename to save: ");
                    string? saveFile = Console.ReadLine();
                    journal.SaveToFile(saveFile);
                    break;

                case "5":
                    Console.WriteLine("Goodbye!");
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please select 1–5.");
                    break;
            }
        }
    }

    static string GetRandomPrompt(List<string> prompts)
    {
        Random rand = new Random();
        int index = rand.Next(prompts.Count);
        return prompts[index];
    }
}


