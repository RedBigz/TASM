using Landfall.Network;

namespace TASM.Modules;

[Command(Name = "Hello World", Reference = "util::hello")]
public class HelloWorld
{
    [CommandEntry]
    public static void Run(TABGPlayerServer player)
    {
        Logging.Log(Logging.LogLevel.Info, "HelloWorld", $"Hello, {player.PlayerName}!");
    }
}