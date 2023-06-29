using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroytimer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 25f);
    }

    private void Awake()
    {
        PauseStateManager.Instance.OnPauseStateChanged += OnPauseStateChanged;
    }

    private void OnDestroy()
    {
        PauseStateManager.Instance.OnPauseStateChanged -= OnPauseStateChanged;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.name == "Char")
        {
            other.gameObject.GetComponent<PlayerSC>().Slow();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Char")
        {
            other.gameObject.GetComponent<PlayerSC>().CancelSlow();
        }
    }

    private void OnPauseStateChanged(PauseState newPauseState)
    {
        enabled = newPauseState == PauseState.Gameplay;
    }
}
