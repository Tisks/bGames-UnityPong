using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Configs_Controller : MonoBehaviour
{
    /**

    private Intro_Controller controller;

    public InputField upKeyField1st, downKeyField1st, leftKeyField1st, rightKeyField1st;
    public InputField upKeyField2nd, downKeyField2nd, leftKeyField2nd, rightKeyField2nd;


    // Use this for initialization
    void Start()
    {
        controller = GetComponent<Intro_Controller>();
        setPlayerConfigurations(PlayerID.FIRST_PLAYER);
        setPlayerConfigurations(PlayerID.SECOND_PLAYER);
    }


    public void buttonSaveAndExitPressed()
    {
        if (controller != null)
        {
            saveConfigurations();
            controller.deactivateConfigurationPanel();
        }
        else
            Debug.Log("Main controller script couldn't be found");
    }

    public void enableConfigurationPanel()
    {
        controller.configurationPanel.SetActive(true);
        controller.mainPanel.SetActive(false);
        setPlayerConfigurations(PlayerID.FIRST_PLAYER);
        setPlayerConfigurations(PlayerID.SECOND_PLAYER);
    }

    public void setPlayerConfigurations(PlayerID pNumber)
    {
        loadPlayerConfigurations(pNumber);
    }

    public void loadPlayerConfigurations(PlayerID pNumber)
    {
        switch (pNumber)
        {
            case PlayerID.FIRST_PLAYER:
                upKeyField1st.text = PlayerPreferencesMethod.getPlayerKeyPreference(pNumber, PlayerPreferences.UP_KEY_PREFERENCE).ToString();
                downKeyField1st.text = PlayerPreferencesMethod.getPlayerKeyPreference(pNumber, PlayerPreferences.DOWN_KEY_PREFERENCE).ToString();
                leftKeyField1st.text = PlayerPreferencesMethod.getPlayerKeyPreference(pNumber, PlayerPreferences.LEFT_KEY_PREFERENCE).ToString();
                rightKeyField1st.text = PlayerPreferencesMethod.getPlayerKeyPreference(pNumber, PlayerPreferences.RIGHT_KEY_PREFERENCE).ToString();
                break;

            case PlayerID.SECOND_PLAYER:
                upKeyField2nd.text = PlayerPreferencesMethod.getPlayerKeyPreference(pNumber, PlayerPreferences.UP_KEY_PREFERENCE).ToString();
                downKeyField2nd.text = PlayerPreferencesMethod.getPlayerKeyPreference(pNumber, PlayerPreferences.DOWN_KEY_PREFERENCE).ToString();
                leftKeyField2nd.text = PlayerPreferencesMethod.getPlayerKeyPreference(pNumber, PlayerPreferences.LEFT_KEY_PREFERENCE).ToString();
                rightKeyField2nd.text = PlayerPreferencesMethod.getPlayerKeyPreference(pNumber, PlayerPreferences.RIGHT_KEY_PREFERENCE).ToString();
                break;
        }
    }

    public void saveConfigurations()
    {
        PlayerPreferencesMethod.setPlayerKeyPreference(PlayerID.FIRST_PLAYER, PlayerPreferences.UP_KEY_PREFERENCE, upKeyField1st.text);
        PlayerPreferencesMethod.setPlayerKeyPreference(PlayerID.FIRST_PLAYER, PlayerPreferences.DOWN_KEY_PREFERENCE, downKeyField1st.text);
        PlayerPreferencesMethod.setPlayerKeyPreference(PlayerID.FIRST_PLAYER, PlayerPreferences.LEFT_KEY_PREFERENCE, leftKeyField1st.text);
        PlayerPreferencesMethod.setPlayerKeyPreference(PlayerID.FIRST_PLAYER, PlayerPreferences.RIGHT_KEY_PREFERENCE, rightKeyField1st.text);
        PlayerPreferencesMethod.setPlayerKeyPreference(PlayerID.SECOND_PLAYER, PlayerPreferences.UP_KEY_PREFERENCE, upKeyField2nd.text);
        PlayerPreferencesMethod.setPlayerKeyPreference(PlayerID.SECOND_PLAYER, PlayerPreferences.DOWN_KEY_PREFERENCE, downKeyField2nd.text);
        PlayerPreferencesMethod.setPlayerKeyPreference(PlayerID.SECOND_PLAYER, PlayerPreferences.LEFT_KEY_PREFERENCE, leftKeyField2nd.text);
        PlayerPreferencesMethod.setPlayerKeyPreference(PlayerID.SECOND_PLAYER, PlayerPreferences.RIGHT_KEY_PREFERENCE, rightKeyField2nd.text);
    }

    **/
}
