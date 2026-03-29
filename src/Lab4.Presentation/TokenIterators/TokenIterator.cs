namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.TokenIterators;

public class TokenIterator
{
    private readonly string[] _tokens;

    public int Index { get; private set; }

    public TokenIterator(string data)
    {
        _tokens = data.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        Index = 0;
    }

    public bool IsEnd => Index >= _tokens.Length;

    public string? NextToken()
    {
        return Index >= _tokens.Length ? null : _tokens[Index++];
    }

    public void SetIndex(int newIndex)
    {
        if (newIndex < _tokens.Length)
        {
            Index = newIndex;
        }
    }
}
