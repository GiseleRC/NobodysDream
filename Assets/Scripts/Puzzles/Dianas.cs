using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dianas : MonoBehaviour
{
    public Puzzle2 puzzle2;
    public Puzzle3 puzzle3;

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Ball(Clone)")
        {
            if (gameObject.name == "Diana1")
            {
                puzzle2.doorEnable1 = true;
            }
            if (gameObject.name == "Diana2")
            {
                puzzle2.doorEnable2 = true;
            }
            if (gameObject.name == "Diana3")
            {
                puzzle2.doorEnable3 = true;
            }

            if (gameObject.name == "Nose1")
            {
                puzzle3.showGuess1 = true;
                Debug.Log("Le pegue a la PRIMERA Nariz");
            }
            if (gameObject.name == "Nose2")
            {
                puzzle3.showGuess2 = true;
                Debug.Log("Le pegue a la SEGUNDA Nariz");
            }
            if (gameObject.name == "Nose3")
            {
                puzzle3.showGuess3 = true;
                Debug.Log("Le pegue a la TERCERA Nariz");
            }
        }
    }
}
