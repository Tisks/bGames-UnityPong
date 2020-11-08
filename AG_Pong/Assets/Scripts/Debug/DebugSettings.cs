using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DebugSettings : MonoBehaviour {

    List<ControllerTypes> controllerTypeList;
    GameObject controllerDropdownInstance;
    List<GameObject> controlFieldInstances;

    [SerializeField]
    private Text textPrefab;

    [SerializeField]
    private GameObject inputPrefab;

    [SerializeField]
    private GameObject dropdownPrefab;

    [SerializeField]
    private GameObject VerticalLayoutGameObject;




	// Use this for initialization
	void Start () {

        controlFieldInstances = new List<GameObject>();

        controllerTypeList = ControllerTypesMethods.getControllerList();

        controllerDropdownInstance = Instantiate(dropdownPrefab);
        controllerDropdownInstance.transform.SetParent(VerticalLayoutGameObject.transform, false);

        var dComponent = controllerDropdownInstance.GetComponentInChildren<Dropdown>();
        dComponent.onValueChanged.AddListener(delegate { OnControllerChange(dComponent); });

        var d1Component = controllerDropdownInstance.GetComponent<Dropdown_1>();
        d1Component.setLabel("Controller Type");
        d1Component.setOptions(ControllerTypesMethods.getControllerNames());

        foreach (ControlsTypes control in ControlsTypesMethods.getControlList())
        {
            var iInstance = Instantiate(inputPrefab);
            var dSelected = controllerTypeList[dComponent.value];

            iInstance.transform.SetParent(VerticalLayoutGameObject.transform, false);
            iInstance.GetComponent<Input_1>().setLabel(control.ToString());
            iInstance.GetComponent<Input_1>().setInputText(dSelected.getInputDefault(control));
            controlFieldInstances.Add(iInstance);
        }
        

        // REBUILD
        LayoutRebuilder.ForceRebuildLayoutImmediate((RectTransform)VerticalLayoutGameObject.transform);

    }

    public void OnControllerChange(Dropdown instance)
    {

        var dSelected = controllerTypeList[instance.value];

        foreach (GameObject input in controlFieldInstances)
        {
            ControlsTypes ctype = ControlsTypesMethods.stringToControlsType(input.GetComponentInChildren<Text>().text);
            input.GetComponent<Input_1>().setInputText(dSelected.getInputDefault(ctype));
        }

    }

   

    // Update is called once per frame
    void Update () {
		
	}
}
