using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialPaperSC : MonoBehaviour
{
    public bool anyTutorialOpen = false;
    public bool showTuturialFlash = false;
    public bool showTutorialGlasses = false;
    public bool showTutorialBall = false;
    public bool showTutorialMat2 = false;
    public bool tutorialMat2Finishing = false;
    public bool showTutorialMat1 = false;
    public bool showGuideTutorialPlane = false;
    private bool nextTutorial = false;
    private float timeDelay = 0.5f;
    public float fillAmount = 1f;
    public DialogSystem dialogS;
    public Image tutorialFlashligth, tutorialGlasses, tutorialBall, tutorialMat2, tutorialMat1/*, guideTutorialPlane*/;

    public AudioSource closeTutorial;

    void Update()
    {
        TutorialFlashligth(showTuturialFlash);
        //GuideTutorialPlane(showGuideTutorialPlane);
        TutorialMaterialized1(showTutorialMat1);
        TutorialGlasses(showTutorialGlasses);
        TutorialBall(showTutorialBall);
        TutorialMaterialized2(showTutorialMat2);

        if (Input.GetButtonDown("CancelMat") && showTuturialFlash == true)
        {
            closeTutorial.Play();
            showTuturialFlash = false;
            anyTutorialOpen = false;
            dialogS.flashlB = true;
        }
        else if (Input.GetButtonDown("CancelMat") && showTutorialGlasses == true)
        {
            closeTutorial.Play();
            showTutorialGlasses = false;
            anyTutorialOpen = false;
        }
        else if (Input.GetButtonDown("CancelMat") && showTutorialBall == true)
        {
            closeTutorial.Play();
            showTutorialBall = false;
            anyTutorialOpen = false;
        }
        else if (Input.GetButtonDown("CancelMat") && showGuideTutorialPlane == true)// falta guia de boina
        {
            closeTutorial.Play();
            showGuideTutorialPlane = false;
        }
        else if (Input.GetButtonDown("CancelMat") && showTutorialMat1 == true)
        {
            closeTutorial.Play();
            showTutorialMat1 = false;
            nextTutorial = true;
        }
        else if (Input.GetButtonDown("CancelMat") && showTutorialMat2 == true)
        {
            closeTutorial.Play();
            showTutorialMat2 = false;
            tutorialMat2Finishing = true;
            anyTutorialOpen = false;
            dialogS.rullerB= true;
        }

        if (nextTutorial)
        {
            timeDelay -= Time.deltaTime;
            if (timeDelay <= 0f)
            {
                showTutorialMat2 = true;
                nextTutorial = false;
                timeDelay = 2f;
            }
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
    public void GuideTutorialPlane(bool show)
    {
        if (show)
        {
            //guideTutorialPlane.fillAmount += fillAmount * Time.deltaTime;// falta guia de boina
            //anyTutorialOpen = true;
        }
        else
        {
            //guideTutorialPlane.fillAmount -= fillAmount * Time.deltaTime;// falta guia de boina
        }
    }
    public void TutorialMaterialized1(bool show)
    {
        if (show)
        {
            tutorialMat1.fillAmount += fillAmount * Time.deltaTime;
        }
        else
        {
            tutorialMat1.fillAmount -= fillAmount * Time.deltaTime;
        }
    }
    public void TutorialMaterialized2(bool show)
    {
        if (show)
        {
            tutorialMat2.fillAmount += fillAmount * Time.deltaTime;
        }
        else
        {
            tutorialMat2.fillAmount -= fillAmount * Time.deltaTime;
        }
    }
}
