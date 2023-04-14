using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneColorEffect : MonoBehaviour
{
    private GameState gameState;
    private GameState.PlaneMode lastAppliedPlaneMode;

    void Awake()
    {
        gameState = FindObjectOfType<GameState>();
        lastAppliedPlaneMode = gameState.GetPlaneMode();
    }

    // Update is called once per frame
    void Update()
    {
        GameState.PlaneMode currAppliedPlaneMode = gameState.GetPlaneMode();
        if (currAppliedPlaneMode == lastAppliedPlaneMode)
            return;

        lastAppliedPlaneMode = currAppliedPlaneMode;

        Debug.Log("Aplicando efecto segun plano: " + currAppliedPlaneMode.ToString());
    }
}
