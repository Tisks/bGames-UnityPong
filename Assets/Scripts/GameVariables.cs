using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameVariables
{

    private GameObject leftPlayer;
    private GameObject rightPlayer;
    private GameObject ball;

    [SerializeField]
    private GameObject playerField;

    [SerializeField]
    private int leftPlayerScore;

    [SerializeField]
    private int rightPlayerScore;

    [SerializeField]
    private KeyCode leftPlayer_LeftKey;

    [SerializeField]
    private KeyCode leftPlayer_RightKey;

    [SerializeField]
    private KeyCode leftPlayer_UpKey;

    [SerializeField]
    private KeyCode leftPlayer_DownKey;

    [SerializeField]
    private KeyCode rightPlayer_LeftKey;

    [SerializeField]
    private KeyCode rightPlayer_RightKey;

    [SerializeField]
    private KeyCode rightPlayer_UpKey;

    [SerializeField]
    private KeyCode rightPlayer_DownKey;

    [SerializeField]
    private KeyCode pauseKey;

    [SerializeField]
    private KeyCode restartKey;

    [SerializeField]
    private Color leftPlayer_Color;

    [SerializeField]
    private Color rightPlayer_Color;

    [SerializeField]
    private List<IPower> leftPlayer_Powers;

    [SerializeField]
    private List<IPower> rightPlayer_Power;

    public GameObject LeftPlayer
    {
        get
        {
            return leftPlayer;
        }

        set
        {
            leftPlayer = value;
        }
    }

    public GameObject RightPlayer
    {
        get
        {
            return rightPlayer;
        }

        set
        {
            rightPlayer = value;
        }
    }

    public GameObject Ball
    {
        get
        {
            return ball;
        }

        set
        {
            ball = value;
        }
    }

    public GameObject PlayerField
    {
        get
        {
            return playerField;
        }

        set
        {
            playerField = value;
        }
    }

    public int LeftPlayerScore
    {
        get
        {
            return leftPlayerScore;
        }

        set
        {
            leftPlayerScore = value;
        }
    }

    public int RightPlayerScore
    {
        get
        {
            return rightPlayerScore;
        }

        set
        {
            rightPlayerScore = value;
        }
    }

    public KeyCode LeftPlayer_LeftKey
    {
        get
        {
            return leftPlayer_LeftKey;
        }

        set
        {
            leftPlayer_LeftKey = value;
        }
    }

    public KeyCode LeftPlayer_RightKey
    {
        get
        {
            return leftPlayer_RightKey;
        }

        set
        {
            leftPlayer_RightKey = value;
        }
    }

    public KeyCode LeftPlayer_UpKey
    {
        get
        {
            return leftPlayer_UpKey;
        }

        set
        {
            leftPlayer_UpKey = value;
        }
    }

    public KeyCode LeftPlayer_DownKey
    {
        get
        {
            return leftPlayer_DownKey;
        }

        set
        {
            leftPlayer_DownKey = value;
        }
    }

    public KeyCode RightPlayer_LeftKey
    {
        get
        {
            return rightPlayer_LeftKey;
        }

        set
        {
            rightPlayer_LeftKey = value;
        }
    }

    public KeyCode RightPlayer_RightKey
    {
        get
        {
            return rightPlayer_RightKey;
        }

        set
        {
            rightPlayer_RightKey = value;
        }
    }

    public KeyCode RightPlayer_UpKey
    {
        get
        {
            return rightPlayer_UpKey;
        }

        set
        {
            rightPlayer_UpKey = value;
        }
    }

    public KeyCode RightPlayer_DownKey
    {
        get
        {
            return rightPlayer_DownKey;
        }

        set
        {
            rightPlayer_DownKey = value;
        }
    }

    public KeyCode PauseKey
    {
        get
        {
            return pauseKey;
        }

        set
        {
            pauseKey = value;
        }
    }

    public KeyCode RestartKey
    {
        get
        {
            return restartKey;
        }

        set
        {
            restartKey = value;
        }
    }

    public Color LeftPlayer_Color
    {
        get
        {
            return leftPlayer_Color;
        }

        set
        {
            leftPlayer_Color = value;
        }
    }

    public Color RightPlayer_Color
    {
        get
        {
            return rightPlayer_Color;
        }

        set
        {
            rightPlayer_Color = value;
        }
    }

    // Get lefftwall gameobject
    public GameObject getLeftWallObject()
    {
        return this.PlayerField.transform.Find("leftwall").gameObject;
    }

    // Get rightwall gameobject
    public GameObject getRightWallObject()
    {
        return this.PlayerField.transform.Find("rightwall").gameObject;
    }



}


