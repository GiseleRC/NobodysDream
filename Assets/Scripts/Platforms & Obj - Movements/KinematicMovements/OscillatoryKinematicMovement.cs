using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OscillatoryKinematicMovement : KinematicMovement
{
    [SerializeField] protected Vector3 direction = Vector3.right;
    [SerializeField] protected float amplitude = 5f;
    [SerializeField] protected float frequency = 0.15f;

    protected float t = 0f;
    protected Vector3 origin;

    protected virtual void Start()
    {
        ResetMovement();
    }

    public override Vector3 GetPositionDelta(float dt)
    {
        Vector3 prev = direction.normalized * amplitude * Mathf.Sin(2f * Mathf.PI * frequency * t);
        t += dt;
        Vector3 curr = direction.normalized * amplitude * Mathf.Sin(2f * Mathf.PI * frequency * t);
        return curr - prev;
    }

    public override void ResetMovement()
    {
        t = 0f;
        origin = transform.position;
    }
}
