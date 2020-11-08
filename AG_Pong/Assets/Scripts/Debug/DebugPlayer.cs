using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugPlayer : MonoBehaviour {

    Player player;

	// Use this for initialization
	void Start () {
 
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.anyKeyDown)
        {
            // print(Input.inputString);
            print(Input.GetAxis("Horizontal"));
        }
    }

    private void updateInputInfo ()
    {
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");

        string text = "Horizontal Axis: " + horizontal + "\n"
            + "Vertical Axis: " + vertical + "\n";

    }
    

    private void createDebugPlayerInfo()
    {

    }

    private void createDebugPlayer()
    {

    }
}
