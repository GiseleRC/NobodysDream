using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticPlatform : Platform
{
    //Plataformas que comienzan su movimiento sin esperar ninguna reaccion a diferencia de la reactionPlatform
    private void Start()
    {
        StartMovement();
    }
}
