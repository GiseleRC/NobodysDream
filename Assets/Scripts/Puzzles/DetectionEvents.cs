using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionEvents : MonoBehaviour
{
    [SerializeField] private FinalPuzzle finalPuzzle;

    private void OnCollisionEnter(Collision collision)
    {
        if (gameObject.name == "SlimeFloor1" && collision.gameObject.name == "Char")
        {
            finalPuzzle.button1enable = true;
        }
        if (collision.gameObject.name == "Ball (Clone)")
        {
            if (gameObject.name == "ON (1)")
            {
                finalPuzzle.particle1Off = true;
                finalPuzzle.lightUp1 = true;
            }
            if (gameObject.name == "")
            {

            }
        }


        if (gameObject.name == "ParticleButton1")
        {
            
        }
    }
    void Update()
    {
        //collition: triger, triger2, triger3
    }
}
