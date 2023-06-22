using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessSensors : MonoBehaviour
{
    public bool torreB, peon1B, peon2B, alfilB, caballoB, peon3B, allPieces;
    public GameObject torreBpart, peon1Bpart, peon2Bpart, alfilBpart, caballoBpart, peon3Bpart;
    public void OnTriggerEnter(Collider other)
    {
        if (other.name == "Torre 1-4" && gameObject.name == "Casillero  1-1")
        {
            Debug.Log("estoy en el casillero y soy " + gameObject.name + other.name);
            torreB = true;
            torreBpart.SetActive(false);
        }
        else if (other.name == "Peon 2-3" && gameObject.name == "Casillero 1-2")
        {
            peon1B = true;
            peon1Bpart.SetActive(false);
        }
        else if (other.name == "Peon 5-3" && gameObject.name == "Casillero  5-2")
        {
            peon2B = true;
            peon2Bpart.SetActive(false);
        }
        else if(other.name == "Alfil 4-3" && gameObject.name == "Casillero  6-1")
        {
            alfilB = true;
            alfilBpart.SetActive(false);
        }
        else if(other.name == "Caballo 8-3" && gameObject.name == "Casillero  7-1")
        {
            caballoB = true;
            caballoBpart.SetActive(false);
        }
        else if(other.name == "Peon 7-4" && gameObject.name == "Casillero  7-2")
        {
            peon3B = true;
            peon3Bpart.SetActive(false);
        }
    }

    private void Update()
    {
        if (peon1B && peon2B && peon3B && torreB && alfilB && caballoB)
        {
            allPieces = true;
            Debug.Log("update de los sendor pieces");

        }
    }
}
