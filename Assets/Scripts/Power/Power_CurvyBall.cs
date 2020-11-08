using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
public class Power_CurvyBall : AbstractPower
{

    // PROPERTIES

        
    private GameObject _playerobj;

    private PlayerController _playerController;

    private string _power_name = "CurvyBall";

    private Color _power_color = Color.blue;

    private useType _power_usetype = useType.onCollision;

    private bool _powerIsActive;

    private float _powerIncrement = 0.075f;

    private int statsConsumption = 5;


    // CONSTRUCTOR FUNCTION
    public Power_CurvyBall(GameObject playerobj)
    {
        _playerobj = playerobj;

        _powerIsActive = false;


    }

    // GETTER FUNCTIONS:
    public override string get_power_name() { return _power_name; }

    public override Color get_power_color() { return _power_color; }

    public override useType get_power_usertype() { return _power_usetype; }

    public override bool power_onCollisionType() { return _power_usetype == useType.onCollision; }

    public override bool power_OnTimerType() { return _power_usetype == useType.onTimer; }

    public override bool power_isActive() { return _powerIsActive; }

    // OTHER FUNCTIONS:
    public override void activate_deactivate_power()
    {
        var spriteRenderer = _playerobj.transform.Find("PLY-Sprite").GetComponent<SpriteRenderer>();

        _powerIsActive = !_powerIsActive;


        if (_powerIsActive)
        {
            spriteRenderer.color = _power_color;
        }
        else
        {
            spriteRenderer.color = Color.white;
        }
    }

    public override void deactivate_power()
    {
        _powerIsActive = false;

        var spriteRenderer = _playerobj.transform.Find("PLY-Sprite").GetComponent<SpriteRenderer>();

        spriteRenderer.color = Color.white;
    }

    public override void consume_power(object arg)
    {

        if (_playerController.getSocialStats() >= statsConsumption)
        {

            GameObject ballObject = (GameObject)arg;

            ballObject.GetComponent<BallBehaviour>().updateMovementAmplitude(_powerIncrement);

            _playerobj.GetComponent<PlayerController>().decreaseMentalStats(statsConsumption);


        }

        deactivate_power();

    }

    public override void activate_power()
    {

    }

}
    **/
