using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;

public class DebugControls : MonoBehaviour {


    private Text dGUIText;

    private int p1Joynum = -1;

    private int p2Joynum = -1;

    [SerializeField]
    private GameObject eventPrefab;

    [SerializeField]
    private Canvas canvasPrefab;

    [SerializeField]
    private Button p1JoyButton;

    [SerializeField]
    private Button p2JoyButton;

    [SerializeField]
    private Text MainInfo;

    [SerializeField]
    private Text p1JoyInfo;

    [SerializeField]
    private Text p2JoyInfo;


	// Use this for initialization
	void Start () {

        if (GameObject.Find("EventSystem") == null)
        {
            Debug.Log("EventSystem couldn't be found. Instantiating a new one...");
            Instantiate(eventPrefab);
        }

        Canvas canvas = (Canvas)Instantiate(canvasPrefab);
        dGUIText = canvas.GetComponentInChildren<Text>();

    }
	

	// Update is called once per frame
	void Update () {
        updateInputInfo();
        updateP1Info();
        updateP2Info();
    }

    // Called by button
    public void setP1Controller()
    {
        IEnumerator coroutine = waitForInput(1);
        StartCoroutine(coroutine);
    }

    // Called by button
    public void setP2Controller()
    {
        IEnumerator coroutine = waitForInput(2);
        StartCoroutine(coroutine);
    }

    // CoRoutine that expects a joystick input to be pressed
    IEnumerator waitForInput(int playerNum)
    {
        // Disable while waiting
        p1JoyButton.interactable = false;
        p2JoyButton.interactable = false;
        MainInfo.text = "PRESS A BUTTON TO SET PLAYER" + playerNum + " CONTROLLER";

        // Wait for input
        int joyNumPressed = JoystickResources.identifyJoyNumAnyButton();
        while (joyNumPressed == -1)
        {
            joyNumPressed = JoystickResources.identifyJoyNumAnyButton();
            yield return null;
        }

        // Enable 
        p1JoyButton.interactable = true;
        p2JoyButton.interactable = true;
        MainInfo.text = "CONTROLLER DEBUG";


        if (playerNum == 1)
            this.p1Joynum = joyNumPressed;
        else if (playerNum == 2)
            this.p2Joynum = joyNumPressed;
        else
            Debug.Log("Wrong player number used at waitForInput coroutine");
    }

    void updateP1Info()
    {
        string text = "Joystick Num: ";
        if (p1Joynum == -1)
            text += "NONE";
        else
            text += p1Joynum + "\nKey is being pressed: " + JoystickResources.anyButtonDown(p1Joynum);
        p1JoyInfo.text = text;
    }

    public void updateP2Info()
    {
        string text = "Joystick Num: ";
        if (p2Joynum == -1)
            text += "NONE";
        else
            text += p2Joynum + "\nKey is being pressed: " + JoystickResources.anyButtonDown(p2Joynum);
        p2JoyInfo.text = text;
    }

    void updateInputInfo()
    {
        dGUIText.text = generatePlayerInfo(1) + "\n" + generatePlayerInfo(2);
    }

    string generatePlayerInfo(int playerNum)
    {
        string text = "Player " + playerNum + "\n";

        int pJoynum = -1;
        switch(playerNum){
            case 1:
                pJoynum = p1Joynum;
                break;
            case 2:
                pJoynum = p2Joynum;
                break;
        }

        if (pJoynum > 0)
        {
            text += "Joynum: " + pJoynum + "\n";
            text += "Horizontal: " + Input.GetAxis("Joystick"+pJoynum+"Horizontal") + "\n";
            text += "Vertical: " + Input.GetAxis("Joystick"+pJoynum +"Vertical") + "\n";
            string kname_base = "Joystick" + pJoynum + "Button";
            for (int index = 0; index <= 19; index++)
            {
                string kname = kname_base + index;
                KeyCode kcode = (KeyCode)System.Enum.Parse(typeof(KeyCode), kname);
                text += kcode.JoystickToString() + ": " + Input.GetKey(kcode) + "\n";
            }
        }

        else
        {
            text += "Joynum: NONE\n";
        }

        return text;
    }





   


  
}

