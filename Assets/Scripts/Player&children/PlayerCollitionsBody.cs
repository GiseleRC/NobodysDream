using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollitionsBody : MonoBehaviour
{
    public GameState gameState;
    public FlashLight flashLightSC;
    public TimerController timerController;
    public TutorialPaperSC tutorialPaperBool;
    public GameObject glasses, map, flashLigthArm, cap, flashLightPick, door, level2Enable, IconFantasma;
    [SerializeField] private Collider glassesC, mapC, flashLightC, capC, boosterC;
    public AudioSource openTutorial, PickUp;

    private void OnTriggerEnter(Collider other)//hacerlo switch
    {
        if (other == flashLightC)
        {
            openTutorial.Play();
            tutorialPaperBool.showPaper = true;
            flashLightSC.hasFlashlight = true;
            flashLigthArm.SetActive(true);//brazo
            flashLightPick.SetActive(false);//brazo
            cap.SetActive(true);
            PickUp.Play();
        }
        if (other == capC)
        {
            cap.SetActive(false);
            door.SetActive(true);
            tutorialPaperBool.showTutorialMat = true;
            gameObject.GetComponent<MaterializeObjects>().enabled = true;
            PickUp.Play();
        }

        if (other == glassesC)
        {
            gameState.GhostPlaneModeEnabled = true;
            glasses.SetActive(false);
            IconFantasma.SetActive(true);
            level2Enable.SetActive(true);
            map.SetActive(true);
            PickUp.Play();
        }
        if (other == mapC)
        {
            map.SetActive(false);
            //gameState.DemonPlaneModeEnabled = true;
            PickUp.Play();
        }
        if (other.name == "zZz")
        {
            other.gameObject.SetActive(false);
            timerController.pickBooster = true;
            PickUp.Play();
        }
    }
}
