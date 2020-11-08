using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Power_BaseBehaviour : MonoBehaviour, IPower
{

    // ---------------------------------------- [ Variables ]

    // Name of the power.
    private string powerName;

    // To check if the power was activated by the user (always true if the power is always active).
    private bool isActivated;

    // To check if the power is always active. If not, then the power must be activated by the user before using it.
    private bool isAlwaysActive;

    // To check if the power magnitude is always constant. If not constant, then it means that power 
    // magnitude can change in time. (alwaysActive must be true for that)
    private bool isAlwaysConstant;

    // Maximum change of whatever the power is modifying
    private float maxChangeMagnitude;

    // Current use of that maximum magnitude
    private float currentUseOfChangeMagnitude;

    // ---------------------------------------- [ Functions ]

    // Activate/Deactivate power
    public void ActivatePower()
    {
        if (!isAlwaysActive)
            isActivated = !isActivated;
    }

    // Deactivate power
    public void DeactivatePower()
    {
        if (!isAlwaysActive)
            isActivated = false;
    }

    // Check if isActivated variable value is correct. If not, then fix it.
    private void CheckIfActivatedVariableIsCorrect()
    {
        if (IsAlwaysActive && !isActivated)
        {
            Debug.Log("Power <" + powerName + "> is always activated, but isActivated is false. isActivated variable has been changed to true");
            this.isActivated = true;
        }
    }

    // Check if isAwlaysConstant variable value is correct. If not, then fix it.
    private void CheckIfAlwaysConstantIsCorrect()
    {
        if (!isAlwaysActive && !IsAlwaysConstant)
        {
            Debug.Log("Power <" + powerName + "> is activated by user, but isAlwaysConstant is false. isAlwaysConstant variable has been changed to true");
            this.isAlwaysConstant = true;
        }
    }

    // ---------------------------------------- [ Properties ]

    public string PowerName
    {
        get
        {

            if (powerName == null)
            {
                Debug.Log("It seems that this power doesn't have a name");
                return "No name power";
            }

            return powerName;
        }
    }

    public bool IsActivated
    {
        get
        {
            CheckIfActivatedVariableIsCorrect();
            return isActivated;
        }

        set
        {
            this.isActivated = value;
            CheckIfActivatedVariableIsCorrect();
        }
    }

    public bool IsAlwaysActive
    {
        get
        {
            return isAlwaysActive;
        }

        set
        {
            this.isAlwaysActive = value;
        }
    }

    public bool IsAlwaysConstant
    {
        get
        {
            CheckIfAlwaysConstantIsCorrect();
            return isAlwaysConstant;
        }

        set
        {
            isAlwaysConstant = value;
            CheckIfAlwaysConstantIsCorrect();
        }
    }

    public float MaxChangeMagnitude
    {
        get
        {
            return maxChangeMagnitude;
        }

    }

    public float CurrentUseOfChangeMagnitude
    {
        get { return currentUseOfChangeMagnitude; }
        set { this.currentUseOfChangeMagnitude = value; }
    }

    public string PowerDescription
    {
        get
        {
            throw new NotImplementedException();
        }
    }

    // ----------------------------------------  [ Non-implemented functions ]

    public void PerformPower()
    {
        throw new NotImplementedException();
    }

}
