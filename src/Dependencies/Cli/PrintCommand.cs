using System.ComponentModel;
using Katas.Dependencies.DependenciesTree;
using Spectre.Console.Cli;

namespace Katas.Dependencies.Cli;

[Description("Prints the specified dependencies tree")]
public class PrintCommand : Command<PrintCommand.Settings>
{
    public sealed class Settings : CommandSettings
    {
        [CommandOption("-f|--file <FILE>")]
        [Description("The dependency file to read from. Use [grey]-[/] to read from standard input.")]
        public required FlagValue<string> FilePath { get; set; }

        [CommandArgument(0, "<LIST>")]
        public required string Input { get; set; }
    }

    public override int Execute(CommandContext context, Settings settings)
    {
        var input = settings.Input;

        if (settings.FilePath.IsSet)
        {
            var stream = settings.FilePath switch
            {
                { IsSet: true } and { Value: "-" } => Console.OpenStandardInput(),
                _ => File.OpenRead(settings.FilePath.Value)
            };

            using var reader = new StreamReader(stream);
            input = reader.ReadToEnd();
        }

        Console.WriteLine(DependencyTree.Print(input));
        return 0;
    }
}