namespace Katas.Dependencies.Parsing;

public class StringInputParser
{
    public Component Parse(string input)
    {
        var components = input.Split(' ');
        return new Component(components[0], components[1..]);
    }
}

public record Component(string Name, IList<string> Dependencies);