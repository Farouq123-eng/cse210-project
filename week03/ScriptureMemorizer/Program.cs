using System;
using System.IO;
using System.Collections.Generic;

class Program
{
    static void ClearScreen()
    {
        Console.Clear();
    }

    static void Main(string[] args)
    {
        var scriptures = LoadScriptures("scriptures.txt");
        Scripture scripture;

        if (scriptures.Count > 0)
        {
            var rand = new Random();
            scripture = scriptures[rand.Next(scriptures.Count)];
        }
        else
        {
            Reference reference = new Reference("John", 3, 16);
            string text = "For God so Loved the world that he gave his only begotten Son";
            scripture = new Scripture(reference, text);
        }

        while (true)
        {
            ClearScreen();
            Console.WriteLine(scripture);
            Console.WriteLine("\nPress Enter to continue or type 'quit': ");
            string input = Console.ReadLine();

            if (input != null && input.ToLower() == "quit")
                break;

            scripture.HideRandomWords();

            if (scripture.AllHidden())
            {
                ClearScreen();
                Console.WriteLine(scripture);
                break;
            }
        }
    }

    static List<Scripture> LoadScriptures(string fileName)
    {
        var list = new List<Scripture>();
        if (!File.Exists(fileName)) return list;

        foreach (var line in File.ReadAllLines(fileName))
        {
            var trimmed = line.Trim();
            if (string.IsNullOrWhiteSpace(trimmed) || trimmed.StartsWith("#")) continue;

            // Expected format: Book|chapter|verse[-endVerse]|text
            var parts = trimmed.Split('|', 4);
            if (parts.Length < 4) continue;

            var book = parts[0].Trim();
            if (!int.TryParse(parts[1], out int chapter)) continue;

            var versePart = parts[2].Trim();
            int verse = 0;
            int? endVerse = null;
            if (versePart.Contains('-'))
            {
                var vs = versePart.Split('-', 2);
                if (!int.TryParse(vs[0], out verse)) continue;
                if (int.TryParse(vs[1], out int ev)) endVerse = ev;
            }
            else
            {
                if (!int.TryParse(versePart, out verse)) continue;
            }

            var text = parts[3].Trim();
            Reference reference = endVerse.HasValue ? new Reference(book, chapter, verse, endVerse.Value) : new Reference(book, chapter, verse);
            list.Add(new Scripture(reference, text));
        }

        return list;
    }
}