using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleEnderezarPlataforma : MonoBehaviour
{
    public bool limitOfRotationZ, cutRope;//poner en true cuando corte la soga

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "ConcreteF - se detiene plataforma")
        {
            limitOfRotationZ = true;
            print("choqueeeeeee");
        }
    }
    void Update()
    {
        if (limitOfRotationZ)
        {
            gameObject.GetComponent<KinematicMovementController>().enabled = false;
        }
        if (cutRope)
        {
            gameObject.GetComponent<KinematicMovementController>().enabled = true;
        }
    }
}
