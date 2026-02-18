// See https://aka.ms/new-console-template for more information

using SimplePlugin.Generated;
using Testing.Sdk;

Console.WriteLine("Hello, World!");

foreach (var pluginModule in PluginRegistry.Modules.OfType<ITypedPlugin>())
{
    Console.WriteLine(pluginModule.Name);
}