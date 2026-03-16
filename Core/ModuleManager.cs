using Microsoft.Extensions.DependencyInjection;

public class ModuleManager
{
    public static void RunModules(List<IModule> modules)
    {
        var ordered = DependencyResolver.Resolve(modules);

        var services = new ServiceCollection();

        foreach (var module in ordered)
        {
            module.RegisterServices(services);
        }

        var provider = services.BuildServiceProvider();

        foreach (var module in ordered)
        {
            Console.WriteLine($"Initializing {module.Name}");
            module.Initialize(provider);
        }
    }
}
