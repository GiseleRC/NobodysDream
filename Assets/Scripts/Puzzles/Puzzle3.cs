using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle3 : MonoBehaviour
{
    public bool showGuess1 = false;
    public bool showGuess2 = false;
    public bool showGuess3 = false;
    public GameObject guess1GO, guess2GO, guess3GO;

    private void Update()
    {
        if (showGuess1)
        {
            guess1GO.SetActive(showGuess1);
            showGuess1 = false;
        }
        if (showGuess2)
        {
            guess2GO.SetActive(showGuess2);
            showGuess2 = false;
        }
        if (showGuess1)
        {
            guess3GO.SetActive(showGuess3);
            showGuess3 = false;
        }
    }

}
