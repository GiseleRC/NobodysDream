using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    public GameObject white, red;

    void OnTriggerEnter(Collider collider)
    {
        if (Input.GetButtonDown("Interact"))
        {
            red.SetActive(false);
            white.SetActive(true);
        }
    }
}
