namespace Katas.Dependencies.Tests;

public class StringInputParserFacts
{
    [Fact]
    public void Input_is_split_on_single_whitespaces()
    {
        const string input = "A B C";
        var sut = new StringInputParser();

        var result = sut.Parse(input);

        Assert.Equivalent(new Component("A", ["B", "C"]), result);
    }

    [Fact]
    public void Longer_input_is_split_on_single_whitespaces()
    {
        const string input = "A B C D E F";
        var sut = new StringInputParser();

        var result = sut.Parse(input);

        Assert.Equivalent(new Component("A", ["B", "C", "D", "E", "F"]), result);
    }
}
