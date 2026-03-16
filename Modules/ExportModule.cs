using Microsoft.Extensions.DependencyInjection;

public class ExportModule : IModule
{
    public string Name => "Export";

    public List<string> Dependencies => new() { "Reporting" };

    public void RegisterServices(IServiceCollection services)
    {
    }

    public void Initialize(IServiceProvider provider)
    {
        Console.WriteLine("Exporting report to file...");

        File.WriteAllText("report.txt", "Report exported");
    }
}
