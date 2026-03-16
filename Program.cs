var modules = new List<IModule>
{
    new ValidationModule(),
    new ReportingModule(),
    new ExportModule()
};

ModuleManager.RunModules(modules);
