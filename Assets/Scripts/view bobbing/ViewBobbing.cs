using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PositionFollower))] //llama a la clase del positionfollower

public class ViewBobbing : MonoBehaviour
    //Aplica el offset al positionfollower (primera clase)
{
    public float EffectIntensity;
    public float EffectIntensityX;
    public float EffectSpeed;

    private PositionFollower FollowerInstance;
    private Vector3 OriginalOffset;
    private float SinTime;

    void Start()
    {
        FollowerInstance = GetComponent<PositionFollower>(); //inicializa el instance de la primera clase y guarda referencia del offset original
        OriginalOffset = FollowerInstance.Offset;
    }

    void Update()
    {
        Vector3 inputVector = new Vector3(Input.GetAxis("Vertical"), 0f, Input.GetAxis("Horizontal")); //usa los inputs para determinar cuando hacer el bobbing
        
        if (inputVector.magnitude > 0f)
        {
            SinTime += Time.deltaTime * EffectSpeed;
        }
        else
        {
            SinTime = 0f;
        }

        float sinAmountY = -Mathf.Abs(EffectIntensity * Mathf.Sin(SinTime)); //usa el negativo del seno para funcionar (empieza en 0,0)
        Vector3 sinAmountX = FollowerInstance.transform.right * EffectIntensity * Mathf.Cos(SinTime) * EffectIntensityX; //lo mismo pero con coseno

        FollowerInstance.Offset = new Vector3 // Aplica la funcion senoidal de los outputs a los offsets de la posicion del follower
        {
            x = OriginalOffset.x,
            y = OriginalOffset.y + sinAmountY,
            z = OriginalOffset.z
        };

        FollowerInstance.Offset += sinAmountX;
    }
}
