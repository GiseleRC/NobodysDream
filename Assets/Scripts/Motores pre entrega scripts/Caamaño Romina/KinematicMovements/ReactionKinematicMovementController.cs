using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class ReactionKinematicMovementController : KinematicMovementController
{
    protected override void Start()
    {
    }

    protected virtual void OnCollisionEnter(Collision collision)
    {
        // Ver una mejor forma de detectar el objecto que activa el movimiento
        if (collision.gameObject.name == "Char")
            StartMovement();
    }
}
