using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeenThinks : MonoBehaviour
{
    public GameObject platfGO;
    public float rotX, rotY, rotZ;
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Ball(Clone)")
        {
            platfGO.transform.Rotate(rotX, rotY, rotZ);
        }
    }
}
