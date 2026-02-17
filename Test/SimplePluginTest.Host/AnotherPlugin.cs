using SimplePlugin;
using SimplePluginTest.Sdk;

namespace SimplePluginTest.Host;

[PluginModule]
public class AnotherPlugin : ITypedPlugin
{
    public string Name => "Testy";
}