using Katas.Dependencies.Parsing;

namespace Katas.Dependencies;

public class DependencyTree
{
    private readonly Dictionary<string, SortedSet<string>> _tree = new();

    public void Add(Component component) =>
        _tree.Add(component.Name, new SortedSet<string>(component.Dependencies));

    public bool Contains(string componentName) =>
        _tree.ContainsKey(componentName);
}