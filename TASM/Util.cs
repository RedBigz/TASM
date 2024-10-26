using Landfall.Network;

namespace TASM;

public static class Util
{
    public static TABGPlayerServer PlayerFromId(byte playerId, ServerClient serverClient)
    {
        try
        {
            return serverClient.GameRoomReference.Players[playerId];
        }
        catch
        {
            return serverClient.GameRoomReference.Players[0];
        }
    }
}