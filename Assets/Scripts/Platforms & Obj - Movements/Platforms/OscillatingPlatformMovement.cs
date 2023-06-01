using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OscillatingPlatformMovement : PlatformMovement
{
    [SerializeField] private Vector3 dir = Vector3.right;
    [SerializeField] private float amp = 5f;
    [SerializeField] private float freq = 0.15f;

    private Vector3 origin;
    private float t = 0f;

    private void Start()
    {
        origin = transform.position;
    }

    protected override void Move()
    {
        t += Time.fixedDeltaTime;
        rb.MovePosition(origin + dir.normalized * amp * Mathf.Sin(2f * Mathf.PI * freq * t));
    }
}
