using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(KinematicMovementController))]
public abstract class KinematicMovement : MonoBehaviour
{
    public virtual Vector3 GetPositionDelta(float dt)
    {
        return Vector3.zero;
    }

    public virtual Quaternion GetRotationDelta(float dt)
    {
        return Quaternion.identity;
    }

    public virtual void ResetMovement()
    {
    }
}
