using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionEvents : MonoBehaviour
{
    [SerializeField] private FinalPuzzle finalPuzzle;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Char")
        {
            if (gameObject.name == "SlimeFloor1")
            {
                finalPuzzle.button1enable = true;
            }

            if (gameObject.name == "ConcreteW(11)")
            {
                finalPuzzle.backMonster = true;
            }
        }
        if (collision.gameObject.name == "Ball (Clone)")
        {
            if (gameObject.name == "ON (1)")//aparece el monstruo
            {
                finalPuzzle.particle1Off = true;
                finalPuzzle.lightUp1 = true;
            }
            if (gameObject.name == "triger")//para rotar aparece plataformas
            {
                finalPuzzle.triger = true;
            }
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        
    }
    void Update()
    {
        //collition: triger, triger2, triger3
    }
}
