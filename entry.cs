using System;

public class Entry
{
    public string? _date;
    public string? _prompt;
    public string? _response;
    public string? _mood;
    public string? _gratitude;

    public Entry(string? date, string? prompt, string? response, string? mood, string? gratitude)
    {
        _date = date;
        _prompt = prompt;
        _response = response;
        _mood = mood;
        _gratitude = gratitude;
    }

    public void Display()
    {
        Console.WriteLine($"Date: {_date}");
        Console.WriteLine($"Prompt: {_prompt}");
        Console.WriteLine($"Response: {_response}");
        Console.WriteLine($"Mood: {_mood}");
        Console.WriteLine($"Gratitude: {_gratitude}");
    }
}
