using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls {

    private KeyCode up;

    private KeyCode down;

    private KeyCode left;

    private KeyCode right;

    private KeyCode action;

    // Constructor
    public PlayerControls(KeyCode up, KeyCode down, KeyCode left, KeyCode right, KeyCode action)
    {
        this.Up = up;
        this.Down = down;
        this.Left = left;
        this.Right = right;
        this.Action = action;
    }

    // Properties

    public KeyCode Up
    {
        get
        {
            return up;
        }

        set
        {
            up = value;
        }
    }

    public KeyCode Down
    {
        get
        {
            return down;
        }

        set
        {
            down = value;
        }
    }

    public KeyCode Left
    {
        get
        {
            return left;
        }

        set
        {
            left = value;
        }
    }

    public KeyCode Right
    {
        get
        {
            return right;
        }

        set
        {
            right = value;
        }
    }

    public KeyCode Action
    {
        get
        {
            return action;
        }

        set
        {
            action = value;
        }
    }





}
