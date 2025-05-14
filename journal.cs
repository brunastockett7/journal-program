using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    private List<Entry> _entries = new List<Entry>();

    public void AddEntry(Entry entry)
    {
        _entries.Add(entry);
    }

    public void DisplayAll()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("No entries to display.");
            return;
        }

        foreach (Entry entry in _entries)
        {
            entry.Display();
            Console.WriteLine("-----------------------------------");
        }
    }

    public void SaveToFile(string? filename)
    {
        if (!string.IsNullOrWhiteSpace(filename))
        {
            using (StreamWriter writer = new StreamWriter(filename))
            {
                foreach (Entry entry in _entries)
                {
                    writer.WriteLine($"{entry._date}~|~{entry._prompt}~|~{entry._response}~|~{entry._mood}~|~{entry._gratitude}");
                }
            }
            Console.WriteLine($"Journal saved to: {filename}");
        }
        else
        {
            Console.WriteLine("Invalid filename. Save failed.");
        }
    }

    public void LoadFromFile(string? filename)
    {
        _entries.Clear();

        if (!string.IsNullOrWhiteSpace(filename) && File.Exists(filename))
        {
            string[] lines = File.ReadAllLines(filename);

            foreach (string line in lines)
            {
                string[] parts = line.Split("~|~");
                if (parts.Length == 5)
                {
                    Entry entry = new Entry(parts[0], parts[1], parts[2], parts[3], parts[4]);
                    _entries.Add(entry);
                }
            }

            Console.WriteLine($"Journal loaded from: {filename}");
        }
        else
        {
            Console.WriteLine("File not found. Load failed.");
        }
    }
}
