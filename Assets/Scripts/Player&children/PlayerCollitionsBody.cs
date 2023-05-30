using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollitionsBody : MonoBehaviour
{
    public GameState gameState;
    public FlashLight flashLightSC;
    public TimerController timerController;
    public TutorialPaperSC tutorialPaperBool;
    public GameObject light1, light2, light3, bookEnableUIGO, lightBed, glassesGO, flashLigthArm, flashLightPickGO, cap, door, level2Enable, IconFantasma, level1Enable, ballBucket, IconFantasmaLinterna, flashLigthUI, rullerPick, collectPickeable;
    [SerializeField] private Collider capC, boosterC;
    public AudioSource openTutorial, pickUp, booster;
    public bool ballEnable = false;
    public bool iHaveCap = false;
    private bool objEnable = false;
    private bool capEnable = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Model&Collider" && !tutorialPaperBool.anyTutorialOpen)
        {
            tutorialPaperBool.showTuturialFlash = true;//booleano del Script tutorial LINTERNA
            flashLightSC.hasFlashlight = true;//booleano del Script flashligth
            tutorialPaperBool.anyTutorialOpen = true;

            flashLightPickGO.SetActive(false);//linterna pickeable
            flashLigthUI.SetActive(true);//UI de linterna
            flashLigthArm.SetActive(true);//linterna del brazo
            rullerPick.SetActive(true);//Se activa RULLER

            pickUp.Play();//Sonido de PICKEABLE
        }
        else if (other.name == "Boina")
        {
            //tutorialPaperBool.showGuideTutorialPlane = true;//booleano del Script guia de tutoriales BOINA/MODO
            capEnable = true;

            cap.SetActive(false);//Se desactiva boina
            flashLightPickGO.SetActive(true);//Se activa la LINTERNA
            IconFantasmaLinterna.SetActive(true);//UI de PLANE DREAM

            pickUp.Play();//Sonido de PICKEABLE
        }
        else if (other.name == "RulerPickeable" && !tutorialPaperBool.anyTutorialOpen)
        {
            tutorialPaperBool.showTutorialMat1 = true;//booleano del Script tutorial REGLA
            objEnable = true;//booleano para I HAVE CAP
            tutorialPaperBool.anyTutorialOpen = true;

            other.gameObject.SetActive(false);//ruller pickeable
            light2.SetActive(false);//Se activa puerta
            light3.SetActive(false);//Se activa puerta
            lightBed.SetActive(false);
            door.SetActive(true);//Se activa puerta
            light1.SetActive(true);//Se activa puerta

            pickUp.Play();//Sonido de PICKEABLE
        }
        else if (other.name == "Glasses" && !tutorialPaperBool.anyTutorialOpen)
        {
            tutorialPaperBool.showTutorialGlasses = true;//booleano del Script tutorial ANTEOJOS
            gameState.GhostPlaneModeEnabled = true;//Activa PLANE GHOST

            glassesGO.SetActive(false);//anteojos pickeable
            IconFantasma.SetActive(true);//UI PLANE GHOST
            level2Enable.SetActive(true);//Se activa LEVEL2

            pickUp.Play();//Sonido de PICKEABLE
        }
        else if (other.name == "zZz")
        {
            timerController.AddTime(50f);

            Instantiate(collectPickeable, other.gameObject.transform.position + transform.forward * 2f, other.gameObject.transform.rotation);
            other.gameObject.SetActive(false);//Booster pickeable

            booster.Play();//Sonido de PICKEABLE
        }
        else if (other.name == "SabanaLvl1Off")
        {
            level1Enable.SetActive(false);
        }
        else if (other.name == "BallBucket" && GetComponent<PlayerSC>().canThrowBall)
        {
            GetComponent<PlayerSC>().PickupBalls();
            GetComponent<PlayerSC>().ballInHand = true;
            pickUp.Play();
        }
        else if (other.name == "BallPickable" && !tutorialPaperBool.anyTutorialOpen)
        {
            ballEnable = true;
            ballBucket.SetActive(true);
            other.gameObject.SetActive(false);
            tutorialPaperBool.showTutorialBall = true;
            pickUp.Play();
        }
        else if (other.name == "BookEnableUI")
        {
            other.gameObject.SetActive(false);
            bookEnableUIGO.SetActive(true);
            pickUp.Play();
        }
    }

    private void Update()
    {
        if (objEnable && capEnable)
        {
            iHaveCap = true;//booleano cuando tiene la gorra
            capEnable = false;
        }
    }
}
