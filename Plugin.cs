using BepInEx;

namespace TASM;

[BepInPlugin(MyPluginInfo.PLUGIN_GUID, MyPluginInfo.PLUGIN_NAME, MyPluginInfo.PLUGIN_VERSION)]
public class Plugin : BaseUnityPlugin
{
    private void Awake()
    {
        Logging.Log(Logging.LogLevel.Info, "TASM", "TASM Plugin loaded!");
    }
}
