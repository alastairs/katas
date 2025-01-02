namespace Katas.Dependencies.Tests.AcceptanceTests;

public class AcceptanceTests
{
    [Fact]
    public void Components_are_added_to_the_tree()
    {
        const string input =
            """
            A B C
            B C E
            C G
            D A F
            E F
            F H
            """;

        var actual = DependencyTree.Print(input);

        const string expected =
            """
            A  B C E F G H
            B  C E F G H
            C  G
            D  A B C E F G H
            E  F H
            F  H
            """;
        Assert.Equal(expected, actual);
    }
}