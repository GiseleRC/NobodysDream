using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle3 : MonoBehaviour
{
    private Vector3 position1;
    private Vector3 position2;
    private Vector3 position3;
    public bool showGuess1, showGuess2, showGuess3, option1, option2, option3;
    private int currGuess = 0;
    public GameObject guess1GO, guess2GO, guess3GO, nose1Particle, nose2Particle, nose3Particle, nose1GO, nose2GO, nose3GO,
                      option1GO, option2GO, option3GO, option4GO, option5GO, option6GO, option7GO, option8GO, option9GO, ajedrezGO1, point2, point3;

    private void Start()
    {
        position1 = ajedrezGO1.transform.position;
        position2 = point2.transform.position;
        position3 = point3.transform.position;
    }
    private void Update()
    {
        if (showGuess1)
        {
            guess1GO.SetActive(true);
            option1GO.SetActive(true);
            option2GO.SetActive(true);
            option3GO.SetActive(true);

            nose1GO.GetComponent<Collider>().enabled = false;
            nose2GO.GetComponent<Collider>().enabled = false;
            nose3GO.GetComponent<Collider>().enabled = false;

            currGuess = 1;
            showGuess1 = false;
        }

        if (option1 && currGuess == 1)
        {
            option1GO.SetActive(false);
            option1 = false;
        }
        else if (option2 && currGuess == 1)
        {
            option2GO.SetActive(false);
            option2 = false;
        }
        else if (option3 && currGuess == 1)
        {
            option3GO.SetActive(false);
            option2GO.SetActive(false);
            option1GO.SetActive(false);
            guess1GO.SetActive(false);
            position1 = new Vector3(position1.x, 2f, position1.z);
            ajedrezGO1.transform.position = position1;

            nose1GO.GetComponent<Collider>().enabled = true;
            nose2GO.GetComponent<Collider>().enabled = true;
            nose3GO.GetComponent<Collider>().enabled = true;

            option3 = false;
        }


        if (showGuess2)
        {
            guess2GO.SetActive(true);
            option4GO.SetActive(true);
            option5GO.SetActive(true);
            option6GO.SetActive(true);

            nose1GO.GetComponent<Collider>().enabled = false;
            nose2GO.GetComponent<Collider>().enabled = false;
            nose3GO.GetComponent<Collider>().enabled = false;

            currGuess = 2;
            showGuess2 = false;
        }

        if (option1 && currGuess == 2)
        {
            option4GO.SetActive(false);
            option1 = false;
        }
        else if (option2 && currGuess == 2)
        {
            option4GO.SetActive(false);
            option5GO.SetActive(false);
            option6GO.SetActive(false);
            guess2GO.SetActive(false);

            ajedrezGO1.transform.position = position2;

            nose1GO.GetComponent<Collider>().enabled = true;
            nose2GO.GetComponent<Collider>().enabled = true;
            nose3GO.GetComponent<Collider>().enabled = true;

            option2 = false;
        }
        else if (option3 && currGuess == 2)
        {
            option6GO.SetActive(false);

            option3 = false;
        }


        if (showGuess3)
        {
            guess3GO.SetActive(true);
            option7GO.SetActive(true);
            option8GO.SetActive(true);
            option9GO.SetActive(true);

            nose1GO.GetComponent<Collider>().enabled = false;
            nose2GO.GetComponent<Collider>().enabled = false;
            nose3GO.GetComponent<Collider>().enabled = false;

            currGuess = 3;
            showGuess3 = false;
        }

        if (option1 && currGuess == 3)
        {
            option7GO.SetActive(false);
            option1 = false;
        }
        else if (option2 && currGuess == 3)
        {
            option8GO.SetActive(false);
            option2 = false;
        }
        else if (option3 && currGuess == 3)
        {
            option7GO.SetActive(false);
            option8GO.SetActive(false);
            option9GO.SetActive(false);
            guess3GO.SetActive(false);
            ajedrezGO1.transform.position = position3;

            nose1GO.GetComponent<Collider>().enabled = true;
            nose2GO.GetComponent<Collider>().enabled = true;
            nose3GO.GetComponent<Collider>().enabled = true;

            option3 = false;
        }
    }
}
