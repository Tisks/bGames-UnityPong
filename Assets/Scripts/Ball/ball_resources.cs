using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ball_resources {

    public static void initializeBall()
    {
        if (game_controller.instance.game_variables.Ball != null)
            UnityEngine.Object.Destroy(game_controller.instance.game_variables.Ball);
        var ball = UnityEngine.Object.Instantiate(game_controller.instance.ballPrefab) as GameObject;
        game_controller.instance.game_variables.Ball = ball;

        // Set ball to the middle position of the player field
        setBallToCenterPosition();
    }

    public static void setBallToCenterPosition()
    {
        if (game_controller.instance.game_variables.Ball != null &&
            game_controller.instance.game_variables.PlayerField != null)
            game_controller.instance.game_variables.Ball.transform.position = game_controller.instance.game_variables.PlayerField.transform.position;
        else if (game_controller.instance.game_variables.Ball == null)
            Debug.Log("Couldn't move the ball to the center position. Ball gameobject is missing");
        else if (game_controller.instance.game_variables.PlayerField == null)
            Debug.Log("Couldn't move the ball to the center position. Ball gameobject is missing");
    }
}
