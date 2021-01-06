using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//USADO PARA USAR LOS SOCKETS
using SocketIO;
public class Power_GrowPlayer : Power_BaseBehaviour
{

    private bool isActivated = true;
    private bool isAlwaysActive = true;
    private float maxChangeMagnitude = 2.5f;
    private float currentUseOfChangeMagnitude = 1f;
    private string powerName = "Grow Player";

    private float growingSpeed = 1.5f;

    private float initialMiddleScale;
    private float initialColliderSize;
    private float cornerExtents;

    private Transform up_part;
    private Transform middle_part;
    private Transform down_part;
    private BoxCollider2D collider;
    private BGWebSocket APIREST;
    private BGobjects.AttributePlayer attAux;
    public float datito = 0;


    void Start()
    {
        up_part = transform.Find("Sprite Assets/pong_assets_up_corner");
        middle_part = transform.Find("Sprite Assets/pong_assets_middle");
        down_part = transform.Find("Sprite Assets/pong_assets_down_corner");
        initialMiddleScale = middle_part.localScale.y;
        collider = GetComponent<BoxCollider2D>();
        initialColliderSize = collider.size.y;
        cornerExtents = up_part.GetComponent<Renderer>().bounds.extents.y;
        //ACA EL CODIGO QUE DEBERIA CAMBIAR TODO
        //APIRestClient.instance.socket.On("AllSensors",OnAllSensors);
        BGWebSocket.instance.socket.On("Smessage",OnSmessag);
    }
    private void OnSmessag(SocketIOEvent socketIOevent)
    {
        Debug.Log("ENTRA EN EL CUSTIOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO");
        attAux = BGWebSocket.instance.JSONstrToAttribute(socketIOevent.data);
        string data = attAux.Dato.ToString();
        Debug.Log("EL DATO QUE LLEGO EeeeeeeeeeeeeeeeEESS: "+ data);
    }


    void Update()
    {
        PerformPower();
        changeUse();
        //APIRestClient.instance.GetAllSensors();
        //datito = GetComponent<APIRestClient>().datito;
    }

    public void PerformPower()
    {
        float changeScale = maxChangeMagnitude * currentUseOfChangeMagnitude;

        if (middle_part.localScale.y < changeScale + initialMiddleScale)
        {

            float middleScaleTarget = initialMiddleScale + changeScale;
            float currentMiddleScale = Mathf.Min(middle_part.localScale.y + growingSpeed * Time.deltaTime, middleScaleTarget);
            middle_part.localScale = new Vector3(middle_part.localScale.x, currentMiddleScale, middle_part.localScale.z);

            float upPositionTarget = cornerExtents + middle_part.GetComponent<Renderer>().bounds.extents.y;
            float downPositionTarget = -cornerExtents - middle_part.GetComponent<Renderer>().bounds.extents.y;

            float currentUpPosition = Mathf.Min(up_part.localPosition.y + growingSpeed * Time.deltaTime, upPositionTarget);
            float currentDownPosition = Mathf.Max(down_part.localPosition.y - growingSpeed * Time.deltaTime, downPositionTarget);

            up_part.localPosition = new Vector2(up_part.localPosition.x, currentUpPosition);
            down_part.localPosition = new Vector2(down_part.localPosition.x, currentDownPosition);


            float colliderSizeTarget = initialColliderSize + changeScale;
            float currentColliderSize = Mathf.Min(collider.size.y + growingSpeed * Time.deltaTime, colliderSizeTarget);
            collider.size = new Vector3(collider.size.x, currentColliderSize, collider.size.y);
        }


        else if (middle_part.localScale.y > (changeScale + initialMiddleScale))
        {

            float middleScaleTarget = initialMiddleScale + changeScale;
            float currentMiddleScale = Mathf.Max(middle_part.localScale.y - growingSpeed * Time.deltaTime, middleScaleTarget);

            middle_part.localScale = new Vector3(middle_part.localScale.x, currentMiddleScale, middle_part.localScale.z);

            float upPositionTarget = cornerExtents + middle_part.GetComponent<Renderer>().bounds.extents.y;
            float downPositionTarget = - cornerExtents - middle_part.GetComponent<Renderer>().bounds.extents.y;

            float currentUpPosition = Mathf.Max(up_part.localPosition.y - growingSpeed * Time.deltaTime, upPositionTarget);
            float currentDownPosition = Mathf.Min(down_part.localPosition.y + growingSpeed * Time.deltaTime, downPositionTarget);

            up_part.localPosition = new Vector2(up_part.localPosition.x, currentUpPosition);
            down_part.localPosition = new Vector2(down_part.localPosition.x, currentDownPosition);

            float colliderSizeTarget = initialColliderSize + changeScale;
            float currentColliderSize = Mathf.Max(collider.size.y - growingSpeed * Time.deltaTime, colliderSizeTarget);
            collider.size = new Vector3(collider.size.x, currentColliderSize, collider.size.y);


        }

    }

    private float time = 10.0f;
    public void changeUse()
    {
        time -= Time.deltaTime;
        if (time < 0)
        {
            currentUseOfChangeMagnitude = Random.Range(0, 2);
            Debug.Log(currentUseOfChangeMagnitude);
            time = 10.0f;
        }
        datito = BGWebSocket.instance.Datito;
        currentUseOfChangeMagnitude = (datito * 4)/100;
        //Debug.Log(currentUseOfChangeMagnitude);
        Debug.Log("El datito cambio a : "+ datito );
    }

}