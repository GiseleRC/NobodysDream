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
        StartMovement();
    }
}
