using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnedBall : MonoBehaviour
{
    public GameObject Ball;

    void Start()
    {
        
    }

    void Update()
    {
       
        if (Input.GetButtonDown("Flashlight"))
        {
            Instantiate(Ball, transform.position, transform.rotation);
            Ball.GetComponent<Rigidbody>().isKinematic = false;
        }
    }
}
