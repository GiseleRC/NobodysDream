using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollitionsBody : MonoBehaviour
{
    public GameState gameState;
    public GameObject glasses, map;
    [SerializeField] private Collider glassesC, mapC;
    void Update()
    {
    }
    private void OnTriggerEnter(Collider other)
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
    }
}
