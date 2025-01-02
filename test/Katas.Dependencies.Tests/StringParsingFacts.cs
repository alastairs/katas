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
}
