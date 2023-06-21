using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClownsCollition : MonoBehaviour
{
    public Puzzle3 puzzle3;
    public GameObject rudolfClown, rudolfHorse;

    public AudioSource NoseSound;

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Ball(Clone)")
        {
            if (gameObject.name == "Nose1")
            {
                puzzle3.showGuess1 = true;
                NoseSound.Play();
            }
            else if (gameObject.name == "Nose2")
            {
                puzzle3.showGuess2 = true;
                NoseSound.Play();
            }
            else if (gameObject.name == "Nose3")
            {
                puzzle3.showGuess3 = true;
                NoseSound.Play();
            }

            if (gameObject.name == "Option1" || gameObject.name == "Option4" || gameObject.name == "Option7")
            {
                puzzle3.option1 = true;
                gameObject.SetActive(false);
            }
            if (gameObject.name == "Option2" || gameObject.name == "Option5" || gameObject.name == "Option8")
            {
                puzzle3.option2 = true;
                gameObject.SetActive(false);
            }
            if (gameObject.name == "Option3" || gameObject.name == "Option6" || gameObject.name == "Option9")
            {
                puzzle3.option3 = true;
                gameObject.SetActive(false);
            }
            if (gameObject.name == "Rudolf")
            {
                rudolfClown.SetActive(true);//hermanito
                rudolfHorse.SetActive(false);//caballo
                gameObject.SetActive(false);//nariz
            }
        }
    }

    private void Update()
    {

    }
}
