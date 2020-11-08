
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.Networking;

public class game_controller: MonoBehaviour 
{
    // Prefabs.
    public GameObject playerPrefab;    
    public GameObject ballPrefab;

    // Singleton Controllers
    [SerializeField]
    public GameVariables game_variables = new GameVariables();
    public GameEvents game_event_manager = new GameEvents();

    // s_Instance is used to cache the instance found in the scene so we don't have to look it up every time.
    private static game_controller s_Instance = null;

    // This defines a static instance property that attempts to find the manager object in the scene and
    // returns it to game_controller caller.
    public static game_controller instance
    {
        get
        {
        
            if (s_Instance == null)
                s_Instance = FindObjectOfType(typeof(game_controller)) as game_controller;

            if (s_Instance == null)
            {
                GameObject obj = new GameObject("Game Controller");
                s_Instance = obj.AddComponent(typeof(game_controller)) as game_controller;
                Debug.Log("Could not locate an game_controller object. game_controller was Generated Automaticly.");
            }

            return s_Instance;
        }
    }

    // Ensure that the instance is destroyed when the game is stopped in the editor.
    void OnApplicationQuit()
    {
        s_Instance = null;
    }

    IEnumerator GetRequest(string uri)
    {
        UnityWebRequest request = UnityWebRequest.Get(uri);
        yield return request.Send();

        // Show results as text        
        Debug.Log(request.downloadHandler.data);
        Debug.Log(request.downloadHandler.text);
    }


    // Use this for initialization
    void Awake()
    {
        /**
        Debug.Log("entra");

        StartCoroutine(GetRequest("http://localhost:8080/twitter_component/user_nonauth/sentiment_summary?username=sebastianpinera&rangeOfDays=10"));
        Debug.Log("sale");
        return;
    **/
        initializePlayerScore();
        player_resources.initializeLeftPlayer();
        player_resources.initializeRightPlayer();
        ball_resources.initializeBall();
        game_event_manager.leftPlayerScore += leftPlayerScored;
        game_event_manager.rightPlayerScore += rightPlayerScored;


		Debug.Log("Hey...");



    }

    // Reload game
    void reloadScene()
    {
        initializePlayerScore();
        player_resources.initializeLeftPlayer();
        player_resources.initializeRightPlayer();
        ball_resources.initializeBall();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(game_variables.RestartKey))
            reloadScene();
        else if (Input.GetKeyDown(game_variables.PauseKey))
            pauseScene();
    }

    // Pause game
    void pauseScene()
    {
        if (Time.timeScale == 0)
            Time.timeScale = 1;
        else
            Time.timeScale = 0;
    }

    // Initialize player score
    public void initializePlayerScore()
    {
        game_variables.LeftPlayerScore = 0;
        game_variables.RightPlayerScore = 0;
    }

    // Call after right player has made an score
    public void rightPlayerScored()
    {
        game_variables.RightPlayerScore += 1;
        Debug.Log("Right Player Score: " + game_variables.RightPlayerScore);
    }

    // Call after left player has made an score
    public void leftPlayerScored()
    {
        game_variables.LeftPlayerScore += 1;
        Debug.Log("Left Player Score: " + game_variables.LeftPlayerScore);

    }

}


[CustomEditor(typeof(game_controller))]
public class LevelScriptEditor : Editor
{

    public bool showPrefab = true;
    public bool showLeftPlayer = true;
    public bool showRightPlayer = true;
    public bool showInGameVars = true;



