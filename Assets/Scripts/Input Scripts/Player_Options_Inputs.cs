using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class Player_Options_Inputs : MonoBehaviour {

    private PlayerID _target_PlayerID;

    [SerializeField]
    private Dropdown _dropdown_PowerList;

    [SerializeField]
    private Dropdown _dropdown_DataReceivers;


	// Use this for initialization
	void Start () {
        initialize_Dropdown_PowerList();
    }
	
    public void setTargetPlayerID(PlayerID pid)
    {
        _target_PlayerID = pid;
    } 

    private void initialize_Dropdown_PowerList()
    {
        if (_dropdown_PowerList != null)
            _dropdown_PowerList.ClearOptions();
            _dropdown_PowerList.AddOptions(PowerID_Methods.getPowerNamesList());
    }



}

[CustomEditor(typeof(Player_Options_Inputs))]
public class Player_Options_Inputs_Editor : Editor
{

    string[] _playerStringIDs;
    int _selectedPlayerID;

    void OnEnable()
    {
        _playerStringIDs = PlayerID_Methods.getNamesList().ToArray();
        _selectedPlayerID = 0;
    }

    public override void OnInspectorGUI()
    {
        Player_Options_Inputs myTarget = (Player_Options_Inputs)target;

        // Player Dropdown
        int tempSelection = EditorGUILayout.Popup("Target Player", _selectedPlayerID, _playerStringIDs);
        if (_selectedPlayerID != tempSelection)
        {
            _selectedPlayerID = tempSelection;
            myTarget.setTargetPlayerID(PlayerID_Methods.getPlayerID(_playerStringIDs[_selectedPlayerID]));
        }

        // Other Dropdowns
        serializedObject.Update();
        EditorGUILayout.PropertyField(serializedObject.FindProperty("_dropdown_PowerList"), true);
        EditorGUILayout.PropertyField(serializedObject.FindProperty("_dropdown_DataReceivers"), true);
        serializedObject.ApplyModifiedProperties();

    }
}
