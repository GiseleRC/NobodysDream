using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialPaperSC : MonoBehaviour
{
    public bool showPaper = false;
    public float fillAmount = 1f;
    public Image paperTutorial;

    void Update()
    {
        ShowPaper(showPaper);
    }

    public void ShowPaper(bool show)
    {
        if (show)
        {
            paperTutorial.fillAmount += fillAmount * Time.deltaTime;
        }
    }
}
