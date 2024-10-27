namespace TASM.Common;

/// <summary>
/// This class holds the paths of all TASM-related folders.
/// </summary>
public static class Paths
{
    private static string? _tasmRoot;
    private static string? _tasmPluginsRoot;
    private static string? _tasmDataRoot;

    // ./TASM
    public static string? TasmRoot
    {
        get => _tasmRoot;
        set => _tasmRoot ??= value;
    }

    // ./TASM/Plugins
    public static string? TasmPluginsRoot
    {
        get => _tasmPluginsRoot;
        set => _tasmPluginsRoot ??= value;
    }

    // ./TASM/Data
    public static string? TasmDataRoot
    {
        get => _tasmDataRoot;
        set => _tasmDataRoot ??= value;
    }
}