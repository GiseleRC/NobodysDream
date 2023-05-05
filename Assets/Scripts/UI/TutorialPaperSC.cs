using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialPaperSC : MonoBehaviour
{

    public bool showPaper = false;
    public bool showTutorialMat = false;
    public float fillAmount = 1f;
    public Image paperTutorial, tutorialMaterialized;

    public AudioSource closeTutorial;

    void Update()
    {
        TutorialFlashligth(showPaper);
        TutorialMaterialized(showTutorialMat);

        if (Input.GetButtonDown("Cancel") && showPaper == true)
        {
            closeTutorial.Play();
            showPaper = false;
        }
        if (Input.GetButtonDown("Cancel") && showTutorialMat == true)
        {
            closeTutorial.Play();
            showTutorialMat = false;
        }
    }
    public void TutorialFlashligth(bool show)
    {
        if (show)
        {
            paperTutorial.fillAmount += fillAmount * Time.deltaTime;
        }
        else
        {
            paperTutorial.fillAmount -= fillAmount * Time.deltaTime;
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
}
