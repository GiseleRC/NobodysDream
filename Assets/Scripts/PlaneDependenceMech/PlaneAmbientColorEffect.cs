using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneAmbientColorEffect : MonoBehaviour
{
    private GameState gameState;
    public GameObject ghostItems, IconGhostEnable, NewSpawnOBJ, trueSteps,IconLinternaOn, IconLinternaOff;
    private GameState.PlaneMode lastAppliedPlaneMode;
    private Color colorDreamPlane;
    public AudioSource SwitchMode;
    [SerializeField, ColorUsageAttribute(true, true)] private Color colorGhostPlane;
    [SerializeField, ColorUsageAttribute(true, true)] private Color colorDemonPlane;

    void Awake()
    {
        gameState = FindObjectOfType<GameState>();
        lastAppliedPlaneMode = gameState.GetPlaneMode();

        colorDreamPlane = RenderSettings.ambientLight;//lo que estoy queriendo cambiar guardandolo, valor inicial del mundo de los sueños
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
                RenderSettings.ambientLight = colorDreamPlane;
                ghostItems.SetActive(false);
                IconGhostEnable.SetActive(false);
                IconLinternaOn.SetActive(true);
                IconLinternaOff.SetActive(false);
                SwitchMode.Play();
                //NewSpawnOBJ.SetActive(false);
                break;
            case GameState.PlaneMode.Ghost:
                ghostItems.SetActive(true); 
                IconGhostEnable.SetActive(true);
                IconLinternaOn.SetActive(false);
                IconLinternaOff.SetActive(true);
                SwitchMode.Play();
                //NewSpawnOBJ.SetActive(true);
                RenderSettings.ambientLight = colorGhostPlane;
                break;
            case GameState.PlaneMode.Demon:
                RenderSettings.ambientLight = colorDemonPlane;
                break;
        }
    }
}
