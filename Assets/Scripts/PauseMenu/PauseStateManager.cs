using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseStateManager
{
    private static PauseStateManager _instance;

    public static PauseStateManager Instance
    {
        get
        {
            if (_instance == null)
                _instance = new PauseStateManager();

            return _instance;
        }
    }

    public PauseState CurrentPauseState { get; set; }

    public delegate void PauseStateChangeHandler(PauseState newPauseState);
    public event PauseStateChangeHandler OnPauseStateChanged;

    public void SetState(PauseState newPauseState)
    {
        if (newPauseState == CurrentPauseState)
            return;

        CurrentPauseState = newPauseState;
        OnPauseStateChanged?.Invoke(newPauseState);
    }
}
