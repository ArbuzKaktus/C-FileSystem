using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab4.Core.PathResolvers.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Results;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Sessions;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Writers.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.CommandParser.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.CommandParser.Results;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.TokenIterators;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Applications;

public class Application
{
    private readonly IWriter _writer;
    private readonly ICommandParser _commandParser;
    private readonly Session _currentSession;

    public Application(IWriter writerForTreeList, ICommandParser commandParser, IPathResolver pathResolver)
    {
        _writer = writerForTreeList;
        _commandParser = commandParser;
        _currentSession = new Session(pathResolver);
    }

    public void RunApp()
    {
        while (true)
        {
            ShowCurrentPath();

            string? input = Console.ReadLine();

            if (string.IsNullOrEmpty(input))
            {
                continue;
            }

            input = input.Trim();

            ExecuteCommand(input);
        }
    }

    private void ShowCurrentPath()
    {
        _writer.WriteLine(_currentSession is { IsConnected: true, CurrentPath: not null }
            ? $"[{_currentSession.CurrentPath}] % "
            : "[disconnected] % ");
    }

    private void ExecuteCommand(string input)
    {
        ParserResult commandBuilder = _commandParser.Parse(new TokenIterator(input));

        if (commandBuilder is not ParserResult.Success commandBuilderSuccess)
        {
            _writer.WriteLine("Error: Unknown command");
            return;
        }

        ICommand command = commandBuilderSuccess.CommandBuilder.Build();

        CommandResult result = command.Execute(_currentSession);
        _writer.WriteLine(result is CommandResult.Success ? "command done" : "error occured");
    }
}