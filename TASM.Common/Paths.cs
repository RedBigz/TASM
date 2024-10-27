namespace TASM.Common;

public static class Paths
{
    private static string? _tasmRoot;
    private static string? _tasmPluginsRoot;
    private static string? _tasmDataRoot;

    public static string? TasmRoot
    {
        get => _tasmRoot;
        set => _tasmRoot ??= value;
    }

    public static string? TasmPluginsRoot
    {
        get => _tasmPluginsRoot;
        set => _tasmPluginsRoot ??= value;
    }

    public static string? TasmDataRoot
    {
        get => _tasmDataRoot;
        set => _tasmDataRoot ??= value;
    }
}