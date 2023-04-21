using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walls : MonoBehaviour
{
    public GameObject newWalls;
    public Rigidbody wall1, wall2, wall3, wall4;
    public void EventFallWalls()
    {
        wall1.isKinematic = false;
        wall2.isKinematic = false;
        wall3.isKinematic = false;
        wall4.isKinematic = false;
        if (wall1.position.y < -50 || wall2.position.y < -50 || wall3.position.y < -50 || wall4.position.y < -50)
        {
            Destroy(wall1);
            Destroy(wall2);
            Destroy(wall3);
            Destroy(wall4);
        }
    }
    public void EventNewWalls()
    {
        newWalls.SetActive(true);
    }


}
