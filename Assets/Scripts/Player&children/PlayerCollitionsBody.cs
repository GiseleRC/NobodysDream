using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollitionsBody : MonoBehaviour
{
    public Animator reloj, windowClosed, windowClosed2, windowOpen;
    public GameState gameState;
    public FlashLight flashLightSC;
    public TimerController timerController;
    public TutorialPaperSC tutorialPaperBool;
    public DialogManager dialogManager;
    public GameObject rudolfClownGO, buttonResetGO, whitePiecesGO, letterOpenGO, introGO, enableLightPuzzle3, dialogSystem, canvasBallCount, IconFantasma, IconFantasmaLinterna, flashLigthUI, rubbers, ligthKaki, ligthPractice, light1, light2, light3, lightBed, interactiveButton, glassesGO, flashLigthArm, flashLightPickGO, cap, door, level2Enable, level1Enable, ballBucket, rullerPick, collectPickeable, Light4;
    public AudioSource openTutorial, pickUp, booster;
    [SerializeField] private Collider capC, boosterC;
    public bool ballEnable = false;
    public bool iHaveCap = false;
    private bool objEnable = false;
    private bool capEnable = false;
    private bool firstTimeGrab = false;
    private bool introB = false;
    private float addTime = 25f;
    private float waitTime = 10f;
    bool canInteractWithItem;
    public GameObject[] pickeablesUI;
    public AudioSource ClickLamp;
    public Puzzle2 puzzle2;
    public GameObject psObject;

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Boina")
        {
            pickeablesUI[0].SetActive(true);// Activa la linterna? no se como lo hace
            canInteractWithItem = true;
        }
        else if (other.name == "Model&Collider" && !tutorialPaperBool.anyTutorialOpen)
        {
            pickeablesUI[1].SetActive(true);// Activa la linterna? no se como lo hace
            canInteractWithItem = true;
        }
        else if (other.name == "RulerPickeable" && !tutorialPaperBool.anyTutorialOpen)
        {
            pickeablesUI[2].SetActive(true);// Activa la linterna? no se como lo hace
            canInteractWithItem = true;
        }
        else if (other.name == "Glasses" && !tutorialPaperBool.anyTutorialOpen)
        {
            pickeablesUI[3].SetActive(true);// Activa la linterna? no se como lo hace
            canInteractWithItem = true;
        }
        else if (other.name == "BallBucket" && GetComponent<PlayerSC>().canThrowBall)
        {
            other.gameObject.GetComponent<EnableBucketUI>().EnableUI();
            canInteractWithItem = true;
        }
        //Booster pickeable
        else if (other.name == "zZz")
        {
            //bool 
            reloj.enabled = true;
            //Suma al tiempo
            timerController.AddTime(addTime);
            //Activa/Desactiva gameobject
            other.gameObject.SetActive(false);
            //Particula
            Instantiate(collectPickeable, other.gameObject.transform.position + transform.forward * 2f, other.gameObject.transform.rotation);
            //Play
            booster.Play();
        }
        else if (other.name == "zZz1")
        {
            //bool 
            reloj.enabled = true;
            dialogManager.ShowDialog(DialogKey.Boosters);
            //Suma al tiempo
            timerController.AddTime(addTime);
            //Activa/Desactiva gameobject
            other.gameObject.SetActive(false);
            rubbers.SetActive(true);
            //Particula
            Instantiate(collectPickeable, other.gameObject.transform.position + transform.forward * 2f, other.gameObject.transform.rotation);
            //Play
            booster.Play();
        }
        else if (other.name == "SabanaLvl1Off")
        {
            dialogManager.ShowDialog(DialogKey.Level2);
            //level1Enable.SetActive(false);
            other.gameObject.GetComponent<Collider>().enabled = false;
        }
        else if (other.name == "SensorPlayerchocolate")
        {
            dialogManager.ShowDialog(DialogKey.Chocolates);
        }
        //Desactiva el nivel 1
        else if (other.name == "CheckPoint7 - GhostB")
        {
            dialogManager.ShowDialog(DialogKey.Ghost);
        }
        else if (other.name == "CheckPoint8 - Candy")
        {
            dialogManager.ShowDialog(DialogKey.CandyWheel);
        }
        else if (other.name == "SensorPlayer - WindowWrong2")
        {
            dialogManager.ShowDialog(DialogKey.FakeWindow);
            windowClosed.Play("WindowLeft");
        }
        else if (other.name == "SensorPlayer - WindowWrong")
        {
            dialogManager.ShowDialog(DialogKey.FakeWindow);
            windowClosed2.Play("WindowMiddle");
        }
        else if (other.name == "SensorPlayer - WindowCorrect")
        {
            dialogManager.ShowDialog(DialogKey.RealWindow);
            windowOpen.Play("WindowRight");
        }
        else if (other.name == "EnableLetter")
        {
            other.gameObject.SetActive(false);
            letterOpenGO.SetActive(true);
            whitePiecesGO.SetActive(true);
            buttonResetGO.SetActive(true);
        }
        else if (other.name == "Dientes")
        {
            other.gameObject.SetActive(false);
        }
        //Desactiva bola pickeable, habilita bola, valde y abre el tuto
        else if (other.name == "BallPickable" && !tutorialPaperBool.anyTutorialOpen)
        {
            canInteractWithItem = true;
            other.gameObject.GetComponent<EnableBucketUI>().EnableUI();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.name == "Boina")
        {
            if (canInteractWithItem && Input.GetButton("Interact"))
            {
                //booleano del Script guia de tutoriales BOINA/MODO
                capEnable = true;

                cap.SetActive(false);//Se desactiva boina
                flashLightPickGO.SetActive(true);//Se activa la LINTERNA
                IconFantasmaLinterna.SetActive(true);//UI de PLANE DREAM
                dialogSystem.SetActive(true);//Se activa SISTEMA DE DIALOGO
                dialogManager.ShowDialog(DialogKey.IntroductionGuide);// bool dialogo

                pickeablesUI[0].SetActive(false);

                pickUp.Play();//Sonido de PICKEABLE

                light3.SetActive(false);
                Light4.SetActive(true);
                ClickLamp.Play();

            }
        }

        if (other.name == "RulerPickeable")
        {
            if (canInteractWithItem && Input.GetButton("Interact") && !tutorialPaperBool.anyTutorialOpen)
            {
                PauseGame();
                tutorialPaperBool.showTutorialMat1 = true;//booleano del Script tutorial REGLA
                objEnable = true;//booleano para I HAVE CAP
                tutorialPaperBool.anyTutorialOpen = true;

                other.gameObject.SetActive(false);//ruller pickeable
                light2.SetActive(false);//Se activa puerta
                light3.SetActive(false);//Se activa puerta
                lightBed.SetActive(false);
                door.SetActive(true);//Se activa puerta
                light1.SetActive(false);//Se activa puerta
                pickUp.Play();//Sonido de PICKEABLE
                pickeablesUI[2].SetActive(false);
            }
        }

        if(other.name == "Model&Collider")
        {
            if (canInteractWithItem && Input.GetButton("Interact") && !tutorialPaperBool.anyTutorialOpen)
            {
                PauseGame();
                tutorialPaperBool.showTuturialFlash = true;//booleano del Script tutorial LINTERNA
                flashLightSC.hasFlashlight = true;//booleano del Script flashligth
                tutorialPaperBool.anyTutorialOpen = true;

                flashLightPickGO.SetActive(false);//linterna pickeable
                flashLigthUI.SetActive(true);//UI de linterna
                flashLigthArm.SetActive(true);//linterna del brazo
                rullerPick.SetActive(true);//Se activa RULLER
                pickeablesUI[1].SetActive(false);

                pickUp.Play();//Sonido de PICKEABLE

                
                Light4.SetActive(false);
                light1.SetActive(true);
                ClickLamp.Play();
            }
        }

        if(other.name == "Glasses")
        {
            if (canInteractWithItem && Input.GetButton("Interact"))
            {
                PauseGame();
                tutorialPaperBool.showTutorialGlasses = true;//booleano del Script tutorial ANTEOJOS
                gameState.GhostPlaneModeEnabled = true;//Activa PLANE GHOST
                tutorialPaperBool.anyTutorialOpen = true;

                glassesGO.SetActive(false);//anteojos pickeable
                IconFantasma.SetActive(true);//UI PLANE GHOST
                level2Enable.SetActive(true);//Se activa LEVEL2
                pickeablesUI[3].SetActive(false);

                pickUp.Play();//Sonido de PICKEABLE
            }
        }

        if (other.name == "BallBucket")
        {
            if (canInteractWithItem && Input.GetButton("Interact"))
            {
                firstTimeGrab = true;
                if (GetComponent<PlayerSC>().PickupBalls(5))
                    pickUp.Play();
            }
        }

        if(other.name == "BallPickable")
        {
            if(canInteractWithItem && Input.GetButton("Interact"))
            {
                PauseGame();
                GetComponent<PlayerSC>().PickupBalls(1);
                other.gameObject.GetComponent<EnableBucketUI>().DisableUI();
                //Activa boleanos
                ballEnable = true;
                tutorialPaperBool.anyTutorialOpen = true;
                tutorialPaperBool.showTutorialBall = true;
                //Activa/Desactiva gameobject
                ballBucket.SetActive(true);
                canvasBallCount.SetActive(true);
                ligthPractice.SetActive(true);
                ligthKaki.SetActive(false);
                other.gameObject.SetActive(false);
                //Play
                pickUp.Play();
                Destroy(psObject);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.name == "RulerPickeable")
        {
            pickeablesUI[2].SetActive(false);
            canInteractWithItem = false;
        }

        if(other.name == "Boina")
        {
            pickeablesUI[0].SetActive(false);
            canInteractWithItem = false;
        }

        if(other.name == "Model&Collider")
        {
            pickeablesUI[1].SetActive(false);
            canInteractWithItem = false;
        }

        if (other.name == "Glasses")
        {
            pickeablesUI[3].SetActive(false);
            canInteractWithItem = false;
        }

        if(other.name == "BallBucket")
        {
            other.gameObject.GetComponent<EnableBucketUI>().DisableUI();
            canInteractWithItem = false;
        }

        if(other.name == "BallPickable")
        {
            other.gameObject.GetComponent<EnableBucketUI>().DisableUI();
            canInteractWithItem = false;
        }
    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "ChocolateBlock")
        {
            dialogManager.ShowDialog(DialogKey.Slide);
        }
        else if (collision.gameObject.name == "CrayonsPlatform")
        {
            dialogManager.ShowDialog(DialogKey.Crayons);
        }
        else if (collision.gameObject.name == "ConcreteF - Rubbers")
        {
            dialogManager.ShowDialog(DialogKey.Rubber);
        }
        else if (collision.gameObject.name == "ConcreteF - EnableLight")
        {
            enableLightPuzzle3.SetActive(true);
        }
        else if (collision.gameObject.name == "AlmohadaL-Intro")
        {
            introB = true;
            introGO.SetActive(true);
            collision.gameObject.name = "AlmohadaL";
        }
        else if (collision.gameObject.name == "Floor&Columns - disable")
        {
            rudolfClownGO.SetActive(true);
        }
    }
    private void Update()
    {
        if (objEnable && capEnable)
        {
            iHaveCap = true;//booleano cuando tiene la gorra
            capEnable = false;
        }
        if (!puzzle2.practice1 && !puzzle2.practice2 && !puzzle2.practice3 && firstTimeGrab)
        {
            dialogManager.ShowDialog(DialogKey.Practice);
            firstTimeGrab = false;
        }
        if (introB && introGO)
        {
            waitTime -= Time.deltaTime;
            if (waitTime <= 0f)
            {
                introGO.SetActive(false);
                introB = false;
            }
        }
    }

    void PauseGame()
    {
        PauseState currentPauseState = PauseStateManager.Instance.CurrentPauseState;
        PauseState newPauseState = currentPauseState == PauseState.Paused
            ? PauseState.Gameplay
            : PauseState.Paused;

        PauseStateManager.Instance.SetState(newPauseState);
        print(PauseStateManager.Instance.CurrentPauseState);
    }
}
