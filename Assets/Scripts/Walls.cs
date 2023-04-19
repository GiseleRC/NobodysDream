using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walls : MonoBehaviour
{
    public GameObject newWalls;
    public void EventFallWalls()
    {
        Rigidbody[] rigidbodies = FindObjectsOfType<Rigidbody>();
        foreach (Rigidbody rb in rigidbodies)
        {
            rb.isKinematic = false;
            if (rb.transform.position.y < -50)
            {
                Destroy(rb);
            }
        }
    }
    public void EventNewWalls()
    {
        newWalls.SetActive(true);
    }


}
