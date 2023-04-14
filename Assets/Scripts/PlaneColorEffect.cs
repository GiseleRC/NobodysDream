using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneColorEffect : MonoBehaviour
{
    private GameState gameState;
    private GameState.PlaneMode lastAppliedPlaneMode;
    private Color colorDreamPlane;
    [SerializeField] private Color colorGhostPlane;
    [SerializeField] private Color colorDemonPlane;

    void Awake()
    {
        gameState = FindObjectOfType<GameState>();
        lastAppliedPlaneMode = gameState.GetPlaneMode();
        colorDreamPlane = GetComponent<Renderer>().material.color;
    }

    // Update is called once per frame
    void Update()
    {
        GameState.PlaneMode currAppliedPlaneMode = gameState.GetPlaneMode();
        if (currAppliedPlaneMode == lastAppliedPlaneMode)
            return;

        lastAppliedPlaneMode = currAppliedPlaneMode;

        switch (currAppliedPlaneMode)
        {
            case GameState.PlaneMode.Dream:
                GetComponent<Renderer>().material.color = colorDreamPlane;
                break;
            case GameState.PlaneMode.Ghost:
                GetComponent<Renderer>().material.color = colorGhostPlane;
                break;
            case GameState.PlaneMode.Demon:
                GetComponent<Renderer>().material.color = colorDemonPlane;
                break;
        }
    }
}
