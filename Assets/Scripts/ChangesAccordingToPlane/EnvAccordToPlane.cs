using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvAccordToPlane : MonoBehaviour
{
    private GameState gameState;
    public GameObject trueSteps, iconGhostOn, iconGhostOff, iconDreamOn, iconDreamOff, canvasBallCount, bucket, disableFlashlight;
    public PlayerSC playerSC;
    private GameState.PlaneMode lastAppliedPlaneMode;
    public AudioSource SwitchMode;

    void Awake()
    {
        gameState = FindObjectOfType<GameState>();
        lastAppliedPlaneMode = gameState.GetPlaneMode();
    }
    void Update()
    {
        GameState.PlaneMode currAppliedPlaneMode = gameState.GetPlaneMode();
        if (currAppliedPlaneMode == lastAppliedPlaneMode)
            return;

        lastAppliedPlaneMode = currAppliedPlaneMode;

        switch (currAppliedPlaneMode)
        {
            case GameState.PlaneMode.Dream:
                //if (playerSC.ballInHand)
                //{
                //    canvasBallCount.SetActive(false);
                //}
                iconGhostOn.SetActive(false);
                iconGhostOff.SetActive(true);
                iconDreamOn.SetActive(true);
                iconDreamOff.SetActive(true);
                bucket.SetActive(false);
                //disableball.SetActive(true);
                //disableFlashlight.SetActive(false);

                SwitchMode.Play();
                break;
            case GameState.PlaneMode.Ghost:
                //canvasBallCount.SetActive(true);
                iconGhostOn.SetActive(true);
                iconGhostOff.SetActive(false);
                iconDreamOn.SetActive(false);
                iconDreamOff.SetActive(true);
                bucket.SetActive(true);
                //disableFlashlight.SetActive(true);
                //disableball.SetActive(false);

                SwitchMode.Play();
                break;
            case GameState.PlaneMode.Demon:
                break;
        }
    }
}
