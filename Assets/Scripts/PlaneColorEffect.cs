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
        colorDreamPlane = GetComponent<Material>().GetColor(0);
    }

    // Update is called once per frame
    void Update()
    {
        GameState.PlaneMode currAppliedPlaneMode = gameState.GetPlaneMode();
        if (currAppliedPlaneMode == lastAppliedPlaneMode)
            return;

        lastAppliedPlaneMode = currAppliedPlaneMode;

        /*switch (currAppliedPlaneMode)
        {
            case GameState.PlaneMode.Dream:
                SetPlaneMode(PlaneMode.Demon);
                break;
            case GameState.PlaneMode.Ghost:
                SetPlaneMode(PlaneMode.Dream);
                break;
            case GameState.PlaneMode.Demon:
                SetPlaneMode(PlaneMode.Ghost);
                break;
        }*/
    }
}
