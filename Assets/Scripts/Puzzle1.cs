using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle1 : MonoBehaviour
{
    public GameObject textHere, sensorplayerRigth, sensorIncorrect;
  
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
