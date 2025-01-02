using System.ComponentModel;
using Katas.Dependencies.DependenciesTree;
using Spectre.Console.Cli;

// ReSharper disable ClassNeverInstantiated.Global

namespace Katas.Dependencies.Cli;

[Description("Prints the specified dependencies tree")]
public class PrintCommand : Command<PrintCommand.Settings>
{
    public sealed class Settings(string input, string filePath) : CommandSettings
    {

        [CommandArgument(0, "[INPUT]")]
        [Description("The list of components and dependencies. The first token of each input line " +
                     "should be the name of the token. The remaining tokens are the names of the " +
                     "things the first item depends upon.")]
        public required string Input { get; init; } = input;

        [CommandOption("-f|--file <PATH>")]
        [Description("The dependency file to read from.")]
        public required string FilePath { get; init; } = filePath;
    }

    public override int Execute(CommandContext context, Settings settings)
    {
        if (!string.IsNullOrWhiteSpace(settings.Input))
        {
            Console.WriteLine(DependencyTree.Print(settings.Input));
            return 0;
        }

        if (!string.IsNullOrWhiteSpace(settings.FilePath))
        {
            var input = File.ReadAllText(settings.FilePath);
            Console.WriteLine(DependencyTree.Print(input));
            return 0;
        }


        using var reader = new StreamReader(Console.OpenStandardInput());
        Console.WriteLine(DependencyTree.Print(reader.ReadToEnd()));
        return 0;
    }
}