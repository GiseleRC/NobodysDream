using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialPaperSC : MonoBehaviour
{

    public bool showPaper = false;
    public float fillAmount = 1f;
    public float EmptyAmount = 1f;
    public Image paperTutorial;

    public AudioSource OpenTutorial, CloseTutorial;

    void Update()
    {
        ShowPaper(showPaper);

        if (Input.GetButtonDown("Cancel") && showPaper == true)
        {
            showPaper = false;
            paperTutorial.fillAmount -= EmptyAmount * Time.deltaTime;
            CloseTutorial.Play();
        }
    }


    public void ShowPaper(bool show)
    {
        if (show)
        {
            OpenTutorial.Play();
            paperTutorial.fillAmount += fillAmount * Time.deltaTime;
        }
    }
}
