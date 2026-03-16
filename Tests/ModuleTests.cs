using Xunit;

public class ModuleTests
{
    [Fact]
    public void CorrectOrderTest()
    {
        var modules = new List<IModule>
        {
            new ValidationModule(),
            new ReportingModule(),
            new ExportModule()
        };

        var ordered = DependencyResolver.Resolve(modules);

        Assert.Equal("Validation", ordered[0].Name);
        Assert.Equal("Reporting", ordered[1].Name);
        Assert.Equal("Export", ordered[2].Name);
    }

    [Fact]
    public void MissingDependencyTest()
    {
        var modules = new List<IModule>
        {
            new ReportingModule()
        };

        Assert.Throws<Exception>(() => DependencyResolver.Resolve(modules));
    }

    [Fact]
    public void CycleTest()
    {
        var a = new TestModule("A", new() { "B" });
        var b = new TestModule("B", new() { "A" });

        var modules = new List<IModule> { a, b };

        Assert.Throws<Exception>(() => DependencyResolver.Resolve(modules));
    }
}
