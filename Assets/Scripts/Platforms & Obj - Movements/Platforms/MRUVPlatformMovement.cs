using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MRUVPlatformMovement : PlatformMovement
{
    [SerializeField] private Vector3 acceleration = Physics.gravity;
    private Vector3 velocity = Vector3.zero;
    //Para la plataforma que cae
    protected override void Move()
    {
        velocity += acceleration * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
    }
}
