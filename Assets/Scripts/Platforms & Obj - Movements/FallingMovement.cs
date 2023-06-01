using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingMovement : MonoBehaviour
{
    //bool isFalling = false;
    bool startTimer;
    float fallingVelocity = 0, currentTimer;
    [SerializeField] float timeToFall; 
    public AudioSource PlatformFalling;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Char")
        {
            startTimer = true;
            PlatformFalling.Play();
        }
    }

    private void Awake()
    {
        PauseStateManager.Instance.OnPauseStateChanged += OnPauseStateChanged;
    }

    private void OnDestroy()
    {
        PauseStateManager.Instance.OnPauseStateChanged -= OnPauseStateChanged;
    }

    void Update()
    {
        if (startTimer)
        {
            currentTimer += Time.deltaTime;
        }

        if (currentTimer > timeToFall)
        {
            fallingVelocity += Time.deltaTime / 10;
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y - fallingVelocity, gameObject.transform.position.z);
            
        }
        if (gameObject.transform.position.y <= -40)
        {
            startTimer = false;
            currentTimer = 0;
            fallingVelocity = 0;
            PlatformFalling.Stop();
        }
    }

    private void OnPauseStateChanged(PauseState newPauseState)
    {
        enabled = newPauseState == PauseState.Gameplay;
    }
}
