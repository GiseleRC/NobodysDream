using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle2 : MonoBehaviour
{
    public bool doorEnable1 = false;
    public bool doorEnable2 = false;
    public bool doorEnable3 = false;
    public GameObject wallDisable;

    void Update()
    {
        if (doorEnable1 && doorEnable2 && doorEnable3)
        {
            wallDisable.SetActive(false);
        }
    }
}
