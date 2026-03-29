using Itmo.ObjectOrientedProgramming.Lab4.Core.PathResolvers;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Writers;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Applications;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.CommandParser.CommandParserFactories;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.CommandParser.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.CommandParser.ParameterHandlers.FileSystemModeHandlers;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.CommandParser.ParameterHandlers.FileViewerModeHandlers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation;

public class Program
{
    public static void Main()
    {
        var writer = new ConsoleWriter();
        var fileSystemModeHandlerFactory = new FileSystemModeHandlerFactory();
        var fileViewerModeHandlerFactory = new FileViewerModeHandlerFactory();

        var parserFactory = new CommandParserFactory(writer, fileSystemModeHandlerFactory, fileViewerModeHandlerFactory);
        ICommandParser parser = parserFactory.Create();
        var app = new Application(writer, parser, new LocalPathResolver());
        app.RunApp();
    }
}
