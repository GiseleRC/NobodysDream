using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlatformMovement))]
public abstract class Platform : MonoBehaviour
{
    protected PlatformMovement[] platformMovements;

    void Awake()
    {
        platformMovements = GetComponents<PlatformMovement>();
    }

    protected void StartMovement()
    {
        foreach (PlatformMovement pm in platformMovements)
            pm.enabled = true;
    }
}
