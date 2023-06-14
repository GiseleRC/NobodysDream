using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class KinematicMovementController : MonoBehaviour
{
    [SerializeField] protected float delayTime = 0f;

    protected Rigidbody rb;
    protected KinematicMovement[] kinematicMovements;
    protected bool movementEnabled = false;

    private float delay = 0f;

    protected virtual void Awake()
    {
        rb = GetComponent<Rigidbody>();
        kinematicMovements = GetComponents<KinematicMovement>();
        PauseStateManager.Instance.OnPauseStateChanged += OnPauseStateChanged;
    }

    protected virtual void Start()
    {
        StartMovement();
    }

    protected virtual void OnDestroy()
    {
        PauseStateManager.Instance.OnPauseStateChanged -= OnPauseStateChanged;
    }

    protected virtual void FixedUpdate()
    {
        if (!movementEnabled)
            return;

        float dt = Time.fixedDeltaTime;

        if (delay > 0f)
        {
            delay = Mathf.Max(delay - dt, 0f);
            return;
        }

        Vector3 positionDelta = rb.position;
        Quaternion rotationDelta = rb.rotation;

        foreach (KinematicMovement kinematicMovement in kinematicMovements)
        {
            positionDelta += kinematicMovement.GetPositionDelta(dt);
            rotationDelta *= kinematicMovement.GetRotationDelta(dt);
        }

        rb.MovePosition(positionDelta);
        rb.MoveRotation(rotationDelta);
    }

    protected virtual void OnPauseStateChanged(PauseState pauseState)
    {
        movementEnabled = pauseState == PauseState.Gameplay;
    }

    protected virtual void StartMovement()
    {
        delay = delayTime;
        movementEnabled = true;
    }
}
