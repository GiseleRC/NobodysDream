using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle3 : MonoBehaviour
{
    public bool showGuess1 = false;
    public bool showGuess2 = false;
    public bool showGuess3 = false;
    public GameObject guess1GO, guess2GO, guess3GO, face1GO, face2GO, face3GO, option1GO, option2GO, option3GO;

    private void Update()
    {
        if (showGuess1)
        {
            face1GO.transform.Rotate(0, 180, 0);
            guess1GO.SetActive(showGuess1);
            option1GO.SetActive(true);
            option2GO.SetActive(true);
            option3GO.SetActive(true);
            showGuess1 = false;
        }
        if (showGuess2)
        {
            face2GO.transform.Rotate(0, 180, 0);
            guess2GO.SetActive(showGuess2);
            showGuess2 = false;
        }
        if (showGuess1)
        {
            face3GO.transform.Rotate(0, 180, 0);
            guess3GO.SetActive(showGuess3);
            showGuess3 = false;
        }
    }

}
