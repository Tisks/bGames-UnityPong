using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{

    private string username;

    private PlayerControls controls;

    private PlayerPower power;

    


    //  Constructor


    //  Properties

    public string Username
    {
        get
        {
            return username;
        }

        set
        {
            if (!System.String.IsNullOrEmpty(value))
            {
                username = value;
            }
        }
    }


}
