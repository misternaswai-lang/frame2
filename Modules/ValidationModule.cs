using Microsoft.Extensions.DependencyInjection;

public class ValidationModule : IModule
{
    public string Name => "Validation";

    public List<string> Dependencies => new();

    public void RegisterServices(IServiceCollection services)
    {
        services.AddSingleton<IDataService, DataService>();
    }

    public void Initialize(IServiceProvider provider)
    {
        Console.WriteLine("Validation rules initialized");
    }
}
