using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingMovement : MonoBehaviour
{

    bool isFalling = false;
    float fallingVelocity = 0;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.name == "Char")
        {
            isFalling = true;
            Destroy(gameObject, 10);
        }
    }
    void Update()
    {
        if (isFalling)
        {
            fallingVelocity += Time.deltaTime / 10;
            transform.position = new Vector3(transform.position.x, transform.position.y - fallingVelocity, transform.position.z);
        }
    }
}
