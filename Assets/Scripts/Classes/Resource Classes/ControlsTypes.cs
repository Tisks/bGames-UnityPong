using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public enum ControlsTypes {
    UP,
    DOWN,
    LEFT,
    RIGHT,
    ACTION,
    ENTER
}

public static class ControlsTypesMethods
{
    public static List<ControlsTypes> getControlList()
    {
        return Enum.GetValues(typeof(ControlsTypes)).Cast<ControlsTypes>().ToList();
    }

    public static List<string> getControlNames()
    {
        return Enum.GetNames(typeof(ControlsTypes)).ToList();
    }

    public static ControlsTypes stringToControlsType(String name)
    {
        return (ControlsTypes)System.Enum.Parse(typeof(ControlsTypes), name);
    }

    public static Boolean isAxis1RelatedControl(this ControlsTypes control)
    {
        switch (control)
        {
            case ControlsTypes.UP: return true;
            case ControlsTypes.DOWN: return true;
        }
        return false;
    }

    public static Boolean isAxis2RelatedControl(this ControlsTypes control)
    {
        switch (control)
        {
            case ControlsTypes.UP: return true;
            case ControlsTypes.DOWN: return true;
        }
        return false;
    }

}
