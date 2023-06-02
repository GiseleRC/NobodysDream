using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallColumn : MonoBehaviour
{
    public GameObject bookWheelSC;
    public AudioSource audioSource;

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Ball(Clone)")
        {
            gameObject.GetComponent<Rigidbody>().isKinematic = false;
            bookWheelSC.GetComponent<Wheel>().enabled = true;
            audioSource.Play();
            bookWheelSC.GetComponentInChildren<Collider>().enabled = true;
        }
    }
    private void Update()
    {
        if (bookWheelSC.transform.rotation.z >= 0.2764)
        {
            audioSource.Stop();
            bookWheelSC.GetComponent<Wheel>().enabled = false;
        }
    }
}
