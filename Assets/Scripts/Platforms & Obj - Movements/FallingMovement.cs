using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingMovement : MonoBehaviour
{
    bool isFalling = false, startTimer;
    float fallingVelocity = 0, currentTimer;
    [SerializeField] float timeToFall;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Char")
        {
            startTimer = true;
        }
    }

    void Update()
    {
        if (startTimer)
        {
            GetComponent<PlatformMove>().enabled = true;
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
            GetComponent<PlatformMove>().enabled = false;
            currentTimer = 0;
            fallingVelocity = 0;
        }
    }
}
