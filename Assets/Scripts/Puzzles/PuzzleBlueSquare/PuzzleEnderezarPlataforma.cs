using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleEnderezarPlataforma : MonoBehaviour
{
    public bool limitOfRotationZ, cutRope;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "ConcreteF - se detiene plataforma")
        {
            limitOfRotationZ = true;
        }
    }
    void Update()
    {
        if (limitOfRotationZ)
        {
            gameObject.GetComponent<KinematicMovementController>().enabled = false;
        }

        //if (cutRope)
        //{

        //}
    }
}
