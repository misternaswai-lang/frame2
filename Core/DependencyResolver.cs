public static class DependencyResolver
{
    public static List<IModule> Resolve(List<IModule> modules)
    {
        var result = new List<IModule>();
        var visited = new HashSet<string>();
        var visiting = new HashSet<string>();

        var dict = modules.ToDictionary(m => m.Name);

        foreach (var module in modules)
        {
            Visit(module);
        }

        return result;

        void Visit(IModule module)
        {
            if (visited.Contains(module.Name))
                return;

            if (visiting.Contains(module.Name))
                throw new Exception($"Cycle detected involving module {module.Name}");

            visiting.Add(module.Name);

            foreach (var dep in module.Dependencies)
            {
                if (!dict.ContainsKey(dep))
                    throw new Exception($"Module {module.Name} requires missing module {dep}");

                Visit(dict[dep]);
            }

            visiting.Remove(module.Name);
            visited.Add(module.Name);
            result.Add(module);
        }
    }
}
