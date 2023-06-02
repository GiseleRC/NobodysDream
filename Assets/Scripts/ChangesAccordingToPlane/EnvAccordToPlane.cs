using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvAccordToPlane : MonoBehaviour
{
    private GameState gameState;
    public GameObject sensorFalse, sensorTrue, IconGhostEnable, trueSteps, IconLinternaOn, IconLinternaOff, canvasBallCount, bucket;
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
                if (playerSC.ballInHand)
                {
                    canvasBallCount.SetActive(false);
                }
                IconGhostEnable.SetActive(false);
                IconLinternaOn.SetActive(true);
                IconLinternaOff.SetActive(false);
                bucket.SetActive(false);
                SwitchMode.Play();
                break;
            case GameState.PlaneMode.Ghost:
                sensorFalse.SetActive(false);
                sensorTrue.SetActive(true);
                canvasBallCount.SetActive(true);
                IconGhostEnable.SetActive(true);
                IconLinternaOn.SetActive(false);
                IconLinternaOff.SetActive(true);
                bucket.SetActive(true);
                SwitchMode.Play();
                break;
            case GameState.PlaneMode.Demon:
                break;
        }
    }
}
