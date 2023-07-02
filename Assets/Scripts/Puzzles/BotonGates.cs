using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotonGates : MonoBehaviour
{
    [SerializeField] private MiniBoss miniBoss;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Ball(Clone)" && gameObject.name == "ResetGreen")
        {
            miniBoss.gateGreenOpen = true;
        }
        else if (collision.gameObject.name == "Ball(Clone)" && gameObject.name == "ResetBlue")
        {
            miniBoss.gateBlueOpen = true;
        }
        else if (collision.gameObject.name == "Ball(Clone)" && gameObject.name == "ResetPink")
        {
            miniBoss.gatePinkOpen = true;
        }
    }

    void Update()
    {
        
    }
}
