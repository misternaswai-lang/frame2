using Microsoft.Extensions.DependencyInjection;

public interface IModule
{
    string Name { get; }

    List<string> Dependencies { get; }

    void RegisterServices(IServiceCollection services);

    void Initialize(IServiceProvider serviceProvider);
}
