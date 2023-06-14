using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TP2 - Caamaño Romina - requiere un rigidbody
[RequireComponent(typeof(Collider))]

//TP2 - Caamaño Romina - hereda de kinematic movement controller
public class ReactionKinematicMovementController : KinematicMovementController
{
    //TP2 - Caamaño Romina - sobreescribe el start heredado con un start vacio
    //para que no comience su movimiento al inciar si no cuando colisione con el player
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
