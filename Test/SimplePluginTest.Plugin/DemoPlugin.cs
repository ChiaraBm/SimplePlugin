using SimplePlugin;
using SimplePluginTest.Sdk;

namespace SimplePluginTest.Plugin;

[PluginModule]
public class DemoPlugin : ITypedPlugin
{
    public string Name => "My cool plugin";
}