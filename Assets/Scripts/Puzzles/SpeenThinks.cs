using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeenThinks : MonoBehaviour
{
    public float rotX, rotY, rotZ, currRotX;
    private bool oreoStartRot = false;
    public GameObject partTwoOflevel2, particle;
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Ball(Clone)" && gameObject.name == "Pizarron")
        {
            gameObject.transform.Rotate(rotX, rotY, rotZ);
            partTwoOflevel2.SetActive(true);
            particle.SetActive(false);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Ball(Clone)" && gameObject.name == "OreoL")
        {
            oreoStartRot = true;
            gameObject.GetComponent<KinematicMovementController>().enabled = true;
        }
    }

    private void Update()
    {
        if (gameObject.name == "OreoL" && oreoStartRot)
        {
            currRotX = gameObject.transform.rotation.x;
            if (currRotX >= 1f)
            {
                gameObject.GetComponent<KinematicMovementController>().enabled = false;
                oreoStartRot = false;
            }
        }

    }
}
