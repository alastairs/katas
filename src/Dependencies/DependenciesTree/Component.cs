namespace Katas.Dependencies.DependenciesTree;

public record Component(string Name, IList<string> Dependencies)
{
    public static Component Parse(string input)
    {
        var components = input.Split(' ');
        return new Component(components[0], components[1..]);
    }

    public static IEnumerable<Component> ParseMany(string input)
    {
        var lines = input.Split('\n', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
        return lines.Select(Parse);
    }
}