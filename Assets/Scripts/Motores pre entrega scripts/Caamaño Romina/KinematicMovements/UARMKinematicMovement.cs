using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TP2 - Caamaño Romina - Uniform accelerated rectilinear motion hereda de Kinematic Movement
public class UARMKinematicMovement : KinematicMovement
{
    //TP2 - Caamaño Romina - Encapsulamiento
    [SerializeField] protected Vector3 acceleration = Vector3.zero;
    [SerializeField] protected Vector3 initialVelocity = Vector3.zero;

    protected Vector3 velocity;

    //TP2 - Caamaño Romina - Utiliza la funcion de reset en que no hace nada, solo para que tenga un awake
    protected virtual void Awake()
    {
        ResetMovement();
    }
    //TP2 - Caamaño Romina - Utiliza los metodos heredados y los sobreescribe
    public override Vector3 GetPositionDelta(float dt)
    {
        velocity += acceleration * dt;
        return velocity * dt;
    }
    //TP2 - Caamaño Romina - sobreescribe el metodo llamado que no hace nada originalmente
    public override void ResetMovement()
    {
        velocity = initialVelocity;
    }
}
