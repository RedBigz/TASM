using Landfall.Network;

namespace TASM.Modules;

[Command(Name = "Hello World", Reference = "util::hello")]
public class HelloWorld
{
    [CommandEntry]
    public static void Run(TABGPlayerServer player)
    {
        Helpers.Notification.Notify(player, $"Hello, {player.PlayerName}!");
    }
}