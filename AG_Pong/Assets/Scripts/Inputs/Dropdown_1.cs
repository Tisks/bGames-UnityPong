using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dropdown_1 : MonoBehaviour {

    Dropdown m_Dropdown;
    Text m_Text;

    void Awake () {
        m_Dropdown = GetComponentInChildren<Dropdown>();
        m_Text = GetComponentInChildren<Text>();
    }

    public void setLabel(string text)
    {
        m_Text.text = text;
    }

    public void setOptions(List<string> options)
    {
        m_Dropdown.ClearOptions();
        m_Dropdown.AddOptions(options);
    }
}
