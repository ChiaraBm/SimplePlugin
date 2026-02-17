using SimplePlugin;

namespace SimplePluginTest.Sdk;

public interface ITypedPlugin : IPluginModule
{
    public string Name { get; }
}