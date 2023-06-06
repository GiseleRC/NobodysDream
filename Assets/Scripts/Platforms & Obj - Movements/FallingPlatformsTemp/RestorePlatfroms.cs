using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestorePlatfroms : MonoBehaviour
{
    [SerializeField] private GameObject[] platforms;
    private Vector3[] platformsRestorePos;

    private void Start()
    {
        platformsRestorePos = new Vector3[platforms.Length];
        for (int i = 0; i < platforms.Length; i++)
        {
            platformsRestorePos[i] = platforms[i].transform.localPosition;
        }
    }

    private void Awake()
    {
        PauseStateManager.Instance.OnPauseStateChanged += OnPauseStateChanged;
    }

    private void OnDestroy()
    {
        PauseStateManager.Instance.OnPauseStateChanged -= OnPauseStateChanged;
    }

    private void FixedUpdate()
    {
        for (int i = 0; i < platforms.Length; i++)
        {
            if (platforms[i].transform.position.y < -40)
            {
                platforms[i].transform.localPosition = platformsRestorePos[i];
            }
        }
    }

    private void OnPauseStateChanged(PauseState newPauseState)
    {
        enabled = newPauseState == PauseState.Gameplay;
    }
}