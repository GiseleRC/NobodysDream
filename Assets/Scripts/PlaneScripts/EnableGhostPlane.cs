using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableGhostPlane : MonoBehaviour
{
    public GameState gameState;
    public GhostCloth ghostCloth;
    [SerializeField] private Collider ghostC;
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
    }
}
