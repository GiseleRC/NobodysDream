using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walls : MonoBehaviour
{
    public bool kinematicDisable = false;
    public bool dontFall = true;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (kinematicDisable && dontFall)
        {
            Rigidbody[] rigidbodies = FindObjectsOfType<Rigidbody>();
            foreach (Rigidbody rb in rigidbodies)
            {
                rb.isKinematic = false;
            }
        }

        if (transform.position.y < -50)
        {
            dontFall = false;
        }
    }
}
