using Landfall.Network;
using TASM.Common;
using Helpers = TASM.Common.Helpers;

[assembly: GamePlugin(name: "Example Plugin", version: "1.0.0", author: "RedBigz")]

namespace ExamplePlugin;

[Command(name: "Echo", reference: "echo", permission: CommandPermission.Everyone)]
// ReSharper disable once UnusedType.Global
public static class EchoCommand
{
    [CommandEntry]
    // ReSharper disable once UnusedMember.Global
    public static void Echo(TABGPlayerServer player, string text)
    {
        Helpers.Notification.Notify(player, text);
    }
}