using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerBase : MonoBehaviour, IPower {

    public static string powerName = null;
    public static string powerDescription = null;

    public string PowerName
    {
        get
        {
            if (powerName == null)
                throw new NotImplementedException();
            else
                return powerName;
        }
    }

    public string PowerDescription
    {
        get
        {
            if (powerDescription == null)
                throw new NotImplementedException();
            else
                return powerDescription;
        }
    }

    
}
