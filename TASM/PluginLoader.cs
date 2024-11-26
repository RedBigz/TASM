using System.IO;
using System.Linq;
using System.Reflection;
using TASM.Common;
using TASM.Common.Helpers;
using TASM.Modules;

namespace TASM;

public class PluginLoader
{
    static void LoadPluginFromAssembly(string assemblyPath)
    {
        var assembly = Assembly.LoadFrom(assemblyPath);

        var friendlyName = assembly.GetName().Name;

        Logging.Log(Logging.LogLevel.Info, "PluginLoader", $"Loaded Assembly: {friendlyName}");

        var attribute = assembly.GetCustomAttribute<GamePluginAttribute>();

        if (attribute is null)
        {
            Logging.Log(Logging.LogLevel.Info, "PluginLoader",
                $"Found no GamePlugin metadata in {friendlyName}, skipping.");
            return;
        }

        Logging.Log(Logging.LogLevel.Info, "PluginLoader",
            $"Loading Plugin: {attribute.Name} ({attribute.Version}) by {attribute.Author}");

        // Gather commands
        CommandList.Gather(assembly);

        // Run all PluginMains
        var mains = from type in assembly.GetTypes()
            from method in type.GetMethods()
            where method.IsDefined(typeof(PluginMainAttribute))
            select method;

        foreach (var method in mains) method.Invoke(null, null);
    }

    public static void LoadAllPlugins()
    {
        Logging.Log(Logging.LogLevel.Info, "PluginLoader", "Loading All Plugins...");

        // recurse files to look for DLLs
        foreach (var assemblyFile in Directory.EnumerateFiles(Paths.TasmPluginsRoot!, "*.dll",
                     SearchOption.AllDirectories))
        {
            Logging.Log(Logging.LogLevel.Info, "PluginLoader", $"Loading Plugin: {assemblyFile}");
            LoadPluginFromAssembly(assemblyFile);
        }
    }
}