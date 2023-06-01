using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public abstract class PlatformMovement : MonoBehaviour
{
    protected Rigidbody rb;
    public bool MovementEnabled { get; set; } = false;

    protected void Awake()
    {
        rb = GetComponent<Rigidbody>();
        PauseStateManager.Instance.OnPauseStateChanged += OnPauseStateChanged;
    }

    protected void OnDestroy()
    {
        PauseStateManager.Instance.OnPauseStateChanged -= OnPauseStateChanged;
    }

    protected void OnPauseStateChanged(PauseState newPauseState)
    {
        enabled = newPauseState == PauseState.Gameplay;
    }

    protected void FixedUpdate()
    {
        if (MovementEnabled)
            Move();
    }

    protected abstract void Move();
}
