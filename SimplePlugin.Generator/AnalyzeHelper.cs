using System.Collections.Generic;
using Microsoft.CodeAnalysis;

namespace SimplePlugin.Generator;

public static class AnalyzeHelper
{
    public static IEnumerable<INamedTypeSymbol> GetAllTypes(IModuleSymbol module)
    {
        // Current assembly
        foreach (var type in GetAllTypesFromNamespace(module.ContainingAssembly.GlobalNamespace))
            yield return type;

        // Referenced assemblies
        foreach (var assembly in module.ReferencedAssemblySymbols)
        {
            var name = assembly.Identity.Name;

            // Skip system assemblies
            if (name.StartsWith("System") ||
                name.StartsWith("Microsoft") ||
                name.StartsWith("netstandard") ||
                name.StartsWith("mscorlib") ||
                name.StartsWith("runtime."))
            {
                continue;
            }

            foreach (var type in GetAllTypesFromNamespace(assembly.GlobalNamespace))
                yield return type;
        }
    }

    private static IEnumerable<INamedTypeSymbol> GetAllTypesFromNamespace(INamespaceSymbol ns)
    {
        foreach (var member in ns.GetMembers())
        {
            if (member is INamespaceSymbol nestedNs)
            {
                foreach (var type in GetAllTypesFromNamespace(nestedNs))
                    yield return type;
            }
            
            else if (member is INamedTypeSymbol type)
            {
                yield return type;

                foreach (var nested in GetNestedTypes(type))
                    yield return nested;
            }
        }
    }

    private static IEnumerable<INamedTypeSymbol> GetNestedTypes(INamedTypeSymbol type)
    {
        foreach (var nested in type.GetTypeMembers())
        {
            yield return nested;
            
            foreach (var deepNested in GetNestedTypes(nested))
                yield return deepNested;
        }
    }
}