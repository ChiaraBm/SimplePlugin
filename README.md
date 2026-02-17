# SimplePlugin

A lightweight plugin discovery system for .NET that uses Roslyn source generators. No reflection, no runtime scanning instead compile-time code generation that finds your plugins and wires them up automatically.

## How it works

SimplePlugin ships two packages: a core library (`SimplePlugin`) and a source generator (`SimplePlugin.Generator`).

At build time, the generator scans your project and its references for any public, non-abstract class that:
- Implements `IPluginModule`
- Is decorated with `[PluginModule]`
- Has a parameterless constructor

It then generates a static `PluginRegistry` class with a `GetAllModules()` method that returns instances of every discovered plugin. No reflection involved. it's all baked in at compile time.

## Getting started

### 1. Define your plugin interface

Create an interface that extends `IPluginModule` with whatever contract your plugins need:

```csharp
using SimplePlugin;

public interface IGreeterPlugin : IPluginModule
{
    string Name { get; }
    void Greet();
}
```

### 2. Implement a plugin

In a separate project (or the same one), create a class that implements your interface and tag it with `[PluginModule]`:

```csharp
using SimplePlugin;

[PluginModule]
public class HelloPlugin : IGreeterPlugin
{
    public string Name => "Hello Plugin";

    public void Greet() => Console.WriteLine("Hello from a plugin!");
}
```

### 3. Discover and use plugins

In your host application, reference both the plugin project and the `SimplePlugin.Generator` as an analyzer. Then call the generated registry:

```csharp
using SimplePlugin.Generated;

foreach (var plugin in PluginRegistry.GetAllModules().OfType<IGreeterPlugin>())
{
    Console.WriteLine(plugin.Name);
    plugin.Greet();
}
```

## Requirements

- .NET 10+