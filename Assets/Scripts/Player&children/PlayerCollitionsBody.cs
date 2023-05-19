using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollitionsBody : MonoBehaviour
{
    public GameState gameState;
    public FlashLight flashLightSC;
    public TimerController timerController;
    public TutorialPaperSC tutorialPaperBool;
    public GameObject glasses, map, flashLigthArm, cap, flashLightPick, door, level2Enable, IconFantasma, level1Enable, ballBucket,IconFantasmaLinterna;
    [SerializeField] private Collider glassesC, mapC, flashLightC, capC, boosterC;
    public AudioSource openTutorial, PickUp;
    public bool ballEnable = false;
    public bool canMaterialized = false;

    private void OnTriggerEnter(Collider other)//hacerlo switch
    {
        if (other == flashLightC)
        {
            //openTutorial.Play();
            tutorialPaperBool.showPaper = true;
            flashLightSC.hasFlashlight = true;
            flashLigthArm.SetActive(true);//brazo
            flashLightPick.SetActive(false);//brazo
            IconFantasmaLinterna.SetActive(true);
            cap.SetActive(true);
            PickUp.Play();
        }
        else if (other == capC)
        {
            cap.SetActive(false);
            door.SetActive(true);
            tutorialPaperBool.showTutorialMat = true;
            canMaterialized = true;
            PickUp.Play();
        }
        else if (other == glassesC)
        {
            gameState.GhostPlaneModeEnabled = true;
            tutorialPaperBool.showTutorialGlasses = true;
            glasses.SetActive(false);
            IconFantasma.SetActive(true);
            level2Enable.SetActive(true);
            map.SetActive(true);
            PickUp.Play();
        }
        else if (other == mapC)
        {
            map.SetActive(false);
            //gameState.DemonPlaneModeEnabled = true;
            PickUp.Play();
        }
        else if (other.name == "zZz")
        {
            other.gameObject.SetActive(false);
            timerController.pickBooster = true;
            PickUp.Play();
        }
        else if (other.name == "SabanaLvl1Off")
        {
            level1Enable.SetActive(false);
        }
        else if (other.name == "BallBucket" && GetComponent<PlayerSC>().canThrowBall)
        {
            GetComponent<PlayerSC>().PickupBalls();
            GetComponent<PlayerSC>().ballInHand = true;
        }
        else if (other.name == "BallPickable")
        {
            ballEnable = true;
            ballBucket.SetActive(true);
            other.gameObject.SetActive(false);
            tutorialPaperBool.showTutorialBall = true;
            PickUp.Play();
        }
    }
}
