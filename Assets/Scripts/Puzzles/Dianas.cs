using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dianas : MonoBehaviour
{
    public Puzzle2 puzzle2;
    public Puzzle3 puzzle3;

    public GameObject currGO;
    public TimerController timerController;
    public AudioSource audioSource;
    private float timeWait = 1f;
    private bool startCount = false;

    private void Update()
    {
        if (startCount)
        {
            timeWait -= Time.deltaTime;
        }
        if (timeWait <= 0f)
        {
            currGO.SetActive(false);
            startCount = false;
            timeWait = 1f;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Ball(Clone)")
        {
            if (gameObject.name == "Practica1")
            {
                puzzle2.practice1 = true;
                currGO = gameObject;
            }
            if (gameObject.name == "Practica2")
            {
                puzzle2.practice2 = true;
                currGO = gameObject;
            }
            if (gameObject.name == "Practica3")
            {
                puzzle2.practice3 = true;
                currGO = gameObject;
            }
            audioSource.Play();
            startCount = true;
        }
    }
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
            }
            if (gameObject.name == "Nose2")
            {
                puzzle3.showGuess2 = true;
            }
            if (gameObject.name == "Nose3")
            {
                puzzle3.showGuess3 = true;
            }

            if (gameObject.name == "Option1")
            {
                if (puzzle3.showGuess1)
                {
                    puzzle3.option1 = true;
                    timerController.AddTime(-50f);
                }
                else if (puzzle3.showGuess2)
                {
                    puzzle3.option1 = true;
                    timerController.AddTime(-50f);
                }
                else if (puzzle3.showGuess3)
                {
                    puzzle3.option1 = true;
                    timerController.AddTime(-50f);
                }
            }
            if (gameObject.name == "Option2")
            {
                if (puzzle3.showGuess1)
                {
                    puzzle3.option2 = true;
                    timerController.AddTime(-50f);
                }
                else if (puzzle3.showGuess2)
                {
                    puzzle3.option2 = true;
                    timerController.AddTime(+50f);
                }
                else if (puzzle3.showGuess3)
                {
                    puzzle3.option2 = true;
                    timerController.AddTime(-50f);
                }
            }
            if (gameObject.name == "Option3")
            {
                if (puzzle3.showGuess1)
                {
                    puzzle3.option3 = true;
                    timerController.AddTime(+50f);
                }
                if (puzzle3.showGuess2)
                {
                    puzzle3.option3 = true;
                    timerController.AddTime(-50f);
                }
                if (puzzle3.showGuess3)
                {
                    puzzle3.option3 = true;
                    timerController.AddTime(+50f);
                }
            }
        }
    }
}
