using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomGravity : MonoBehaviour
{
    public float gravityScale = 1.0f;

    public static float globalGravity = -9.81f;

    Rigidbody m_rb;

    GroundCheck ground;
    void OnEnable()
    {
        m_rb = GetComponent<Rigidbody>();
        m_rb.useGravity = false;
        ground = GetComponentInChildren<GroundCheck>();

    }

    void FixedUpdate()
    {
        Vector3 gravity = globalGravity * gravityScale * Vector3.up;
        m_rb.AddForce(gravity, ForceMode.Acceleration);
        if (ground.IsGrounded)
        {
            gravityScale = 1.0f;
        }
    }
    public void changeGravity(float scaleGravity)
    {
        gravityScale = scaleGravity;
    }
}
