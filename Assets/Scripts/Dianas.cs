using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dianas : MonoBehaviour
{
    public Puzzle2 puzzle2;
    public GameObject pivotBook;
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Ball(Clone)")
        {
            if (gameObject.name == "Diana1")
            {
                puzzle2.doorEnable1 = true;
                Debug.Log("1" + puzzle2.doorEnable1);
            }
            else if (gameObject.name == "Diana2")
            {
                puzzle2.doorEnable2 = true;
                Debug.Log("2" + puzzle2.doorEnable2);
            }
            else if (gameObject.name == "Diana3")
            {
                puzzle2.doorEnable3 = true;
                Debug.Log("3" + puzzle2.doorEnable3);
            }

        }

    }
}
