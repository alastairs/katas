namespace Katas.Dependencies.Tests;

public class DependencyTreeFacts
{
    [Fact]
    public void Components_are_added_to_the_tree()
    {
        var sut = new DependencyTree();
        sut.Add(new Component("A", ["B", "C"]));
        Assert.True(sut.Contains("A"));
    }
}