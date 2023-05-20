using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialPaperSC : MonoBehaviour
{

    public bool showPaper = false;
    public bool showTutorialMat = false;
    public bool showTutorialGlasses = false;
    public bool showTutorialBall = false;
    public float fillAmount = 1f;
    public Image tutorialFlashligth, tutorialMaterialized, tutorialGlasses, tutorialBall;

    public AudioSource closeTutorial;

    void Update()
    {
        TutorialFlashligth(showPaper);
        TutorialMaterialized(showTutorialMat);
        TutorialGlasses(showTutorialGlasses);
        TutorialBall(showTutorialBall);

        if (Input.GetButtonDown("CancelTutorial&Pause") && showPaper == true)
        {
            closeTutorial.Play();
            showPaper = false;
        }
        else if (Input.GetButtonDown("CancelTutorial&Pause") && showTutorialMat == true)
        {
            closeTutorial.Play();
            showTutorialMat = false;
        }
        else if (Input.GetButtonDown("CancelTutorial&Pause") && showTutorialGlasses == true)
        {
            closeTutorial.Play();
            showTutorialGlasses = false;
        }
        else if (Input.GetButtonDown("CancelTutorial&Pause") && showTutorialBall == true)
        {
            closeTutorial.Play();
            showTutorialBall = false;
        }
    }
    public void TutorialFlashligth(bool show)
    {
        if (show)
        {
            tutorialFlashligth.fillAmount += fillAmount * Time.deltaTime;
        }
        else
        {
            tutorialFlashligth.fillAmount -= fillAmount * Time.deltaTime;
        }
    }
    public void TutorialMaterialized(bool show)
    {
        if (show)
        {
            tutorialMaterialized.fillAmount += fillAmount * Time.deltaTime;
        }
        else
        {
            tutorialMaterialized.fillAmount -= fillAmount * Time.deltaTime;
        }
    }
    public void TutorialGlasses(bool show)
    {
        if (show)
        {
            tutorialGlasses.fillAmount += fillAmount * Time.deltaTime;
        }
        else
        {
            tutorialGlasses.fillAmount -= fillAmount * Time.deltaTime;
        }
    }
    public void TutorialBall(bool show)
    {
        if (show)
        {
            tutorialBall.fillAmount += fillAmount * Time.deltaTime;
        }
        else
        {
            tutorialBall.fillAmount -= fillAmount * Time.deltaTime;
        }
    }
}
