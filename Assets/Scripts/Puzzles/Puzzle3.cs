using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle3 : MonoBehaviour
{
    private Vector3 position1;
    private Vector3 position2;
    private Vector3 position3;
    public TimerController timerController;
    public bool showGuess1, showGuess2, showGuess3, option1, option2, option3;
    private int currGuess = 0;
    public GameObject guess1GO, guess2GO, guess3GO, nose1Particle, nose2Particle, nose3Particle, nose1GO, nose2GO, nose3GO,
                      option1GO, option2GO, option3GO, option4GO, option5GO, option6GO, option7GO, option8GO, option9GO, ajedrezGO1, face1GO, face2GO, face3GO, finalGO;

    private void Start()
    {
        position1 = ajedrezGO1.transform.position;
    }
    private void Update()
    {
        if (showGuess1)
        {
            guess1GO.SetActive(true);
            option1GO.SetActive(true);
            option2GO.SetActive(true);
            option3GO.SetActive(true);
            nose1Particle.SetActive(false);

            face1GO.GetComponent<Wheel>().enabled = true;
            nose1GO.GetComponent<Collider>().enabled = false;

            currGuess = 1;
            showGuess1 = false;
        }
        if (option1 && currGuess == 1)
        {
            option1 = false;
            timerController.AddTime(-50f);
        }
        else if (option2 && currGuess == 1)
        {
            option2 = false;
            timerController.AddTime(-50f);
        }
        else if (option3 && currGuess == 1)
        {
            option2GO.SetActive(false);
            option1GO.SetActive(false);
            guess1GO.SetActive(false);
            nose2Particle.SetActive(true);

            position1 = new Vector3(position1.x, 2f, position1.z);
            ajedrezGO1.transform.position = position1;

            option3 = false;
            timerController.AddTime(+50f);

            nose2GO.GetComponent<Collider>().enabled = true;
        }

        if (showGuess2)
        {
            guess2GO.SetActive(true);
            option4GO.SetActive(true);
            option5GO.SetActive(true);
            option6GO.SetActive(true);
            nose2Particle.SetActive(false);

            nose2GO.GetComponent<Collider>().enabled = false;

            currGuess = 2;
            showGuess2 = false;
        }
        if (option1 && currGuess == 2)
        {
            option1 = false;
            timerController.AddTime(-50f);
        }
        else if (option2 && currGuess == 2)
        {
            guess2GO.SetActive(false);
            option4GO.SetActive(false);
            option5GO.SetActive(false);
            option6GO.SetActive(false);
            nose3Particle.SetActive(true);

            position1 = new Vector3(position1.x, position1.y -= 2f, position1.z);
            ajedrezGO1.transform.position = position1;

            option2 = false;
            timerController.AddTime(+50f);

            nose3GO.GetComponent<Collider>().enabled = true;
        }
        else if (option3 && currGuess == 2)
        {
            option3 = false;
            timerController.AddTime(-50f);
        }

        if (showGuess3)
        {
            guess3GO.SetActive(true);
            option7GO.SetActive(true);
            option8GO.SetActive(true);
            option9GO.SetActive(true);
            nose3Particle.SetActive(false);

            nose3GO.GetComponent<Collider>().enabled = false;

            currGuess = 3;
            showGuess3 = false;
        }
        if (option1 && currGuess == 3)
        {
            option1 = false;
            timerController.AddTime(-50f);
        }
        else if (option2 && currGuess == 3)
        {
            option2 = false;
            timerController.AddTime(-50f);
        }
        else if (option3 && currGuess == 3)
        {
            option7GO.SetActive(false);
            option8GO.SetActive(false);
            option9GO.SetActive(false);
            guess3GO.SetActive(false);
            finalGO.SetActive(true);

            position1 = new Vector3(position1.x, position1.y -= 2f, position1.z);
            ajedrezGO1.transform.position = position1;

            option3 = false;
            timerController.AddTime(+50f);
        }

        if (face1GO.transform.rotation.y <= 0.61f)
        {
            face1GO.GetComponent<Wheel>().enabled = false;
        }
        else if (face2GO.transform.rotation.y <= 0.50f)
        {
            face2GO.GetComponent<Wheel>().enabled = false;
        }
        else if (face3GO.transform.rotation.y <= 0.50f)
        {
            face3GO.GetComponent<Wheel>().enabled = false;
        }
    }
}