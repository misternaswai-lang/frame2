using Microsoft.Extensions.DependencyInjection;

public class ReportingModule : IModule
{
    public string Name => "Reporting";

    public List<string> Dependencies => new() { "Validation" };

    public void RegisterServices(IServiceCollection services)
    {
    }

    public void Initialize(IServiceProvider provider)
    {
        var data = provider.GetRequiredService<IDataService>();

        Console.WriteLine("Student report:");

        foreach (var s in data.GetStudents())
        {
            Console.WriteLine($" - {s}");
        }
    }
}
