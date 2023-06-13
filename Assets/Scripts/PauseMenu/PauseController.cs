using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TP2 - Leandro Fanelli - Se inicializa el estado en Gameplay, cuando se presiona Escape, se consulta el estado actual de la pausa.
// En caso de que sea Pausa lo cambia a Gameplay, y viceversa. Haciendo que se activen y desactiven los scripts subscritos dependiendo su enum.
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
        //print(PauseStateManager.Instance.CurrentPauseState);
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
