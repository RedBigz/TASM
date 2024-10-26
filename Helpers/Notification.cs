using System;
using System.IO;
using System.Text;
using Landfall.Network;

namespace TASM.Helpers;

public static class Notification
{
    public static void Notify(TABGPlayerServer player, string text)
    {
        var unicodeText = Encoding.Unicode.GetBytes(text);
        var bytes = new byte[24 + unicodeText.Length];

        using (MemoryStream ms = new(bytes))
        using (BinaryWriter bw = new(ms))
        {
            bw.Write(player.PlayerIndex);
            
            bw.Write(player.PlayerPosition.x);
            bw.Write(player.PlayerPosition.y);
            bw.Write(player.PlayerPosition.z);
            bw.Write(player.PlayerRotation.x);
            bw.Write(player.PlayerRotation.y);
            
            bw.Write((byte)unicodeText.Length);
            bw.Write(unicodeText);
        }

        Instances.GameServerClient.SendMessageToClients(EventCode.ThrowChatMessage, bytes, player.PlayerIndex, true);
    }
}