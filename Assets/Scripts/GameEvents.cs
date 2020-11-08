using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents
{

    public delegate void EventAction();
    public event EventAction leftPlayerHit;
    public event EventAction rightPlayerHit;
    public event EventAction leftPlayerScore;
    public event EventAction rightPlayerScore;

    public void eventLeftPlayerHit()
    {
        if (leftPlayerHit != null)
            leftPlayerHit();
        else
            Debug.Log("Left player hit event doesn't have functions subscribed");
    }

    public void eventRightPlayerHit()
    {
        if (rightPlayerHit != null)
            rightPlayerHit();
        else
            Debug.Log("Right player hit event doesn't have functions subscribed");
    }

    public void eventLeftPlayerScore()
    {
        if (leftPlayerScore != null)
            leftPlayerScore();
        else
            Debug.Log("Left player score event doesn't have functions subscribed");
    }

    public void eventRightPlayerScore()
    {
        if (rightPlayerScore != null)
            rightPlayerScore();
        else
            Debug.Log("Right player score event doesn't have functions subscribed");
    }

}
