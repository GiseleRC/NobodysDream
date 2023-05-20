using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle2 : MonoBehaviour
{
    public bool doorEnable1 = false;
    public bool doorEnable2 = false;
    public bool doorEnable3 = false;
    public GameObject wallDisable;
    public GameObject particle1, particle2, particle3;

    void Update()
    {
        if (doorEnable1 && doorEnable2 && doorEnable3)
        {
            wallDisable.SetActive(false);
        }
        if (doorEnable1)
        {
            particle1.SetActive(true);
        }
        if (doorEnable2)
        {
            particle2.SetActive(true);
        }
        if (doorEnable3)
        {
            particle3.SetActive(true);
        }
    }
}
