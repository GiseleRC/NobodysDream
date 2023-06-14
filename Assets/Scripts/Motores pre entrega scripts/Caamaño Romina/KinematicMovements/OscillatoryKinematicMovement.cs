using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TP2 - Caamaño Romina - Uniform accelerated rectilinear motion hereda de Kinematic Movement
public class OscillatoryKinematicMovement : KinematicMovement
{
    //TP2 - Caamaño Romina - Encapsulamiento
    [SerializeField] protected Vector3 direction = Vector3.right;
    [SerializeField] protected float amplitude = 5f;
    [SerializeField] protected float frequency = 0.15f;

    protected float t = 0f;
    protected Vector3 origin;

    //TP2 - Caamaño Romina - Utiliza la funcion de reset en que no hace nada, 
    protected virtual void Start()
    {
        ResetMovement();
    }
    //TP2 - Caamaño Romina - sobreescribe el metodo llamado en el awake que no hace nada originalmente
    public override void ResetMovement()
    {
        t = 0f;
        origin = transform.position;
    }
    //TP2 - Caamaño Romina - Utiliza los metodos heredados y los sobreescribe
    public override Vector3 GetPositionDelta(float dt)
    {
        Vector3 prev = direction.normalized * amplitude * Mathf.Sin(2f * Mathf.PI * frequency * t);
        t += dt;
        Vector3 curr = direction.normalized * amplitude * Mathf.Sin(2f * Mathf.PI * frequency * t);
        return curr - prev;
    }

}
