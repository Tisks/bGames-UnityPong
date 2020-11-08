using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Input_1 : MonoBehaviour {

    [SerializeField]
    private Text m_Label;

    [SerializeField]
    private InputField m_InputField;

    void Awake()
    {
        m_InputField = GetComponentInChildren<InputField>();
        m_InputField.text = "NONE";
        m_Label = GetComponentInChildren<Text>();
        m_Label.text = "LABEL";
    }

    void Update()
    {
        //Check if the Input Field is in focus and able to alter
        if (m_InputField.isFocused)
        {
            if (Input.anyKeyDown)
            {

                foreach (KeyCode kcode in Enum.GetValues(typeof(KeyCode)))
                {
                    if (Input.GetKeyDown(kcode)) m_InputField.text = kcode.ToString();
                }

            }
        }
    }

    public void setLabel(string text)
    {
        m_Label.text = text;
    }

    public void setInputText(string text)
    {
        m_InputField.text = text;
    }



}
