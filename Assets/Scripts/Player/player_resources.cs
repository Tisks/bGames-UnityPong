using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class player_resources {

    // Use this for instantiating the left player
	public static void initializeLeftPlayer()
    {

        if (game_controller.instance.game_variables.LeftPlayer != null)
            UnityEngine.Object.Destroy(game_controller.instance.game_variables.LeftPlayer);
        GameObject leftPlayer = UnityEngine.Object.Instantiate(game_controller.instance.playerPrefab) as GameObject;
        game_controller.instance.game_variables.LeftPlayer = leftPlayer;

        // Add movement Keys
        leftPlayer.GetComponent<player_movement>().addMovementKeys(game_controller.instance.game_variables.LeftPlayer_DownKey,
                                                                   game_controller.instance.game_variables.LeftPlayer_LeftKey,
                                                                   game_controller.instance.game_variables.LeftPlayer_RightKey,
                                                                   game_controller.instance.game_variables.LeftPlayer_UpKey);

        // Add initial position
        moveLeftPlayerToInitialPosition();

        // Add color
        addLeftPlayerDefaultColor();

        // Add powers
        //leftPlayer.AddComponent<Power_FastBall>();
        leftPlayer.AddComponent<Power_GrowPlayer>();
        

    }

    // Use this for instantiating the right player
    public static void initializeRightPlayer()
    {
        if (game_controller.instance.game_variables.RightPlayer != null)
            UnityEngine.Object.Destroy(game_controller.instance.game_variables.RightPlayer);
        GameObject rightPlayer = UnityEngine.Object.Instantiate(game_controller.instance.playerPrefab) as GameObject;
        game_controller.instance.game_variables.RightPlayer = rightPlayer;
    
        // Add movement Keys
        rightPlayer.GetComponent<player_movement>().addMovementKeys(game_controller.instance.game_variables.RightPlayer_DownKey,
                                                                   game_controller.instance.game_variables.RightPlayer_LeftKey,
                                                                   game_controller.instance.game_variables.RightPlayer_RightKey,
                                                                   game_controller.instance.game_variables.RightPlayer_UpKey);

        // Add initial position
        moveRightPlayerToInitialPosition();

        // Add color
        addRightPlayerDefaultColor();

    }

    // Move left player to his initial position
    public static void moveLeftPlayerToInitialPosition()
    {
        if (game_controller.instance.game_variables.PlayerField != null &&
            game_controller.instance.game_variables.LeftPlayer != null)
        {
            float y_position = game_controller.instance.game_variables.PlayerField.transform.position.y;
            float x_position = -25;
            game_controller.instance.game_variables.LeftPlayer.transform.position = new Vector2(x_position, y_position);
        }

        else if (game_controller.instance.game_variables.PlayerField == null)
            Debug.Log("Couldn't move left player to his center position. playerField object is missing");
        else if (game_controller.instance.game_variables.LeftPlayer == null)
            Debug.Log("Couldn't move left player to his center position. leftPlayer object is missing");
    }

    // Move right player ho his initial position
    public static void moveRightPlayerToInitialPosition()
    {
        if (game_controller.instance.game_variables.PlayerField != null &&
            game_controller.instance.game_variables.RightPlayer != null)
        {
            float y_position = game_controller.instance.game_variables.PlayerField.transform.position.y;
            float x_position = 25;
            game_controller.instance.game_variables.RightPlayer.transform.position = new Vector2(x_position, y_position);
        }

        else if (game_controller.instance.game_variables.PlayerField == null)
            Debug.Log("Couldn't move right player to his center position. playerField object is missing");
        else if (game_controller.instance.game_variables.RightPlayer == null)
            Debug.Log("Couldn't move right player to his center position. rightPlayer object is missing");
    }

    // Check if left player has moved
    public static bool hasLeftPlayerMoved()
    {
        return Input.GetKey(game_controller.instance.game_variables.LeftPlayer_DownKey) ||
                Input.GetKey(game_controller.instance.game_variables.LeftPlayer_LeftKey) ||
                Input.GetKey(game_controller.instance.game_variables.LeftPlayer_RightKey) ||
                Input.GetKey(game_controller.instance.game_variables.LeftPlayer_UpKey);
    }

    // Check if right player has moved
    public static bool hasRightPlayerMoved()
    {
        return Input.GetKey(game_controller.instance.game_variables.RightPlayer_DownKey) ||
                Input.GetKey(game_controller.instance.game_variables.RightPlayer_LeftKey) ||
                Input.GetKey(game_controller.instance.game_variables.RightPlayer_RightKey) ||
                Input.GetKey(game_controller.instance.game_variables.RightPlayer_UpKey);
    }



    // Add color to player
    public static void addColor(GameObject player, Color color)
    {
        if (!color.Equals(Color.clear))
            foreach (SpriteRenderer sr in player.GetComponentsInChildren<SpriteRenderer>(true))
                sr.color = color;
        else
            Debug.Log("Couldn't paint gameobject. Color is not valid");
    }

    // Add default color to the left player
    public static void addLeftPlayerDefaultColor()
    {
        if (game_controller.instance.game_variables.LeftPlayer != null &&
            !game_controller.instance.game_variables.LeftPlayer_Color.Equals(Color.clear))
            addColor(game_controller.instance.game_variables.LeftPlayer, game_controller.instance.game_variables.LeftPlayer_Color);

        else if (game_controller.instance.game_variables.LeftPlayer == null)
            Debug.Log("Couldn't paint left player to his center position. leftPlayer object is missing");

        else if (game_controller.instance.game_variables.LeftPlayer_Color.Equals(Color.clear))
            Debug.Log("Couldn't paint left player to his center position. leftPlayer_Color object is missing");

    }

    // Add default color to the right player
    public static void addRightPlayerDefaultColor()
    {
        if (game_controller.instance.game_variables.RightPlayer != null &&
           !game_controller.instance.game_variables.RightPlayer_Color.Equals(Color.clear))
            addColor(game_controller.instance.game_variables.RightPlayer, game_controller.instance.game_variables.RightPlayer_Color);

        else if (game_controller.instance.game_variables.RightPlayer == null)
            Debug.Log("Couldn't paint right player to his center position. rightPlayer object is missing");

        else if (!game_controller.instance.game_variables.RightPlayer_Color.Equals(Color.clear))
            Debug.Log("Couldn't paint right player to his center position. rightPlayer_Color object is missing");

    }
}
