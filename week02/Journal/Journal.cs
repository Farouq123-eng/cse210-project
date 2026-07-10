using System;
using System.Collections.Generic;
using System.IO;

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
            Console.WriteLine();
        }
    }

    public void SaveToFile(string fileName)
    {
        string fullPath = GetFullPath(fileName);
        using StreamWriter writer = new StreamWriter(fullPath);
        foreach (Entry entry in _entries)
        {
            writer.WriteLine($"{entry.Date}|{entry.Prompt}|{entry.Response}");
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
            if (parts.Length == 3)
            {
                Entry entry = new Entry(parts[0], parts[1], parts[2]);
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
