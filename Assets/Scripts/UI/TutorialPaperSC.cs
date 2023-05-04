using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialPaperSC : MonoBehaviour
{

    public bool showPaper = false;
    public float fillAmount = 1f;
    public Image paperTutorial;

    public AudioSource closeTutorial;

    void Update()
    {
        ShowPaper(showPaper);

        if (Input.GetButtonDown("Cancel") && showPaper == true)
        {
            closeTutorial.Play();
            paperTutorial.fillAmount -= fillAmount * Time.deltaTime;
            if (paperTutorial.fillAmount <= 0 )
            {
                paperTutorial.fillAmount = 0;
                showPaper = false;

            }
        }
    }
    public void ShowPaper(bool show)
    {
        if (show)
        {
            paperTutorial.fillAmount += fillAmount * Time.deltaTime;
        }
    }
}
