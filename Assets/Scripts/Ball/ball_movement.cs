using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball_movement : MonoBehaviour {

    public float initialSpeed;
    public float accelerationPerHit;
    public float maxSpeed;
    private float currentMovementSpeed;
    private new Rigidbody2D rigidbody;

    private bool throwToTheLeft;
    private bool waitingForThrow;
    private float beforeThrowingTimer;
    private float autoThrowingTimer;

    // Use this for initialization
    void Start() {
        throwToTheLeft = true;                          // Throw to the left at first by default
        rigidbody = GetComponent<Rigidbody2D>();        // Store rigidbody on variable to not do GetComponent for every use
        updateToInitialState();
    }

    // Update is called once per frame
    void Update() {
        if (waitingForThrow)
            manageInitialThrowing();
    }

    // Manage initial throwing.
    void manageInitialThrowing()
    {

        beforeThrowingTimer -= Time.deltaTime;

        if (beforeThrowingTimer <= 0.0f)
        {
            if (throwToTheLeft && player_resources.hasLeftPlayerMoved())
            {
                rigidbody.velocity = new Vector2(-initialSpeed, 0);
                waitingForThrow = false;
            }

            else if (!throwToTheLeft && player_resources.hasRightPlayerMoved())
            {
                rigidbody.velocity = new Vector2(initialSpeed, 0);
                waitingForThrow = false;
            }

            else
            {
                autoThrowingTimer -= Time.deltaTime;

                if (autoThrowingTimer <= 0.0f)
                {
                    if (throwToTheLeft)
                        rigidbody.velocity = new Vector2(-initialSpeed, 0);
                    else
                        rigidbody.velocity = new Vector2(initialSpeed, 0);
                    waitingForThrow = false;
                }

            }

        }
    }

    // Manage collision effects.
    void OnCollisionEnter2D(Collision2D hit)
    {
        // Collision with left player
        if (hit.gameObject == game_controller.instance.game_variables.LeftPlayer)
        {
            accelerateCurrentMovementSpeed();
            rigidbody.velocity = new Vector2(obtainHorizontalVelocityOnHit(), obtainVerticalVelocityOnHit(hit));
           game_controller.instance.game_event_manager.eventLeftPlayerHit();
        }

        // Collision with right player
        else if (hit.gameObject == game_controller.instance.game_variables.RightPlayer)
        {
            
            accelerateCurrentMovementSpeed();
            rigidbody.velocity = new Vector2(obtainHorizontalVelocityOnHit(), obtainVerticalVelocityOnHit(hit));
           game_controller.instance.game_event_manager.eventRightPlayerHit();
        }
        
        // Collision with left goal
        else if (hit.collider == game_controller.instance.game_variables.getLeftWallObject().GetComponent<Collider2D>())
        {
            updateToInitialState();
            throwToTheLeft = true;
           game_controller.instance.game_event_manager.eventRightPlayerScore();
        }

        // Collision with right goal
        else if (hit.collider == game_controller.instance.game_variables.getRightWallObject().GetComponent<Collider2D>())
        {
            updateToInitialState();
            throwToTheLeft = false;
           game_controller.instance.game_event_manager.eventLeftPlayerScore();

        }
    }

    // Update the current movement speed added to the acceleration variable
    void accelerateCurrentMovementSpeed()
    {
        currentMovementSpeed = Mathf.Clamp(currentMovementSpeed + accelerationPerHit, initialSpeed, maxSpeed);
    }

    // Return the velocity's x component according to the current movement speed
    float obtainHorizontalVelocityOnHit()
    {
        // Don't know why this works, but it does works
        if (rigidbody.velocity.x < 0)
            return - currentMovementSpeed;
        else
            return currentMovementSpeed;
    }

    // Return the velocity's y component according to the current movement speed
    float obtainVerticalVelocityOnHit( Collision2D hit)
    {
        var contactPoint = hit.contacts[0].point;
        var playerObject = hit.gameObject;
        var playerBounds = playerObject.GetComponent<Collider2D>().bounds;
        var playerCenter = playerBounds.center;
        var playerExtents = playerBounds.extents;
        var distance = contactPoint.y - playerCenter.y + playerExtents.y;
        var distancePercentage = (distance * 100) / (2 * playerExtents.y) - 50;
        return currentMovementSpeed * (distancePercentage / 100);
    }

    // Reset to initial State;
    void updateToInitialState()
    {
        ball_resources.setBallToCenterPosition();
        rigidbody.velocity = new Vector2(0, 0);         // Ball movement to none
        beforeThrowingTimer = 0.5f;                     // Seconds before being able to throw the ball
        autoThrowingTimer = 5;                          // Seconds before it is thrown automatically
        waitingForThrow = true;                         // Ball must be throw again
        currentMovementSpeed = initialSpeed;            // Ball speed is set to match initial speed
    }

    // Get current movement speed
    public float getCurrentMovementSpeed()
    {
        return currentMovementSpeed;
    }


}

