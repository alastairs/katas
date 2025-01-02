using Katas.Dependencies.Parsing;

namespace Katas.Dependencies;

public class DependencyTree
{
    private readonly Dictionary<string, SortedSet<string>> _tree = new();

    public void Add(Component component)
    {
        _tree.Add(component.Name, new SortedSet<string>(component.Dependencies));

        // Update existing components' dependencies
        foreach (var (_, dependencies) in _tree)
        {
            if (dependencies.Contains(component.Name))
            {
                dependencies.UnionWith(component.Dependencies);
            }
        }
    }

    public bool Contains(string componentName) =>
        _tree.ContainsKey(componentName);

    public IEnumerable<string> DependenciesFor(string componentName) =>
        _tree[componentName];
}