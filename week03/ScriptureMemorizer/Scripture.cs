using System;
using System.Collections.Generic;
using System.Linq;

public class Scripture
{
    private Reference _reference;
    private List<Word> _words;
    private static readonly Random _rand = new Random();

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();
        foreach (var wordText in text.Split(' '))
        {
            _words.Add(new Word(wordText));
        }
    }

    public void HideRandomWords(int count = 3)
    {
        var visibleIndices = _words
            .Select((w, i) => new { Word = w, Index = i })
            .Where(x => !x.Word.IsHidden())
            .Select(x => x.Index)
            .ToList();

        if (visibleIndices.Count == 0) return;

        for (int i = 0; i < count && visibleIndices.Count > 0; i++)
        {
            int pick = _rand.Next(visibleIndices.Count);
            int index = visibleIndices[pick];
            _words[index].Hide();
            visibleIndices.RemoveAt(pick);
        }
    }

    public bool AllHidden()
    {
        foreach (var word in _words)
        {
            if (!word.IsHidden()) return false;
        }
        return true;
    }

    public override string ToString()
    {
        string wordsStr = string.Join(" ", _words);
        return $"{_reference}\n{wordsStr}";
    }
}