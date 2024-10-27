using System.Reflection;
using BepInEx;
using HarmonyLib;
using TASM.Common.Helpers;
using TASM.Modules;

namespace TASM;

[BepInPlugin(MyPluginInfo.PLUGIN_GUID, MyPluginInfo.PLUGIN_NAME, MyPluginInfo.PLUGIN_VERSION)]
public class Plugin : BaseUnityPlugin
{
    Harmony _harmony;

    private void Awake()
    {
        Logging.Log(Logging.LogLevel.Info, "TASM", "TASM Plugin loaded!");

        _harmony = new("com.redbigz.TASM");
        _harmony.PatchAll();

        Logging.Log(Logging.LogLevel.Info, "TASM", "Patched game.");

        // Get annotations and add them to the command list
        CommandList.Gather(Assembly.GetExecutingAssembly());
        
        // Setup paths
        PathManager.SetupPaths();
    }

    private void OnDestroy()
    {
        _harmony.UnpatchSelf();
        Logging.Log(Logging.LogLevel.Info, "TASM", "Unpatched game.");
    }
}