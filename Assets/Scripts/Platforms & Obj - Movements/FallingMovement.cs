using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingMovement : MonoBehaviour
{
    bool isFalling = false;
    float fallingVelocity = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Char")
        {
            isFalling = true;
        }
    }
    void Update()
    {
        if (isFalling)
        {
            fallingVelocity += Time.deltaTime / 10;
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y - fallingVelocity, gameObject.transform.position.z);
        }
        if (gameObject.transform.position.y <= -40)
        {
            isFalling = false;
            fallingVelocity = 0;
        }
    }
}
