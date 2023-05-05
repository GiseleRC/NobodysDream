using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollitionsBody : MonoBehaviour
{
    public GameState gameState;
    public FlashLight flashLightSC;
    public TutorialPaperSC tutorialPaperBool;
    public GameObject glasses, map, flashLigthArm, cap, flashLightPick;
    [SerializeField] private Collider glassesC, mapC, flashLightC, capC;
    public AudioSource openTutorial;
    void Update()
    {
    }
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
        }
        if (other == capC)
        {
            cap.SetActive(false);
            gameObject.GetComponent<MaterializeObjects>().enabled = true;
        }

        if (other == glassesC)
        {
            gameState.GhostPlaneModeEnabled = true;
            glasses.SetActive(false);
            map.SetActive(true);
        }
        if (other == mapC)
        {
            map.SetActive(false);
            gameState.DemonPlaneModeEnabled = true;
        }
    }
}