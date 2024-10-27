using System.IO;
using TASM.Common;
using UnityEngine;

namespace TASM;

public static class PathManager
{
    /// <summary>
    /// Sets paths for <see cref="TASM.Common.Paths"/> and create them if they don't exist.
    /// </summary>
    public static void SetupPaths()
    {
        Paths.TasmRoot = Path.GetFullPath(Path.Combine(Application.dataPath, @"..\TASM"));
        Paths.TasmPluginsRoot = Path.Combine(Paths.TasmRoot, "Plugins");
        Paths.TasmDataRoot = Path.Combine(Paths.TasmRoot, "Data");

        if (!Directory.Exists(Paths.TasmRoot)) Directory.CreateDirectory(Paths.TasmRoot);
        if (!Directory.Exists(Paths.TasmPluginsRoot)) Directory.CreateDirectory(Paths.TasmPluginsRoot);
        if (!Directory.Exists(Paths.TasmDataRoot)) Directory.CreateDirectory(Paths.TasmDataRoot);
    }
}