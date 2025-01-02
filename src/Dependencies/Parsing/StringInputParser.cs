namespace Katas.Dependencies.Parsing;

public record Component(string Name, IList<string> Dependencies)
{
    public static Component Parse(string input)
    {
        var components = input.Split(' ');
        return new Component(components[0], components[1..]);
    }
}