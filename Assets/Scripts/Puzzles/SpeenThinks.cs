using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeenThinks : MonoBehaviour
{
    public float rotX, rotY, rotZ;
    public GameObject ghost1, ghost, patrol, level2;
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Ball(Clone)")
        {
            gameObject.transform.Rotate(rotX, rotY, rotZ);

            if (gameObject.name == "Pizarron")
            {
                ghost.SetActive(true);
                ghost1.SetActive(true);
                patrol.SetActive(true);
                level2.SetActive(true);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Ball(Clone)")
        {
            gameObject.transform.Rotate(rotX, rotY, rotZ);
        }
    }
}
