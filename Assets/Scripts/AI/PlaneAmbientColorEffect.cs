using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneAmbientColorEffect : MonoBehaviour
{
    private GameState gameState;
    public GameObject sensorFalse, sensorTrue, IconGhostEnable, trueSteps, IconLinternaOn, IconLinternaOff, canvasBallCount;
    public PlayerSC playerSC;
    private GameState.PlaneMode lastAppliedPlaneMode;
    //private Color colorDreamPlane;
    public AudioSource SwitchMode;
    //[SerializeField, ColorUsageAttribute(true, true)] private Color colorGhostPlane;
    //[SerializeField, ColorUsageAttribute(true, true)] private Color colorDemonPlane;

    void Awake()
    {
        gameState = FindObjectOfType<GameState>();
        lastAppliedPlaneMode = gameState.GetPlaneMode();

        //colorDreamPlane = RenderSettings.ambientLight;//lo que estoy queriendo cambiar guardandolo, valor inicial del mundo de los sueños
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
                //RenderSettings.ambientLight = colorDreamPlane;
                canvasBallCount.SetActive(false);
                IconGhostEnable.SetActive(false);
                IconLinternaOn.SetActive(true);
                IconLinternaOff.SetActive(false);
                SwitchMode.Play();
                break;
            case GameState.PlaneMode.Ghost:
                sensorFalse.SetActive(false);
                sensorTrue.SetActive(true);
                canvasBallCount.SetActive(true);
                IconGhostEnable.SetActive(true);
                IconLinternaOn.SetActive(false);
                IconLinternaOff.SetActive(true);
                SwitchMode.Play();
                //RenderSettings.ambientLight = colorGhostPlane;
                break;
            case GameState.PlaneMode.Demon:
                //RenderSettings.ambientLight = colorDemonPlane;
                break;
        }
    }
}
