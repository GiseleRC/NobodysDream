using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class ReactionPlatform : Platform
{
    [SerializeField] private float delayTime = 0f;
    private float delay = 0f;
    private bool active = false;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Char")
            active = true;
    }

    private void Update()
    {
        if (!active)
            return;

        delay += Time.deltaTime;
        if (delay > delayTime)
        {
            StartMovement();
        }
    }
}
