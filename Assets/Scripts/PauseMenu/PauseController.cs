using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseController : MonoBehaviour
{
    bool paused;

    // Start is called before the first frame update
    void Start()
    {
        PauseStateManager.Instance.CurrentPauseState = PauseState.Gameplay;
    }

    // Update is called once per frame
    void Update()
    {
        print(PauseStateManager.Instance.CurrentPauseState);
        if (Input.GetButtonDown("Escape"))
        {
            PauseState currentPauseState = PauseStateManager.Instance.CurrentPauseState;
            PauseState newPauseState = currentPauseState == PauseState.Paused
                ? PauseState.Gameplay
                : PauseState.Paused;

            PauseStateManager.Instance.SetState(newPauseState);
        }


        
    }
}
