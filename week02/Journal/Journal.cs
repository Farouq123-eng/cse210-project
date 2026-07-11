using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class Journal
{
    private readonly List<Entry> _entries = new List<Entry>();

    public void AddEntry(Entry entry)
    {
        _entries.Add(entry);
    }

    public void DisplayAll()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("No entries have been added yet.");
            return;
        }

        foreach (Entry entry in _entries)
        {
            Console.WriteLine($"Date: {entry.Date}");
            Console.WriteLine($"Prompt: {entry.Prompt}");
            Console.WriteLine($"Response: {entry.Response}");
            Console.WriteLine($"Mood: {entry.Mood}");
            Console.WriteLine();
        }
    }

    public void SearchByWord(string keyword)
    {
        if (string.IsNullOrWhiteSpace(keyword))
        {
            Console.WriteLine("Please enter a valid word.");
            return;
        }

        List<Entry> matches = _entries
            .Where(entry =>
                entry.Response.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
                entry.Prompt.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
                entry.Mood.Contains(keyword, StringComparison.OrdinalIgnoreCase))
            .ToList();

        if (matches.Count == 0)
        {
            Console.WriteLine("No entries matched your search.");
            return;
        }

        foreach (Entry entry in matches)
        {
            Console.WriteLine($"Date: {entry.Date}");
            Console.WriteLine($"Prompt: {entry.Prompt}");
            Console.WriteLine($"Response: {entry.Response}");
            Console.WriteLine($"Mood: {entry.Mood}");
            Console.WriteLine();
        }
    }

    public void SaveToFile(string fileName)
    {
        string fullPath = GetFullPath(fileName);
        using StreamWriter writer = new StreamWriter(fullPath);
        foreach (Entry entry in _entries)
        {
            writer.WriteLine($"{entry.Date}|{entry.Prompt}|{entry.Response}|{entry.Mood}");
        }
    }

    public void LoadFromFile(string fileName)
    {
        string fullPath = GetFullPath(fileName);

        if (!File.Exists(fullPath))
        {
            Console.WriteLine($"File not found: {fullPath}");
            return;
        }

        _entries.Clear();
        string[] lines = File.ReadAllLines(fullPath);

        foreach (string line in lines)
        {
            string[] parts = line.Split('|');
            if (parts.Length >= 3)
            {
                string mood = parts.Length >= 4 ? parts[3] : "Not specified";
                Entry entry = new Entry(parts[0], parts[1], parts[2], mood);
                _entries.Add(entry);
            }
        }
    }

    private string GetFullPath(string fileName)
    {
        if (Path.IsPathRooted(fileName))
        {
            return fileName;
        }

        return Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), fileName));
    }
}
