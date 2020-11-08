using System;
using System.Collections.Generic;

public enum PlayerID
{
    FIRST_PLAYER,
    SECOND_PLAYER,
    NULL
}

public static class PlayerID_Methods
{

    public static List<string> getNamesList()
    {
        List<string> newList = new List<string>();
        foreach (PlayerID pe in Enum.GetValues(typeof(PlayerID)))
            if (pe != PlayerID.NULL)
                newList.Add(pe.getString());
        return newList;
    }

    public static string getString(this PlayerID pn)
    {
        switch (pn)
        {
            case PlayerID.FIRST_PLAYER:
                return "Player 1";
            case PlayerID.SECOND_PLAYER:
                return "Player 2";
            default:
                return null;
        }
    }

    public static bool isFirstPlayer(this PlayerID pn)
    {
        return pn == PlayerID.FIRST_PLAYER;
    }

    public static bool isSecondPlayer(this PlayerID pn)
    {
        return pn == PlayerID.SECOND_PLAYER;
    }

    public static PlayerID getPlayerID(string name)
    {
        if (string.Equals(name, PlayerID.FIRST_PLAYER.getString()))
            return PlayerID.FIRST_PLAYER;
        else if (string.Equals(name, PlayerID.SECOND_PLAYER.getString()))
            return PlayerID.SECOND_PLAYER;
        return PlayerID.NULL;
    }

}
