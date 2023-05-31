using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MRUVPlatformMovement : PlatformMovement
{
    [SerializeField] private Vector3 acceleration = Physics.gravity;
    private Vector3 velocity = Vector3.zero;

    private void FixedUpdate()
    {
        velocity += acceleration * Time.deltaTime;
        rb.MovePosition(rb.position + velocity * Time.deltaTime);
    }
}
