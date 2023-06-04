using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dianas : MonoBehaviour
{
    public Puzzle2 puzzle2;
    public Puzzle3 puzzle3;
    private Vector3 position1;
    public GameObject tabGO, facesGO1, facesGO2, facesGO3, facesGO1A, facesGO2A, facesGO3A, currGO;
    public TimerController timerController;
    public AudioSource audioSource;
    private float timeWait = 1f;
    private bool startCount = false;

    private void Start()
    {
        position1 = tabGO.transform.position;
    }

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
                facesGO1.SetActive(false);
                facesGO1A.SetActive(true);
            }
            if (gameObject.name == "Nose2")
            {
                puzzle3.showGuess2 = true;
                facesGO2.SetActive(false);
                facesGO2A.SetActive(true);
            }
            if (gameObject.name == "Nose3")
            {
                puzzle3.showGuess3 = true;
                facesGO3.SetActive(false);
                facesGO3A.SetActive(true);
            }

            if (gameObject.name == "Option1")
            {
                puzzle3.option1GO.SetActive(false);
                timerController.AddTime(-100f);
            }
            if (gameObject.name == "Option2")
            {
                puzzle3.option2GO.SetActive(false);
                timerController.AddTime(-100f);
            }
            if (gameObject.name == "Option3")
            {
                puzzle3.option3GO.SetActive(false);
                puzzle3.option2GO.SetActive(false);
                puzzle3.option1GO.SetActive(false);
                puzzle3.guess1GO.SetActive(false);
                position1 = new Vector3(position1.x, 2f, position1.z);
                tabGO.transform.position = position1;
            }
        }
    }
}
