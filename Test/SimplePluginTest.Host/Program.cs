using SimplePlugin.Generated;
using SimplePluginTest.Sdk;

Console.WriteLine("Hello, World!");

foreach (var pluginModule in PluginRegistry.GetAllModules().OfType<ITypedPlugin>())
{
    Console.WriteLine(pluginModule.Name);
}