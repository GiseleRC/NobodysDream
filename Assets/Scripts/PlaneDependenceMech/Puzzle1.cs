using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle1 : MonoBehaviour
{
    public GameObject textHere, sensorplayerRigth, sensorIncorrect;
    bool stairPart1 = false;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Cube")
        {
            stairPart1 = true;
            Debug.Log(stairPart1);
        }
        if (other.gameObject.tag == "Player")
        {
            stairPart1 = true;
            Debug.Log(stairPart1 + "Player");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Cube")
        {
            stairPart1 = false;
            Debug.Log(stairPart1);
        }
        if (other.gameObject.tag == "Player")
        {
            stairPart1 = false;
            Debug.Log(stairPart1 + "Player");
        }
    }
    private void Update()
    {
        if (textHere)
        {
            textHere.SetActive(true);
            sensorplayerRigth.SetActive(true);
            sensorIncorrect.SetActive(false);
        }
    }
}
