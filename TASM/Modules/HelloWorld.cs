using Landfall.Network;
using TASM.Common;
using Helpers = TASM.Common.Helpers;

namespace TASM.Modules;

[Command(name: "Hello World", reference: "hello", permission: CommandPermission.Everyone)]
public class HelloWorld
{
    [CommandEntry]
    public static void Run(TABGPlayerServer player)
    {
        Helpers.Notification.Notify(player, $"Hello, {player.PlayerName}!");
    }
}