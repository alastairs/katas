﻿namespace Katas.Dependencies.Tests;

public class DependencyTreeFacts
{
    [Fact]
    public void Components_are_added_to_the_tree()
    {
        var sut = new DependencyTree();
        sut.Add(new Component("A", ["B", "C"]));
        Assert.True(sut.Contains("A"));
    }

    [Fact]
    public void Dependencies_are_added_to_the_tree()
    {
        var sut = new DependencyTree();

        sut.Add(new Component("A", ["B", "C"]));
        sut.Add(new Component("B", ["C", "E"]));

        Assert.Distinct(sut.DependenciesFor("A"));
        Assert.Equal(["B", "C", "E"], sut.DependenciesFor("A"));
    }

    [Fact]
    public void Dependencies_are_retrospectively_updated()
    {
        var sut = new DependencyTree();

        sut.Add(new Component("B", ["C", "E"]));
        sut.Add(new Component("A", ["B", "C"]));

        Assert.Distinct(sut.DependenciesFor("A"));
        Assert.Equal(["B", "C", "E"], sut.DependenciesFor("A"));
    }

    [Fact]
    public void Tree_can_be_printed()
    {
        var sut = new DependencyTree();

        sut.Add(new Component("A", ["B", "C"]));

        Assert.Equal("A  B C", sut.Print());
    }
}