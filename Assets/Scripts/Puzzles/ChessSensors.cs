using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessSensors : MonoBehaviour
{
    public ChessBoard chessBoard;
    public GameObject torreBpart, peon1Bpart, peon2Bpart, alfilBpart, caballoBpart, peon3Bpart;
    public void OnTriggerEnter(Collider other)
    {
        if (other.name == "Torre 1-4" && gameObject.name == "Casillero  1-1")
        {
            chessBoard.torreB = true;
            other.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            torreBpart.SetActive(false);
        }
        else if (other.name == "Peon 2-3" && gameObject.name == "Casillero 1-2")
        {
            chessBoard.peon1B = true;
            other.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            peon1Bpart.SetActive(false);
        }
        else if (other.name == "Peon 5-3" && gameObject.name == "Casillero  5-2")
        {
            chessBoard.peon2B = true;
            other.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            peon2Bpart.SetActive(false);
        }
        else if(other.name == "Alfil 4-3" && gameObject.name == "Casillero  6-1")
        {
            chessBoard.alfilB = true;
            other.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            alfilBpart.SetActive(false);
        }
        else if(other.name == "Caballo 8-3" && gameObject.name == "Casillero  7-1")
        {
            chessBoard.caballoB = true;
            other.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            caballoBpart.SetActive(false);
        }
        else if(other.name == "Peon 7-4" && gameObject.name == "Casillero  7-2")
        {
            chessBoard.peon3B = true;
            other.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            peon3Bpart.SetActive(false);
        }
    }
}
