using System.Reflection;

public static class ModuleLoader
{
    public static List<IModule> LoadModules(string path)
    {
        var modules = new List<IModule>();

        foreach (var file in Directory.GetFiles(path, "*.dll"))
        {
            var assembly = Assembly.LoadFrom(file);

            var types = assembly.GetTypes()
                .Where(t => typeof(IModule).IsAssignableFrom(t) && !t.IsInterface);

            foreach (var type in types)
            {
                var module = (IModule)Activator.CreateInstance(type)!;
                modules.Add(module);
            }
        }

        return modules;
    }
}
