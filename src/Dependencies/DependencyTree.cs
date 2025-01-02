using Katas.Dependencies.Parsing;

namespace Katas.Dependencies;

public class DependencyTree
{
    private readonly Dictionary<string, SortedSet<string>> _tree = new();

    public void Add(Component component)
    {
        _tree.Add(component.Name, new SortedSet<string>(component.Dependencies));

        foreach (var current in _tree)
        {
            var (_, nodeDependencies) = current;

            UpdateChildDependencies(nodeDependencies, component);
            UpdateParentDependencies(nodeDependencies);
        }
    }

    private static void UpdateChildDependencies(SortedSet<string> nodeDependencies, Component newComponent)
    {
        // If the new component is a dependency of the current node, add the new component's dependencies to the
        // node. E.g.: if A exists in the tree and depends on B, and B is being added to
        // the tree and depends on E, then A must depend on E too.
        if (nodeDependencies.Contains(newComponent.Name))
        {
            nodeDependencies.UnionWith(newComponent.Dependencies);
        }
    }

    private void UpdateParentDependencies(SortedSet<string> nodeDependencies)
    {
        // If the current node is a dependency of the new component, add the current node's own dependencies to
        // the new component. E.g.: if B exists in the tree and depends on C and E, and A is being added to the
        // tree and depends on B and C, then A must also depend on E.
        for (var i = 0; i < nodeDependencies.Count; i++)
        {
            if (_tree.TryGetValue(nodeDependencies.ToArray()[i], out var furtherDependencies))
            {
                nodeDependencies.UnionWith(furtherDependencies);
            }
        }
    }

    public bool Contains(string componentName) =>
        _tree.ContainsKey(componentName);

    public IEnumerable<string> DependenciesFor(string componentName) =>
        _tree[componentName];
}