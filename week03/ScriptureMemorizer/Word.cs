public class Word
{
    private string _text;
    private bool _hidden;

    public Word(string text)
    {
        _text = text;
        _hidden = false;
    }

    public void Hide()
    {
        _hidden = true;
    }

    public bool IsHidden()
    {
        return _hidden;
    }

    public override string ToString()
    {
        if (!_hidden) return _text;

        var chars = _text.Select(c => char.IsLetter(c) ? '_' : c).ToArray();
        return new string(chars);
    }
}
