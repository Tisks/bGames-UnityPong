using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GeneralResources
{
    public static KeyCode convertStringToKeyCode(string kString)
    {
        return (KeyCode)System.Enum.Parse(typeof(KeyCode), kString);
    }
}
