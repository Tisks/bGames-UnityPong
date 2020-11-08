using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public static class JoystickResources {

    public static string JoystickToString(this KeyCode code)
    {
        if (code.ToString().Contains("Joystick"))
        {
            string pattern = @"Joystick[\d]+";
            string replacement = "";
            Regex rgx = new Regex(pattern);
            string name = rgx.Replace(code.ToString(), replacement);
            return name.Insert(6, " ");
        }
        return null;
    }

    public static KeyCode stringToJoystickKeyCode(string button_name, int joynum)
    {
        string pattern = @"^Button[\d]+$";
        Match match = Regex.Match(button_name, pattern);
        if (match.Success)
        {
            string[] aux = button_name.Split(' ');
            string name = "Joystick" + joynum + aux[0] + aux[1];
            return (KeyCode)System.Enum.Parse(typeof(KeyCode), name);
        }
        return KeyCode.None;
    }

    /// <summary>
    /// To check if any button from any joystick has been pressed.
    /// </summary>
    /// <returns>True if any button from any joystick has been pressed. Otherwise False</returns>
    public static bool anyButton()
    {
        if (Input.anyKey)
        {

            foreach (KeyCode kcode in Enum.GetValues(typeof(KeyCode)))
            {
                for (int joyNum = 1; joyNum <= 16; joyNum++)
                {
                    if (Input.GetKeyDown(kcode) && kcode.ToString().Contains("Joystick" + joyNum))
                    {
                        return true;
                    }
                }

            }
        }
        return false;
    }

    /// <summary>
    /// To check if any button from the joystick with certain joyNum ID has been pressed.
    /// </summary>
    /// <param name="joyNum">Joystick ID number</param>
    /// <returns>True if any button has been pressed from the specified joystick. Otherwise False</returns>
    public static bool anyButton(int joyNum)
    {
        if (Input.anyKey)
        {

            foreach (KeyCode kcode in Enum.GetValues(typeof(KeyCode)))
            {
                if (Input.GetKeyDown(kcode) && kcode.ToString().Contains("Joystick"+joyNum))
                {
                    return true;
                }
            }
        }
        return false;
    }

    /// <summary>
    /// To check if any button from the joystick with certain joyNum ID is being pressed.
    /// </summary>
    /// <param name="joyNum">Joystick ID number</param>
    /// <returns>True if any button is being pressed from the specified joystick. Otherwise False</returns>
    public static bool anyButtonDown(int joyNum)
    {
        if (Input.anyKeyDown)
        {

            foreach (KeyCode kcode in Enum.GetValues(typeof(KeyCode)))
            {
                if (Input.GetKeyDown(kcode) && kcode.ToString().Contains("Joystick" + joyNum))
                {
                    return true;
                }
            }
        }
        return false;
    }

    /// <summary>
    /// To identify the joynum ID of a joystick whose button has been pressed
    /// </summary>
    /// <returns>Joynum from the joystick whose button has been pressed. Returns -1 if error happens</returns>
    public static int identifyJoyNumAnyButton()
    {
        int joyNum = -1;

        if (Input.anyKeyDown)
        {

            foreach (KeyCode kcode in Enum.GetValues(typeof(KeyCode)))
            {
                if (Input.GetKeyDown(kcode) && kcode.ToString().Contains("Joystick"))
                {
                    var input = kcode.ToString();
                    string pattern = @"Button(\d)+";
                    string replacement = "";
                    Regex rgx = new Regex(pattern);
                    input = input.Replace("Joystick", replacement);
                    input = rgx.Replace(input, replacement);
                    Int32.TryParse(input, out joyNum);
                }
            }

        }

        return joyNum;
    }


}
