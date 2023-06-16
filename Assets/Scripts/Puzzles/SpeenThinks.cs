using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeenThinks : MonoBehaviour
{
    public float rotX, rotY, rotZ;
    public GameObject partTwoOflevel2, particle;
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Ball(Clone)")
        {
            gameObject.transform.Rotate(rotX, rotY, rotZ);

            if (gameObject.name == "Pizarron")
            {
                partTwoOflevel2.SetActive(true);
                particle.SetActive(false);
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
