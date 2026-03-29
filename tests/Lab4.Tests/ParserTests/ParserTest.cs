using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.ConnectCommandBuilders;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.DisconnectCommandBuilders;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.FileCopyCommandBuilders;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.FileDeleteCommandBuilders;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.FileMoveCommandBuilders;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.FileRenameCommandBuilders;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.FileShowCommandBuilders;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.TreeGoToCommandBuilders;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.TreeListCommandBuilders;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Writers;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.CommandParser.CommandParserFactories;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.CommandParser.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.CommandParser.ParameterHandlers.FileSystemModeHandlers;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.CommandParser.ParameterHandlers.FileViewerModeHandlers;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.CommandParser.Results;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.TokenIterators;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab4.Tests.ParserTests;

public class ParserTest
{
    [Fact]
    public void Parse_ConnectCommand_ConnectCommandWithAddress()
    {
        // Arrange
        ICommandParser parser = CreateParser();
        const string input = "connect /Users/kek/directory";

        // Act
        ParserResult result = parser.Parse(new TokenIterator(input));

        // Assert
        Assert.IsType<ParserResult.Success>(result);
        var success = (ParserResult.Success)result;
        Assert.IsType<ConnectCommandBuilder>(success.CommandBuilder);
        ICommand command = success.CommandBuilder.Build();
        Assert.IsType<ConnectCommand>(command);
    }

    [Fact]
    public void Parse_ConnectCommand_ConnectCommandWithAddressAndModeFlag()
    {
        // Arrange
        ICommandParser parser = CreateParser();
        const string input = "connect /arbuzKaktus/tests/labwork -m local";

        // Act
        ParserResult result = parser.Parse(new TokenIterator(input));

        // Assert
        Assert.IsType<ParserResult.Success>(result);
        var success = (ParserResult.Success)result;
        Assert.IsType<ConnectCommandBuilder>(success.CommandBuilder);
        ICommand command = success.CommandBuilder.Build();
        Assert.IsType<ConnectCommand>(command);
    }

    [Fact]
    public void Parse_DisconnectCommand_DisconnectCommand()
    {
        // Arrange
        ICommandParser parser = CreateParser();
        const string input = "disconnect";

        // Act
        ParserResult result = parser.Parse(new TokenIterator(input));

        // Assert
        Assert.IsType<ParserResult.Success>(result);
        var success = (ParserResult.Success)result;
        Assert.IsType<DisconnectCommandBuilder>(success.CommandBuilder);
        ICommand command = success.CommandBuilder.Build();
        Assert.IsType<ConnectedCommand>(command);
    }

    [Fact]
    public void Parse_TreeGoToCommand_TreeGoToCommand()
    {
        // Arrange
        ICommandParser parser = CreateParser();
        const string input = "tree goto /Useeeers/teeeeest/блаблабла";

        // Act
        ParserResult result = parser.Parse(new TokenIterator(input));

        // Assert
        Assert.IsType<ParserResult.Success>(result);
        var success = (ParserResult.Success)result;
        Assert.IsType<TreeGoToCommandBuilder>(success.CommandBuilder);
        ICommand command = success.CommandBuilder.Build();
        Assert.IsType<ConnectedCommand>(command);
    }

    [Fact]
    public void Parse_TreeListCommand_TreeListCommandDefault()
    {
        // Arrange
        ICommandParser parser = CreateParser();
        const string input = "tree list";

        // Act
        ParserResult result = parser.Parse(new TokenIterator(input));

        // Assert
        Assert.IsType<ParserResult.Success>(result);
        var success = (ParserResult.Success)result;
        Assert.IsType<TreeListCommandBuilder>(success.CommandBuilder);
        ICommand command = success.CommandBuilder.Build();
        Assert.IsType<ConnectedCommand>(command);
    }

