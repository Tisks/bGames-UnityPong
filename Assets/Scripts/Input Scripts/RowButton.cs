using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


[System.Serializable]
public class ConfigurationButton
{
    public Button button;
    public GameObject panel;
}

public class RowButton : MonoBehaviour {

    public ConfigurationButton[] ConfigList;
     
    public Button pressedButton;
    private GameObject currentlyShowingPanel;
    public GameObject targetGameObjectPosition;

    // Use this for initialization
    void Start() {
        pressedButton.interactable = false;
        currentlyShowingPanel = searchPannelFromButton(pressedButton);
        currentlyShowingPanel.transform.position = targetGameObjectPosition.transform.position;
    }

    public void buttonPressed()
    {
        var go = EventSystem.current.currentSelectedGameObject;
        if (go != null)
        {
            var panel = searchPannelFromButton(go.GetComponent<Button>());
            if (panel != null)
            {
                pressedButton.interactable = true;
                pressedButton = go.GetComponent<Button>();
                pressedButton.interactable = false;

                currentlyShowingPanel.transform.position = panel.transform.position;
                panel.transform.position = targetGameObjectPosition.transform.position;
                currentlyShowingPanel = panel;
            }
        }
            
    }

    GameObject searchPannelFromButton(Button btn)
    {
        foreach (ConfigurationButton cb in ConfigList)
            if (cb.button == btn)
                return cb.panel;
        return null;
    }
	

}

[CustomEditor(typeof(RowButton))]
public class RowButtonEditor : Editor
{
    private int previousSize;

    void OnEnable()
    {
        RowButton myTarget = (RowButton)target;

        previousSize = 0;
    }

    public override void OnInspectorGUI()
    {
        RowButton myTarget = (RowButton)target;

        myTarget.pressedButton = (Button)EditorGUILayout.ObjectField("Initial pressed button", myTarget.pressedButton, typeof(Button));
        myTarget.targetGameObjectPosition = (GameObject) EditorGUILayout.ObjectField("Target panel", myTarget.targetGameObjectPosition, typeof(GameObject));
        
        serializedObject.Update();
        EditorGUILayout.PropertyField(serializedObject.FindProperty("ConfigList"), true);
        serializedObject.ApplyModifiedProperties();


    }
}