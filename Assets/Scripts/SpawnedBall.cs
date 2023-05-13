using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnedBall : MonoBehaviour
{
    public GameObject ball, point;
    public bool ballEnable = false;


    void Update()
    {

        if (Input.GetButtonDown("Flashlight") && ballEnable)
        {
            Instantiate(ball, point.transform.position, point.transform.rotation);
            ball.GetComponent<Rigidbody>().isKinematic = false;
        }
    }
}
