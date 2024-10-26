using System.Linq;
using System.Text;
using HarmonyLib;
using Landfall.Network;
using TASM.Common.Helpers;
using TASM.Modules; // This patch CAN use TABG's chat listening system, but I'm lazy.

namespace TASM.Patches;

[HarmonyPatch(typeof(ServerClient), nameof(ServerClient.HandleNetorkEvent), typeof(ServerPackage))]
public static class RPCListener
{
    static void Postfix(ServerClient __instance, ServerPackage networkEvent)
    {
        Instances.GameServerClient = __instance; // nab serverclient for instances class
        
        var opcode = networkEvent.Code;
        var sender = networkEvent.SenderPlayerID;
        var buffer = networkEvent.Buffer;

        switch (opcode)
        {
            case EventCode.ChatMessage:
                byte supposedSender = buffer[0];
                string text = Encoding.ASCII.GetString(buffer[2..^1].Where(c => c != 0).ToArray());

                var player = Util.PlayerFromId(sender, __instance);

                Logging.Log(Logging.LogLevel.Info, "Chat", $"{player.PlayerName}: {text}");

                if (text.StartsWith("/"))
                {
                    string[] args = text[1..].Split(" ");

                    if (args.Length == 0) break;
                    
                    CommandList.Invoke(args[0], args[1..], player);
                }
                
                break;
        }
    }
}