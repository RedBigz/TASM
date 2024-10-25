using System.Linq;
using System.Text;
using HarmonyLib;
using Landfall.Network;
using TASM.Modules; // This patch CAN use TABG's chat listening system, but I'm lazy.

namespace TASM.Patches;

[HarmonyPatch(typeof(ServerClient), nameof(ServerClient.HandleNetorkEvent), typeof(ServerPackage))]
public static class RPCListener
{
    static void Postfix(ServerClient __instance, ServerPackage networkEvent)
    {
        var opcode = networkEvent.Code;
        var sender = networkEvent.SenderPlayerID;
        var buffer = networkEvent.Buffer;

        switch (opcode)
        {
        }
    }
}