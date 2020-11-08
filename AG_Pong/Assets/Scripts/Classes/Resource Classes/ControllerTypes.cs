using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;
using UnityEngine;

public enum ControllerTypes
{
    KEYBOARD,
    MOUSE,
    JOYSTICK,
    KEYBOARD_MOUSE
}

public static class ControllerTypesMethods
{
    // This function is used to define the default keys for every game control defined on ControllerTypes.
    // (Mouse and Joystick in this case doesn't need the UP, DOWN, LEFT or RIGHT since those kind of movements are related to Axis input and not buttons)
    public static string getInputDefault(this ControllerTypes controller, ControlsTypes control)
    {
        string defaultInput = "NONE";

        switch (controller)
        {
            case ControllerTypes.MOUSE:
                switch (control)
                {
                    case ControlsTypes.UP: defaultInput = "Mouse Y Movement"; break;
                    case ControlsTypes.DOWN: defaultInput = "Mouse Y Movement"; break;
                    case ControlsTypes.LEFT: defaultInput = "Mouse X Movement"; break;
                    case ControlsTypes.RIGHT: defaultInput = "Mouse X Movement"; break;
                    case ControlsTypes.ACTION: defaultInput = KeyCode.Mouse0.ToString(); break;
                }
                break;

            case ControllerTypes.KEYBOARD:
                switch (control)
                {
                    case ControlsTypes.UP: defaultInput = KeyCode.W.ToString(); break;
                    case ControlsTypes.DOWN: defaultInput = KeyCode.S.ToString(); break;
                    case ControlsTypes.LEFT: defaultInput = KeyCode.A.ToString(); break;
                    case ControlsTypes.RIGHT: defaultInput = KeyCode.D.ToString(); break;
                    case ControlsTypes.ACTION: defaultInput = KeyCode.Space.ToString(); break;
                }
                break;

            case ControllerTypes.JOYSTICK:
                switch (control)
                {
                    case ControlsTypes.UP: defaultInput = "Joystick Y Axis"; break;
                    case ControlsTypes.DOWN: defaultInput = "Joystick Y Axis"; break;
                    case ControlsTypes.LEFT: defaultInput = "Joystick X Axis"; break;
                    case ControlsTypes.RIGHT: defaultInput = "Joystick X Axis"; break;
                    case ControlsTypes.ACTION: defaultInput = KeyCode.JoystickButton0.ToString(); break;
                }
                break;

            case ControllerTypes.KEYBOARD_MOUSE:
                switch (control)
                {
                    case ControlsTypes.UP: defaultInput = KeyCode.W.ToString(); break;
                    case ControlsTypes.DOWN: defaultInput = KeyCode.S.ToString(); break;
                    case ControlsTypes.LEFT: defaultInput = KeyCode.A.ToString(); break;
                    case ControlsTypes.RIGHT: defaultInput = KeyCode.D.ToString(); break;
                    case ControlsTypes.ACTION: defaultInput = KeyCode.Mouse0.ToString(); break;
                }
                break;
        }

        return defaultInput;

    }

    // This function is used for defining what inputs are a
    public static bool isInputAccepted(this ControllerTypes controller, ControlsTypes control, KeyCode code)
    {

        switch (controller)
        {
            case ControllerTypes.KEYBOARD:
                if (!code.ToString().Contains("Joystick") && !code.ToString().Contains("Mouse"))
                    return true;
                else
                    return false;

            case ControllerTypes.JOYSTICK:
                if (code.ToString().Contains("Joystick"))
                    return true;
                else
                    return false;

            case ControllerTypes.MOUSE:
                if (code.ToString().Contains("Mouse"))
                    return true;
                else
                    return false;
        }

        return false;
    }

    public static List<ControllerTypes> getControllerList()
    {
        return Enum.GetValues(typeof(ControllerTypes)).Cast<ControllerTypes>().ToList();
    }

    public static List<string> getControllerNames()
    {
        return Enum.GetNames(typeof(ControllerTypes)).ToList();
    }

    public static ControllerTypes stringToControllerType(String name)
    {
        return (ControllerTypes)System.Enum.Parse(typeof(ControllerTypes), name);
    }




}

