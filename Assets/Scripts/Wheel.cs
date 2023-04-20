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
}
