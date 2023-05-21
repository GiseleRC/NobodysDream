using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollitionsBody : MonoBehaviour
{
    public GameState gameState;
    public FlashLight flashLightSC;
    public TimerController timerController;
    public TutorialPaperSC tutorialPaperBool;
    public GameObject glassesGO, flashLigthArm, flashLightPickGO, cap, door, level2Enable, IconFantasma, level1Enable, ballBucket, IconFantasmaLinterna, flashLigthUI, rullerPick, cubePick;
    [SerializeField] private Collider capC, boosterC;
    public AudioSource openTutorial, pickUp, booster;
    public bool ballEnable = false;
    public bool iHaveCap = false;
    private bool rullerEnable = false;
    private bool cubeEnable = false;
    private bool capEnable = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Model&Collider")
        {
            tutorialPaperBool.showTuturialFlash = true;//booleano del Script tutorial LINTERNA
            flashLightSC.hasFlashlight = true;//booleano del Script flashligth

            flashLightPickGO.SetActive(false);//linterna pickeable
            flashLigthUI.SetActive(true);//UI de linterna
            flashLigthArm.SetActive(true);//linterna del brazo
            cap.SetActive(true);//Se activa boina

            pickUp.Play();//Sonido de PICKEABLE
        }
        else if (other.name == "Boina")
        {
            //tutorialPaperBool.showGuideTutorialPlane = true;//booleano del Script guia de tutoriales BOINA/MODO
            capEnable = true;

            cap.SetActive(false);//Se desactiva boina
            rullerPick.SetActive(true);//Se activa RULLER
            cubePick.SetActive(true);//Se activa CUBE
            door.SetActive(true);//Se activa puerta
            IconFantasmaLinterna.SetActive(true);//UI de PLANE DREAM

            pickUp.Play();//Sonido de PICKEABLE
        }
        else if (other.name == "RulerPickeable")
        {
            tutorialPaperBool.showTutorialRuller = true;//booleano del Script tutorial REGLA
            rullerEnable = true;//booleano para I HAVE CAP

            other.gameObject.SetActive(false);//ruller pickeable

            pickUp.Play();//Sonido de PICKEABLE
        }
        else if (other.name == "CubePickeable")
        {
            tutorialPaperBool.showTutorialCube = true;//booleano del Script tutorial CUBO
            cubeEnable = true;//booleano para I HAVE CAP

            other.gameObject.SetActive(false);//cube pickeable

            pickUp.Play();//Sonido de PICKEABLE
        }
        else if (other.name == "Glasses")
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
            timerController.pickBooster = true;//booleano del Script TimerController

            other.gameObject.SetActive(false);//Booster pickeable

            booster.Play();//Sonido de PICKEABLE
        }
        else if (other.name == "SabanaLvl1Off")
        {
            level1Enable.SetActive(false);//--------------------------no se esta aplicando
        }
        else if (other.name == "BallBucket" && GetComponent<PlayerSC>().canThrowBall)
        {
            GetComponent<PlayerSC>().PickupBalls();
            GetComponent<PlayerSC>().ballInHand = true;
            pickUp.Play();
        }
        else if (other.name == "BallPickable")
        {
            ballEnable = true;
            ballBucket.SetActive(true);
            other.gameObject.SetActive(false);
            tutorialPaperBool.showTutorialBall = true;
            pickUp.Play();
        }
    }

    private void Update()
    {
        if (rullerEnable && cubeEnable && capEnable)
        {
            iHaveCap = true;//booleano cuando tiene la gorra
            capEnable = false;
        }
    }
}
