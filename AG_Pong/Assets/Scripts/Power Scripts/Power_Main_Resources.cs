using System;
using System.Collections.Generic;

public enum PowerID
{
    P_MIGHTY_BLOW,
    POWER_GROW_PLAYER,
    NULL
}

public static class PowerID_Methods
{

    public static List<string> getPowerNamesList()
    {
        List<string> newList = new List<string>();
        foreach (PowerID pe in Enum.GetValues(typeof(PowerID)))
            if (pe != PowerID.NULL)
                newList.Add(pe.getPowerName());
        return newList;
    }

    public static List<PowerID> getPowerIDList()
    {
        List<PowerID> newList = new List<PowerID>();
        foreach (PowerID pe in Enum.GetValues(typeof(PowerID)))
            if (pe != PowerID.NULL)
                newList.Add(pe);
        return newList;
    }

    public static string getPowerName(this PowerID pe)
    {
        switch (pe)
        {
            case (PowerID.P_MIGHTY_BLOW):
                return P_Mighty_Blow.powerName;
            case (PowerID.POWER_GROW_PLAYER):
                return "Grow Player";
            default: return null;
        }
    }

    public static PowerID getEnumByName(string name)
    {
        if (string.Equals(name, PowerID.P_MIGHTY_BLOW.getPowerName()))
            return PowerID.P_MIGHTY_BLOW;
        else if (string.Equals(name, PowerID.POWER_GROW_PLAYER.getPowerName()))
            return PowerID.POWER_GROW_PLAYER;
        else
            return PowerID.NULL;
    }

    public static IPower initPower(this PowerID pe)
    {
        switch (pe)
        {
            case (PowerID.P_MIGHTY_BLOW): return new P_Mighty_Blow();
            case (PowerID.POWER_GROW_PLAYER): return new Power_GrowPlayer();
            default: return null;
        }
    }

    public static IPower initPower(string power_name)
    {
        return getEnumByName(power_name).initPower();
    }

}
