using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UARMKinematicMovement : KinematicMovement
{
    [SerializeField] protected Vector3 acceleration = Vector3.zero;
    [SerializeField] protected Vector3 initialVelocity = Vector3.zero;

    protected Vector3 velocity;

    protected virtual void Awake()
    {
        velocity = initialVelocity;
    }

    public override Vector3 GetPositionDelta(float dt)
    {
        velocity += acceleration * dt;
        return velocity * dt;
    }
}
