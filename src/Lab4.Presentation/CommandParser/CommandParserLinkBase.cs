using Itmo.ObjectOrientedProgramming.Lab4.Presentation.CommandParser.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.CommandParser.Results;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.TokenIterators;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.CommandParser;

public abstract class CommandParserLinkBase : ICommandParserLink
{
    private ICommandParserLink? _next;

    public abstract ParserResult Parse(TokenIterator input);

    public ICommandParserLink AddNext(ICommandParserLink link)
    {
        if (_next is null)
        {
            _next = link;
        }
        else
        {
            _next.AddNext(link);
        }

        return this;
    }

    protected ParserResult CallNext(TokenIterator iterator)
    {
        return _next?.Parse(iterator) ?? new ParserResult.Failure();
    }
}