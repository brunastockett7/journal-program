using System;
using System.Collections.Generic;

class Program
{
    // EXCEEDS REQUIREMENTS:
    // - This program adds a mood tracker to each journal entry.
    // - It also saves and loads the journal using JSON format for better structure and readability.

    static List<string> prompts = new List<string>
    {
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?"
    };

    static void Main()
    {
        Journal journal = new Journal();
        string? choice = "";

        while (choice != "5")
        {
            Console.WriteLine("\nJournal Menu:");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal to a file");
            Console.WriteLine("4. Load the journal from a file");
            Console.WriteLine("5. Exit");
            Console.Write("Choose an option: ");
            choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    WriteEntry(journal);
                    break;
                case "2":
                    journal.DisplayEntries();
                    break;
                case "3":
                    Console.Write("Enter filename to save (e.g., journal.json): ");
                    string? saveFile = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(saveFile))
                    {
                        journal.SaveToFile(saveFile);
                    }
                    else
                    {
                        Console.WriteLine("Filename cannot be empty.");
                    }
                    break;
                case "4":
                    Console.Write("Enter filename to load (e.g., journal.json): ");
                    string? loadFile = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(loadFile))
                    {
                        journal.LoadFromFile(loadFile);
                    }
                    else
                    {
                        Console.WriteLine("Filename cannot be empty.");
                    }
                    break;
                case "5":
                    Console.WriteLine("Goodbye!");
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    static void WriteEntry(Journal journal)
    {
        Random rand = new Random();
        string prompt = prompts[rand.Next(prompts.Count)];

        Console.WriteLine($"\nPrompt: {prompt}");

        Console.Write("Your response: ");
        string? response = Console.ReadLine();

        Console.Write("Your mood today: ");
        string? mood = Console.ReadLine();

        if (!string.IsNullOrWhiteSpace(response) && !string.IsNullOrWhiteSpace(mood))
        {
            Entry entry = new Entry(prompt, response, mood);
            journal.AddEntry(entry);
            Console.WriteLine("Entry added successfully!");
        }
        else
        {
            Console.WriteLine("Response and mood cannot be empty.");
        }
    }
}
