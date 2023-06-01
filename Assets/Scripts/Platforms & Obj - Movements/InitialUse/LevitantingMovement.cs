using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevitantingMovement : MonoBehaviour
{
    public float maxHeight;
    public float velocityLevitation;
    private Vector3 initialPos;

    private void Awake()
    {
        PauseStateManager.Instance.OnPauseStateChanged += OnPauseStateChanged;
    }

    private void OnDestroy()
    {
        PauseStateManager.Instance.OnPauseStateChanged -= OnPauseStateChanged;
    }

    void Start()
    {
        initialPos = transform.position;
    }
    void Update()
    {
        transform.position = initialPos + new Vector3(0, Mathf.Sin(Time.time * velocityLevitation) * maxHeight, 0);
    }

    private void OnPauseStateChanged(PauseState newPauseState)
    {
        enabled = newPauseState == PauseState.Gameplay;
    }
}
