using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_movement : MonoBehaviour {

    private KeyCode downMovementKey;
    private KeyCode leftMovementKey;
    private KeyCode rightMovementKey;
    private KeyCode upMovementKey;
    public float movementSpeed;
    public float middleSeparation;

    public void addMovementKeys(KeyCode downKey, KeyCode leftKey, KeyCode rightKey, KeyCode upKey)
    {
        downMovementKey = downKey;
        leftMovementKey = leftKey;
        rightMovementKey = rightKey;
        upMovementKey = upKey;
    }

    // Update is called once per frame
    void Update () {
        manageMovement();
    }

    // Responsible of gameobject's movement
    void manageMovement()
    {
        manageHorizontalMovement();
        manageVerticalMovement();
    }

    // Responsible of horizontal gameobject's movement
    void manageHorizontalMovement()
    {
        if (Input.GetKey(leftMovementKey))
            transform.position = new Vector2(limitedHorizontalPosition(transform.position.x - movementSpeed * Time.deltaTime), transform.position.y);
        else if (Input.GetKey(rightMovementKey))
            transform.position = new Vector2(limitedHorizontalPosition(transform.position.x + movementSpeed * Time.deltaTime), transform.position.y);
    }

    // Responsible of vertical gameobject's movement
    void manageVerticalMovement()
    {
        if (Input.GetKey(downMovementKey))
            transform.position = new Vector2(transform.position.x, transform.position.y - movementSpeed * Time.deltaTime);
        else if (Input.GetKey(upMovementKey))
            transform.position = new Vector2(transform.position.x, transform.position.y + movementSpeed * Time.deltaTime);
    }

    // Doesn't let gameobject move throught the middle lane
    float limitedHorizontalPosition(float next_position_x)
    {
        float position_x = transform.position.x;
        float new_position_x = next_position_x;
        float middlePosition = game_controller.instance.game_variables.PlayerField.transform.position.x;
        if (position_x < middlePosition)
            new_position_x = Mathf.Clamp(next_position_x, -100, middlePosition - middleSeparation);
        else if (position_x > middlePosition)
            new_position_x = Mathf.Clamp(next_position_x, middlePosition + middleSeparation, 100);
        return new_position_x;
    }
}
