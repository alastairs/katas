using Katas.Dependencies.Parsing;

namespace Katas.Dependencies;

public class DependencyTree
{
    private readonly Dictionary<string, SortedSet<string>> _tree = new();

    public void Add(Component component)
    {
        _tree.Add(component.Name, new SortedSet<string>(component.Dependencies));

        foreach(var (_, dependencies) in _tree)
        {
            UpdateDependencies(dependencies, component);
        }
    }

    private void UpdateDependencies(SortedSet<string> dependencies, Component component)
    {
        // "Forward" update: if the new component is a dependency of the current component, add its dependencies
        // E.g.: if A depends on B, and B (new) depends on E, then A must depend on E too.
        if (dependencies.Contains(component.Name))
        {
            dependencies.UnionWith(component.Dependencies);
        }

        // "Backward" update: if the current component is a dependency of the new component, add its dependencies
        // E.g.: if B depends on C and E, and A (newly added) depends on B and C, then A must also depend on E.
        for (var i = 0; i < dependencies.Count; i++)
        {
            if (_tree.TryGetValue(dependencies.ToArray()[i], out var furtherDependencies))
            {
                dependencies.UnionWith(furtherDependencies);
            }
        }
    }

    public bool Contains(string componentName) =>
        _tree.ContainsKey(componentName);

    public IEnumerable<string> DependenciesFor(string componentName) =>
        _tree[componentName];
}