    public override void OnInspectorGUI()
    {
        game_controller myTarget = (game_controller) target;

        // Prefabs objects
        showPrefab  = EditorGUILayout.Foldout(showPrefab, "Prefabs objects");
        if (showPrefab)
        {
            EditorGUI.indentLevel = 2;

            // Player Prefab
            GameObject pObj = (GameObject)EditorGUILayout.ObjectField("Player Prefab", myTarget.playerPrefab, typeof(Object), true);
            if (pObj != null && PrefabUtility.GetPrefabType(pObj) == PrefabType.Prefab)
                myTarget.playerPrefab = pObj;
            else
                myTarget.playerPrefab = null;

            // Ball Prefab
            GameObject bObj = (GameObject)EditorGUILayout.ObjectField("Ball Prefab", myTarget.ballPrefab, typeof(Object), true);
            if (bObj != null && PrefabUtility.GetPrefabType(bObj) == PrefabType.Prefab)
                myTarget.ballPrefab = bObj;
            else
                myTarget.ballPrefab = null;

            // Player Field
            myTarget.game_variables.PlayerField = (GameObject)EditorGUILayout.ObjectField("Player Field", myTarget.game_variables.PlayerField, typeof(Object), true);

        }

        // Left Player variables
        EditorGUI.indentLevel = 0;
        showLeftPlayer = EditorGUILayout.Foldout(showLeftPlayer, "Left player configurations");
        if (showLeftPlayer)
        {
            EditorGUI.indentLevel = 2;

            // Color
            myTarget.game_variables.LeftPlayer_Color = EditorGUILayout.ColorField("Player Color", myTarget.game_variables.LeftPlayer_Color);

            // Keys
            myTarget.game_variables.LeftPlayer_UpKey = (KeyCode)EditorGUILayout.EnumPopup("Up Key", myTarget.game_variables.LeftPlayer_UpKey);
            myTarget.game_variables.LeftPlayer_DownKey = (KeyCode)EditorGUILayout.EnumPopup("Down Key", myTarget.game_variables.LeftPlayer_DownKey);
            myTarget.game_variables.LeftPlayer_LeftKey = (KeyCode)EditorGUILayout.EnumPopup("Left Key", myTarget.game_variables.LeftPlayer_LeftKey);
            myTarget.game_variables.LeftPlayer_RightKey = (KeyCode)EditorGUILayout.EnumPopup("Right Key", myTarget.game_variables.LeftPlayer_RightKey);

            //Powers
        }

        EditorGUI.indentLevel = 0;
        showRightPlayer = EditorGUILayout.Foldout(showRightPlayer, "Right player configurations");
        if (showRightPlayer)
        {
            EditorGUI.indentLevel = 2;

            // Color
            myTarget.game_variables.RightPlayer_Color = EditorGUILayout.ColorField("Player Color", myTarget.game_variables.RightPlayer_Color);

            // Keys
            myTarget.game_variables.RightPlayer_UpKey = (KeyCode)EditorGUILayout.EnumPopup("Up Key", myTarget.game_variables.RightPlayer_UpKey);
            myTarget.game_variables.RightPlayer_DownKey = (KeyCode)EditorGUILayout.EnumPopup("Down Key", myTarget.game_variables.RightPlayer_DownKey);
            myTarget.game_variables.RightPlayer_LeftKey = (KeyCode)EditorGUILayout.EnumPopup("Left Key", myTarget.game_variables.RightPlayer_LeftKey);
            myTarget.game_variables.RightPlayer_RightKey = (KeyCode)EditorGUILayout.EnumPopup("Right Key", myTarget.game_variables.RightPlayer_RightKey);

        }

        // In-game variables
        EditorGUI.indentLevel = 0;
        showInGameVars = EditorGUILayout.Foldout(showPrefab, "In-game variables");
        if (showInGameVars)
        {
            EditorGUI.indentLevel = 2;

            // Gamebjects
            GUI.enabled = false;
            EditorGUILayout.ObjectField("Left Player", myTarget.game_variables.LeftPlayer, typeof(Object), true);
            EditorGUILayout.ObjectField("Right Player", myTarget.game_variables.RightPlayer, typeof(Object), true);
            EditorGUILayout.ObjectField("Ball", myTarget.game_variables.Ball, typeof(Object), true);
            GUI.enabled = true;

            // Player Score
            GUI.enabled = false;
            EditorGUILayout.IntField("Left player score", myTarget.game_variables.LeftPlayerScore);
            EditorGUILayout.IntField("Right player score", myTarget.game_variables.RightPlayerScore);
            GUI.enabled = true;
        }

        if (GUI.changed)
            EditorUtility.SetDirty((game_controller)target);

    }
    
}


    