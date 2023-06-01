using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingPlatformMovement : PlatformMovement
{
    [SerializeField] private Vector3 rotationAxis = Vector3.up;
    [SerializeField] private float angularVelocity = 1f;

    private void Awake()
    {
        PauseStateManager.Instance.OnPauseStateChanged += OnPauseStateChanged;
    }

    private void OnDestroy()
    {
        PauseStateManager.Instance.OnPauseStateChanged -= OnPauseStateChanged;
    }

    void FixedUpdate()
    {
        Quaternion deltaRotation = Quaternion.Euler(angularVelocity * rotationAxis * Time.fixedDeltaTime);
        rb.MoveRotation(rb.rotation * deltaRotation);
    }

    private void OnPauseStateChanged(PauseState newPauseState)
    {
        enabled = newPauseState == PauseState.Gameplay;
    }
}
