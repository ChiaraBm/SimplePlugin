using SimplePlugin.Abstractions;
using Testing.Sdk;

namespace Testing.Plugin;

[PluginModule]
public class ExternalPlugin : ITypedPlugin
{
    public string Name => "ExternalPlugin";
}