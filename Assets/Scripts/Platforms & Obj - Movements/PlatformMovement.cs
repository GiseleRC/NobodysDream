using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public abstract class PlatformMovement : MonoBehaviour
{
    protected Rigidbody rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        enabled = false;
    }
}
