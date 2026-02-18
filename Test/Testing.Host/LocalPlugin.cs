using SimplePlugin.Abstractions;
using Testing.Sdk;

namespace Testing.Host;

[PluginModule]
public class LocalPlugin : ITypedPlugin
{
    public string Name => "LocalPlugin";
}