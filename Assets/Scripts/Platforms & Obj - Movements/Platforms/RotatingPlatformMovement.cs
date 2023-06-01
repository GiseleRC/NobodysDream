using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingPlatformMovement : PlatformMovement
{
    [SerializeField] private Vector3 rotationAxis = Vector3.up;
    [SerializeField] private float angularVelocity = 1f;

    protected override void Move()
    {
        Quaternion deltaRotation = Quaternion.Euler(angularVelocity * rotationAxis * Time.fixedDeltaTime);
        rb.MoveRotation(rb.rotation * deltaRotation);
    }
}
