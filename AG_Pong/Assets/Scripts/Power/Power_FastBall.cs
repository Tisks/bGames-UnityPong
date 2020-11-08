using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
public class Power_FastBall : Power_BaseBehaviour
{

    private bool isActivated = true;                
    private bool isAlwaysActive = true;                   
    private float maxChangeMagnitude = 30.0f;             
    private float currentUseOfChangeMagnitude = 1.0f;    
    private string powerName = "Fast Ball";             

    public void PerformPower()
    {
        if (isAlwaysActive || isActivated)
        {
            Rigidbody2D ballRigidBody = game_controller.instance.game_variables.Ball.GetComponent<Rigidbody2D>();
            var normalizedVelocity = ballRigidBody.velocity.normalized;
            ballRigidBody.velocity = ballRigidBody.velocity + (normalizedVelocity * maxChangeMagnitude * currentUseOfChangeMagnitude);
            if (!isAlwaysActive && isActivated) isActivated = false;
        }
    }

    public void OnDisable()
    {
        
        if ( gameObject == game_controller.instance.game_variables.LeftPlayer)
            game_controller.instance.game_event_manager.leftPlayerHit -= PerformPower;
        else if (gameObject == game_controller.instance.game_variables.RightPlayer)
            game_controller.instance.game_event_manager.rightPlayerHit -= PerformPower;
    }

    public void OnEnable()
    {

        if ( gameObject == game_controller.instance.game_variables.LeftPlayer)
            game_controller.instance.game_event_manager.leftPlayerHit += PerformPower;
        else if ( gameObject == game_controller.instance.game_variables.RightPlayer)
            game_controller.instance.game_event_manager.rightPlayerHit += PerformPower;
    }
}
 **/ 