using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountBall : MonoBehaviour
{
    [SerializeField] private PlayerSC playerData;
    [SerializeField] public GameState gameState;
    [SerializeField] public PlayerCollitionsBody playerC;
    [SerializeField] private int currBall;
    [SerializeField] public GameObject zeroBall, oneBall, twoBalls, threeBalls;
    void Update()
    {
        currBall = playerData.currBallsInHand;
        if (gameState.GhostPlaneModeEnabled && playerC.ballEnable)
        {
            if (currBall == 0)
            {
                zeroBall.SetActive(true);
                oneBall.SetActive(false);
                twoBalls.SetActive(false);
                threeBalls.SetActive(false);
            }
            else if (currBall == 1)
            {
                zeroBall.SetActive(false);
                oneBall.SetActive(true);
                twoBalls.SetActive(false);
                threeBalls.SetActive(false);
            }
            else if (currBall == 2)
            {
                zeroBall.SetActive(false);
                oneBall.SetActive(false);
                twoBalls.SetActive(true);
                threeBalls.SetActive(false);
            }
            else if (currBall == 3)
            {
                zeroBall.SetActive(false);
                oneBall.SetActive(false);
                twoBalls.SetActive(false);
                threeBalls.SetActive(true);
            }
        } 
    }
}