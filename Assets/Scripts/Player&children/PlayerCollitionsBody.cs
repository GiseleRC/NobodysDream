using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollitionsBody : MonoBehaviour
{
    public Animator reloj;
    public GameState gameState;
    public FlashLight flashLightSC;
    public TimerController timerController;
    public TutorialPaperSC tutorialPaperBool;
    public GameObject rubbers, canvasBallCount, ligthKaki, ligthPractice, light1, light2, light3, bookEnableUIGO, lightBed, glassesGO, flashLigthArm, flashLightPickGO, cap, door, level2Enable, IconFantasma, level1Enable, ballBucket, IconFantasmaLinterna, flashLigthUI, rullerPick, collectPickeable, interactiveButton;
    [SerializeField] private Collider capC, boosterC;
    public AudioSource openTutorial, pickUp, booster;
    public bool ballEnable = false;
    public bool justOneWhenPick = false;
    public bool iHaveCap = false;
    private bool objEnable = false;
    private bool capEnable = false;
    bool canInteractWithItem;

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Model&Collider" && !tutorialPaperBool.anyTutorialOpen)
        {
            other.transform.GetChild(0).gameObject.SetActive(true);
            canInteractWithItem = true;

        }
        else if (other.name == "Boina")
        {
            other.transform.GetChild(0).gameObject.SetActive(true);
            canInteractWithItem = true;
        }
        else if (other.name == "RulerPickeable" && !tutorialPaperBool.anyTutorialOpen)
        {
            other.transform.GetChild(2).gameObject.SetActive(true);
            canInteractWithItem = true;
        }
        else if (other.name == "Glasses" && !tutorialPaperBool.anyTutorialOpen)
        {
            other.transform.GetChild(0).gameObject.SetActive(true);
            canInteractWithItem = true;
        }
        else if (other.name == "zZz")
        {
            timerController.AddTime(15f);
            reloj.enabled = true;
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
            other.transform.GetChild(0).gameObject.SetActive(true);
            canInteractWithItem = true;
        }
        else if (other.name == "BallPickable" && !tutorialPaperBool.anyTutorialOpen)
        {
            justOneWhenPick = true;
            ballEnable = true;
            ballBucket.SetActive(true);
            canvasBallCount.SetActive(true);
            ligthPractice.SetActive(true);
            ligthKaki.SetActive(false);
            other.gameObject.SetActive(false);
            tutorialPaperBool.showTutorialBall = true;
            pickUp.Play();
        }
        else if (other.name == "BookEnableUI")
        {
            other.gameObject.SetActive(false);
            bookEnableUIGO.SetActive(true);
            rubbers.SetActive(true);
            pickUp.Play();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.name == "RulerPickeable")
        {
            if (canInteractWithItem && Input.GetButton("Interact") && !tutorialPaperBool.anyTutorialOpen)
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
        }

        if(other.name == "Boina")
        {
            if (canInteractWithItem && Input.GetButton("Interact"))
            {
                //tutorialPaperBool.showGuideTutorialPlane = true;//booleano del Script guia de tutoriales BOINA/MODO
                capEnable = true;

                cap.SetActive(false);//Se desactiva boina
                flashLightPickGO.SetActive(true);//Se activa la LINTERNA
                IconFantasmaLinterna.SetActive(true);//UI de PLANE DREAM

                pickUp.Play();//Sonido de PICKEABLE
            }
        }

        if(other.name == "Model&Collider")
        {
            if (canInteractWithItem && Input.GetButton("Interact") && !tutorialPaperBool.anyTutorialOpen)
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
        }

        if(other.name == "Glasses")
        {
            if (canInteractWithItem && Input.GetButton("Interact"))
            {
                tutorialPaperBool.showTutorialGlasses = true;//booleano del Script tutorial ANTEOJOS
                gameState.GhostPlaneModeEnabled = true;//Activa PLANE GHOST

                glassesGO.SetActive(false);//anteojos pickeable
                IconFantasma.SetActive(true);//UI PLANE GHOST
                level2Enable.SetActive(true);//Se activa LEVEL2

                pickUp.Play();//Sonido de PICKEABLE
            }
        }
        
        if(other.name == "BallBucket")
        {
            if (canInteractWithItem && Input.GetButton("Interact"))
            {
                GetComponent<PlayerSC>().PickupBalls();
                GetComponent<PlayerSC>().ballInHand = true;
                pickUp.Play();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.name == "RulerPickeable")
        {
            other.transform.GetChild(2).gameObject.SetActive(false);
            canInteractWithItem = false;
        }

        if(other.name == "Boina")
        {
            other.transform.GetChild(0).gameObject.SetActive(false);
            canInteractWithItem = false;
        }

        if(other.name == "Model&Collider")
        {
            other.transform.GetChild(0).gameObject.SetActive(false);
            canInteractWithItem = false;
        }

        if (other.name == "Glasses")
        {
            other.transform.GetChild(0).gameObject.SetActive(false);
            canInteractWithItem = false;
        }

        if(other.name == "BallBucket")
        {
            other.transform.GetChild(0).gameObject.SetActive(false);
            canInteractWithItem = false;
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
