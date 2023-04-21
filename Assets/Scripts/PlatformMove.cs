using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMove : MonoBehaviour
{
    [SerializeField] private Vector3 dir = Vector3.right;
    [SerializeField] private float amp = 5f;
    [SerializeField] private float freq = 0.2f;

    private Vector3 origin;
    private Rigidbody rigidBody;
    public float t = 0f;

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        origin = transform.position;
    }

    private void FixedUpdate()
    {
        t += Time.deltaTime;
        rigidBody.MovePosition(origin + dir.normalized * amp * Mathf.Sin(2f * Mathf.PI * freq * t));
    }
}