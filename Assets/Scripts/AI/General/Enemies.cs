using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemies : MonoBehaviour
{
    protected NavMeshAgent nma;
    protected GameState gameState;
    protected Transform characterPos;
    protected float actualTime;
    protected GameState.PlaneMode mode;
    // Start is called before the first frame update

    private void Awake()
    {
        characterPos = GameObject.Find("Char").GetComponent<Transform>();

        nma = GetComponent<NavMeshAgent>();

        gameState = GameObject.Find("GameState").GetComponent<GameState>();

        PauseStateManager.Instance.OnPauseStateChanged += OnPauseStateChanged;
    }

    private void OnDisable()
    {
        nma.isStopped = true;
    }

    private void OnEnable()
    {
        nma.isStopped = false;
    }

    private void OnDestroy()
    {
        PauseStateManager.Instance.OnPauseStateChanged -= OnPauseStateChanged;
    }


    public void ReceiveStun(float stunDuration)
    {
        actualTime = stunDuration;
    }

    private void OnPauseStateChanged(PauseState newPauseState)
    {
        enabled = newPauseState == PauseState.Gameplay;
    }

    public Transform CharacterPos
    {
        get { return characterPos; }
    }

    public NavMeshAgent NMA
    {
        get
        {
            return nma;
        }
    }
}
