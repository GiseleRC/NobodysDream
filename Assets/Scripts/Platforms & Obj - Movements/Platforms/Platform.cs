using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlatformMovement))]
public abstract class Platform : MonoBehaviour
{
    protected PlatformMovement[] platformMovements;

    protected void Awake()
    {
        platformMovements = GetComponents<PlatformMovement>();
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

    protected void StartMovement()
    {
        foreach (PlatformMovement pm in platformMovements)
            pm.MovementEnabled = true;
    }
}
