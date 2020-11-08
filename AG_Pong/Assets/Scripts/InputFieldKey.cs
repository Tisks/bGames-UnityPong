using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputFieldKey : InputField {

	// Update is called once per frame
	void Update () {


        if (this.isFocused)
        {
            disableCaret();
            updatePressedKey();
        }
    }

    private void updatePressedKey()
    {

        if (Input.anyKey)
        {
            if (Input.GetKeyDown(KeyCode.Backspace))
                this.text = "";
            else if (!Input.GetKeyDown(KeyCode.Backspace))
                this.text = detectKeyDown();
        }
    }

    private string detectKeyDown()
    {
        foreach (KeyCode vKey in System.Enum.GetValues(typeof(KeyCode)))
        {
            if (Input.GetKeyDown(vKey))
                return vKey.ToString();
        }
        return this.text;
    }

    private void disableCaret()
    {
        if (!string.IsNullOrEmpty(this.text))
        {
            this.caretWidth = 0;
        }
        else
        {
            this.caretWidth = 1;
        }
    }
}
