using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialPaperSC : MonoBehaviour
{

    public bool showTuturialFlash = false;
    public bool showTutorialGlasses = false;
    public bool showTutorialBall = false;
    public bool showTutorialCube = false;
    public bool showTutorialRuller = false;
    public bool showGuideTutorialPlane = false;
    public float fillAmount = 1f;
    public Image tutorialFlashligth, tutorialGlasses, tutorialBall, tutorialCube, tutorialRuller/*, guideTutorialPlane*/;

    public AudioSource closeTutorial;

    void Update()
    {
        TutorialFlashligth(showTuturialFlash);
        //GuideTutorialPlane(showGuideTutorialPlane);
        TutorialRuller(showTutorialRuller);
        TutorialCube(showTutorialCube);
        TutorialGlasses(showTutorialGlasses);
        TutorialBall(showTutorialBall);

        if (Input.GetButtonDown("Escape") && showTuturialFlash == true)
        {
            closeTutorial.Play();
            showTuturialFlash = false;
        }
        else if (Input.GetButtonDown("Escape") && showTutorialGlasses == true)
        {
            closeTutorial.Play();
            showTutorialGlasses = false;
        }
        else if (Input.GetButtonDown("Escape") && showTutorialBall == true)
        {
            closeTutorial.Play();
            showTutorialBall = false;
        }
        else if (Input.GetButtonDown("Escape") && showGuideTutorialPlane == true)// falta guia de boina
        {
            closeTutorial.Play();
            showGuideTutorialPlane = false;
        }
        else if (Input.GetButtonDown("Escape") && showTutorialRuller == true)
        {
            closeTutorial.Play();
            showTutorialRuller = false;
        }
        else if (Input.GetButtonDown("Escape") && showTutorialCube == true)
        {
            closeTutorial.Play();
            showTutorialCube = false;
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
        }
        else
        {
            //guideTutorialPlane.fillAmount -= fillAmount * Time.deltaTime;// falta guia de boina
        }
    }
    public void TutorialRuller(bool show)
    {
        if (show)
        {
            tutorialRuller.fillAmount += fillAmount * Time.deltaTime;
        }
        else
        {
            tutorialRuller.fillAmount -= fillAmount * Time.deltaTime;
        }
    }
    public void TutorialCube(bool show)
    {
        if (show)
        {
            tutorialCube.fillAmount += fillAmount * Time.deltaTime;
        }
        else
        {
            tutorialCube.fillAmount -= fillAmount * Time.deltaTime;
        }
    }
}
