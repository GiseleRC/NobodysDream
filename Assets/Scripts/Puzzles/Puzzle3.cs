using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle3 : MonoBehaviour
{
    public bool showGuess1 = false;
    public bool showGuess2 = false;
    public bool showGuess3 = false;
    public GameObject guess1GO, guess2GO, guess3GO, option1GO, option2GO, option3GO;

    private void Update()
    {
        if (showGuess1)
        {
            guess1GO.SetActive(showGuess1);
            option1GO.SetActive(true);
            option2GO.SetActive(true);
            option3GO.SetActive(true);
        }
        if (showGuess2)
        {
            //guess2GO.SetActive(showGuess2);
            //option1GO.SetActive(true);
            //option2GO.SetActive(true);
            //option3GO.SetActive(true);
        }
        if (showGuess3)
        {
            //guess3GO.SetActive(showGuess3);
            //option1GO.SetActive(true);
            //option2GO.SetActive(true);
            //option3GO.SetActive(true);
        }
    }

}
