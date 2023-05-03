using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollitionsBody : MonoBehaviour
{
    public GameState gameState;
    public FlashLight flashLightSC;
    public GameObject glasses, map, flashLigth, cap;
    [SerializeField] private Collider glassesC, mapC, flashLightC;
    void Update()
    {
    }
    private void OnTriggerEnter(Collider other)//hacerlo switch
    {
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
        if (other == flashLightC)
        {
            flashLightSC.hasFlashlight = true;
            flashLigth.SetActive(false);
            cap.SetActive(true);
        }
    }
}
