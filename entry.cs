using System;

public class Entry
{
    public string _date;
    public string _prompt;
    public string _response;
    public string _mood;

    public Entry(string prompt, string response, string mood)
    {
        _date = DateTime.Now.ToString("yyyy-MM-dd");
        _prompt = prompt;
        _response = response;
        _mood = mood;
    }

    public override string ToString()
    {
        return $"Date: {_date}\nPrompt: {_prompt}\nMood:{_mood}\nResponse: {_response}\n";
    }
}