using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//  Only two players
public enum PlayerIdentities
{
    FIRST_PLAYER,
    SECOND_PLAYER,
}

public static class PlayerIdentity {


    public static PlayerIdentities[] getIdentities()
    {
         return (PlayerIdentities[])Enum.GetValues(typeof(PlayerIdentities));
    }
}
