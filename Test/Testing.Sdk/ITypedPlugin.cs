using SimplePlugin.Abstractions;

namespace Testing.Sdk;

public interface ITypedPlugin : IPluginModule
{
    public string Name { get; }
}