    [Fact]
    public void Parse_TreeListCommand_TreeListCommandWithDepthFlag()
    {
        // Arrange
        ICommandParser parser = CreateParser();
        const string input = "tree list -d 44";

        // Act
        ParserResult result = parser.Parse(new TokenIterator(input));

        // Assert
        Assert.IsType<ParserResult.Success>(result);
        var success = (ParserResult.Success)result;
        Assert.IsType<TreeListCommandBuilder>(success.CommandBuilder);
        ICommand command = success.CommandBuilder.Build();
        Assert.IsType<ConnectedCommand>(command);
    }

    [Fact]
    public void Parse_FileShowCommand_FileShowCommandWithModeFlag()
    {
        // Arrange
        ICommandParser parser = CreateParser();
        const string input = "file show /плз/апруввввв/пжпжпжпж/test.txt -m console";

        // Act
        ParserResult result = parser.Parse(new TokenIterator(input));

        // Assert
        Assert.IsType<ParserResult.Success>(result);
        var success = (ParserResult.Success)result;
        Assert.IsType<FileShowCommandBuilder>(success.CommandBuilder);
        ICommand command = success.CommandBuilder.Build();
        Assert.IsType<ConnectedCommand>(command);
    }

    [Fact]
    public void Parse_FileMoveCommand_FileMoveCommand()
    {
        // Arrange
        ICommandParser parser = CreateParser();
        const string input = "file move /майнкрафт_пароли/path/file.txt /бравл_старс_пороли/path/";

        // Act
        ParserResult result = parser.Parse(new TokenIterator(input));

        // Assert
        Assert.IsType<ParserResult.Success>(result);
        var success = (ParserResult.Success)result;
        Assert.IsType<FileMoveCommandBuilder>(success.CommandBuilder);
        ICommand command = success.CommandBuilder.Build();
        Assert.IsType<ConnectedCommand>(command);
    }

    [Fact]
    public void Parse_FileCopyCommand_FileCopyCommand()
    {
        // Arrange
        ICommandParser parser = CreateParser();
        const string input = "file copy /source/path/file.txt /destination/path/";

        // Act
        ParserResult result = parser.Parse(new TokenIterator(input));

        // Assert
        Assert.IsType<ParserResult.Success>(result);
        var success = (ParserResult.Success)result;
        Assert.IsType<FileCopyCommandBuilder>(success.CommandBuilder);
        ICommand command = success.CommandBuilder.Build();
        Assert.IsType<ConnectedCommand>(command);
    }

    [Fact]
    public void Parse_FileDeleteCommand_FileDeleteCommand()
    {
        // Arrange
        ICommandParser parser = CreateParser();
        const string input = "file delete /path/to/file.txt";

        // Act
        ParserResult result = parser.Parse(new TokenIterator(input));

        // Assert
        Assert.IsType<ParserResult.Success>(result);
        var success = (ParserResult.Success)result;
        Assert.IsType<FileDeleteCommandBuilder>(success.CommandBuilder);
        ICommand command = success.CommandBuilder.Build();
        Assert.IsType<ConnectedCommand>(command);
    }

    [Fact]
    public void Parse_FileRenameCommand_FileRenameCommand()
    {
        // Arrange
        ICommandParser parser = CreateParser();
        const string input = "file rename /path/to/old_name.txt new_name.txt";

        // Act
        ParserResult result = parser.Parse(new TokenIterator(input));

        // Assert
        Assert.IsType<ParserResult.Success>(result);
        var success = (ParserResult.Success)result;
        Assert.IsType<FileRenameCommandBuilder>(success.CommandBuilder);
        ICommand command = success.CommandBuilder.Build();
        Assert.IsType<ConnectedCommand>(command);
    }

    private static ICommandParser CreateParser()
    {
        var writer = new ConsoleWriter();
        var factory = new CommandParserFactory(writer, new FileSystemModeHandlerFactory(), new FileViewerModeHandlerFactory());
        return factory.Create();
    }
}