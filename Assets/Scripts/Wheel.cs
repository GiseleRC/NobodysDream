using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wheel : MonoBehaviour
{
    [SerializeField] float velocityRotation;
    void Update()
    {
        transform.Rotate(0,(transform.rotation.y + velocityRotation)* Time.deltaTime, 0);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("MatObject") && collision.gameObject.name != gameObject.name)
        {
            collision.gameObject.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if ((collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("MatObject")) && collision.gameObject.name != gameObject.name)
        {
            collision.gameObject.transform.SetParent(null);
        }
    }
}
