using Landfall.Network;

namespace TASM.Common.Helpers;

/// <summary>
/// This class holds current game instance data in a static form, letting any function use it.
/// </summary>
public static class Instances
{
    /// <summary>
    /// The ServerClient being used by the game.
    /// </summary>
    public static ServerClient? GameServerClient;
}