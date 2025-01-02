namespace Katas.Dependencies.Tests;

public class StringParsingFacts
{
    [Fact]
    public void Input_is_split_on_single_whitespaces()
    {
        const string input = "A B C";
        var result = Component.Parse(input);

        Assert.Equivalent(new Component("A", ["B", "C"]), result);
    }

    [Fact]
    public void Longer_input_is_split_on_single_whitespaces()
    {
        const string input = "A B C D E F";

        var result = Component.Parse(input);

        Assert.Equivalent(new Component("A", ["B", "C", "D", "E", "F"]), result);
    }

    [Fact]
    public void Multiple_dependencies_are_parsed_out_of_the_string()
    {
        const string input = """
                             A B C
                             B C E
                             C G
                             """;

        var result = Component.ParseMany(input);

        Assert.Equivalent(new List<Component> {
            new("A", ["B", "C"]),
            new("B", ["C", "E"]),
            new("C", ["G"]),
        }, result);
    }
}
