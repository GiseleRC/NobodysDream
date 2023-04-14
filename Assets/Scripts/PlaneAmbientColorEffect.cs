using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneAmbientColorEffect : MonoBehaviour
{
    private GameState gameState;
    private GameState.PlaneMode lastAppliedPlaneMode;
    private Color colorDreamPlane;
    [SerializeField, ColorUsageAttribute(true, true)] private Color colorGhostPlane;
    [SerializeField, ColorUsageAttribute(true, true)] private Color colorDemonPlane;

    void Awake()
    {
        gameState = FindObjectOfType<GameState>();
        lastAppliedPlaneMode = gameState.GetPlaneMode();

        colorDreamPlane = RenderSettings.ambientLight;//lo que estoy queriendo cambiar guardandolo, valor inicial del mundo de los sue�os
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
                break;
            case GameState.PlaneMode.Ghost:
                RenderSettings.ambientLight = colorGhostPlane;
                break;
            case GameState.PlaneMode.Demon:
                RenderSettings.ambientLight = colorDemonPlane;
                break;
        }
    }
}
