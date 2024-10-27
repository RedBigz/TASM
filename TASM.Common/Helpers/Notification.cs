using System;
using System.IO;
using System.Text;
using Landfall.Network;

namespace TASM.Common.Helpers;

/// <summary>
/// This class holds the <see cref="Notification.Notify"/> function.
/// </summary>
public static class Notification
{
    /// <summary>
    /// Summons a client-side talking rock with a message.
    /// </summary>
    /// <param name="player">The player to receive the message.</param>
    /// <param name="text">The text to be shown from the talking rock.</param>
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

        Instances.GameServerClient?.SendMessageToClients(EventCode.ThrowChatMessage, bytes, player.PlayerIndex, true);
    }
}