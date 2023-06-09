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
    public DialogSystem dialogS;
    public GameObject dialogSystem, canvasBallCount, bookEnableUIGO, IconFantasma, IconFantasmaLinterna, flashLigthUI, rubbers, ligthKaki, ligthPractice, light1, light2, light3, lightBed, interactiveButton, glassesGO, flashLigthArm, flashLightPickGO, cap, door, level2Enable, level1Enable, ballBucket, rullerPick, collectPickeable, Light4;
    public AudioSource openTutorial, pickUp, booster;
    [SerializeField] private Collider capC, boosterC;
    public bool ballEnable = false;
    public bool justOneWhenPick = false;
    public bool iHaveCap = false;
    private bool objEnable = false;
    private bool capEnable = false;
    private float addTime = 15f;
    bool canInteractWithItem;
    public GameObject[] pickeablesUI;
    public AudioSource ClickLamp;

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Boina")
        {
            pickeablesUI[0].SetActive(true);// Activa la linterna? no se como lo hace
            canInteractWithItem = true;
        }
        else if (other.name == "Model&Collider" && !tutorialPaperBool.anyTutorialOpen)// Activa la regla y el cubo?
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
        //Habilita acceso a tutoriales
        else if (other.name == "BookEnableUI")
        {
            dialogS.rubberB = true;
            //Activa/Desactiva gameobject
            other.gameObject.SetActive(false);
            bookEnableUIGO.SetActive(true);
            rubbers.SetActive(true);
            //Play
            pickUp.Play();
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
            dialogS.boosterB = true;
            //Suma al tiempo
            timerController.AddTime(addTime);
            //Activa/Desactiva gameobject
            other.gameObject.SetActive(false);
            //Particula
            Instantiate(collectPickeable, other.gameObject.transform.position + transform.forward * 2f, other.gameObject.transform.rotation);
            //Play
            booster.Play();
        }
        else if (other.name == "SabanaLvl1Off")
        {
            level1Enable.SetActive(false);
        }
        //Desactiva el nivel 1
        else if (other.name == "SensorPlayer - GhostB")
        {
            dialogS.chocolatesB = true;
        }
        else if (other.name == "SensorPlayer - Candy")
        {
            dialogS.candyWheelB = true;
        }
        else if (other.name == "SensorPlayer - Glasses")
        {
            dialogS.glassesB = true;
        }
        //Desactiva bola pickeable, habilita bola, valde y abre el tuto
        else if (other.name == "BallPickable" && !tutorialPaperBool.anyTutorialOpen)
        {
            GetComponent<PlayerSC>().PickupBalls(1);
            //Activa boleanos
            ballEnable = true;
            tutorialPaperBool.showTutorialBall = true;
            //Activa/Desactiva gameobject
            ballBucket.SetActive(true);
            canvasBallCount.SetActive(true);
            ligthPractice.SetActive(true);
            ligthKaki.SetActive(false);
            other.gameObject.SetActive(false);
            //Play
            pickUp.Play();
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
                dialogS.capB = true;// bool dialogo

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
                tutorialPaperBool.showTutorialGlasses = true;//booleano del Script tutorial ANTEOJOS
                gameState.GhostPlaneModeEnabled = true;//Activa PLANE GHOST

                glassesGO.SetActive(false);//anteojos pickeable
                IconFantasma.SetActive(true);//UI PLANE GHOST
                level2Enable.SetActive(true);//Se activa LEVEL2
                pickeablesUI[3].SetActive(false);

                pickUp.Play();//Sonido de PICKEABLE
            }
        }

        if(other.name == "BallBucket")
        {
            if (canInteractWithItem && Input.GetButton("Interact"))
            {
                other.gameObject.GetComponent<EnableBucketUI>().DisableUI();
                if (GetComponent<PlayerSC>().PickupBalls(5))
                    pickUp.Play();
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
    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "ChocolateBlock")
        {
            dialogS.slideB = true;
        }
        else if (collision.gameObject.name == "Crayons")
        {
            dialogS.crayonsB = true;
        }
        else if (collision.gameObject.name == "SensorPlayerchocolate")
        {
            dialogS.chocolatesB = true;
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
