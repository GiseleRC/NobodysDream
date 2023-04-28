using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableGhostPlane : MonoBehaviour
{
    public GameState gameState;
    public GhostCloth ghostCloth;
    public GameObject glasses, map;
    [SerializeField] private Collider ghostC, glassesC, mapC;
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other == ghostC)
        {
            ghostCloth.collitionE = true;
            gameState.GhostPlaneModeEnabled = true;
        }
        if (other == glassesC)
        {
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
